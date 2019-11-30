using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Rodkulman.MilkMafia.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rodkulman.MilkMafia.Services
{
    public static class ServerDataStore
    {
#if DEBUG
        private static readonly RestClient client = new RestClient("http://192.168.0.18/MilkMafia");
#else
        private static readonly RestClient client = new RestClient("http://142.93.71.132");
#endif
        private static Guid token;
        private static Guid refresh;

        public static async Task<Category[]> GetDatabase()
        {
            var reponse = await Request("api/v0/Categories/All");

            if (reponse.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Category[]>(reponse.Content.Substring(1, reponse.Content.Length - 2));
            }
            else
            {
                return null;
            }
        }

        private static async Task<IRestResponse> Request(string path)
        {
            var request = new RestRequest(path, Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized && !string.IsNullOrWhiteSpace(response.Content))
            {
                var content = JObject.Parse(response.Content);

                if (content.TryGetValue("Reason", out JToken reason) && reason.Value<string>() == "expired")
                {
                    if (await RefreshToken())
                    {
                        response = await Request(path);
                    }
                }
            }

            return response;
        }

        public static byte[] GetImage(BaseImageModel model)
        {
            // TODO: cache image and retrieve locally

            var id = model.ImageId;

            if (!string.IsNullOrWhiteSpace(id))
            {
                GetImageAsync(id).ContinueWith(x => model.SetImage(x.Result));
            }            

            return null;
        }

        public static async Task<byte[]> GetImageAsync(string id)
        {
            var reponse = await Request($"api/v0/Images/{id}");

            if (reponse.IsSuccessful)
            {
                return reponse.RawBytes;
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool> Login(string cpf)
        {            
            var request = new RestRequest($"api/v0/login", Method.POST);

            using (var hashAlgorithm = SHA512.Create())
            {
                var hash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(cpf));
                request.AddParameter("body", Convert.ToBase64String(hash), "text/plain", ParameterType.RequestBody);
            }            

            var reponse = await client.ExecuteTaskAsync(request);

            if (reponse.IsSuccessful)
            {
                var content = JObject.Parse(reponse.Content);

                token = Guid.Parse(content.Value<string>("token"));
                refresh = Guid.Parse(content.Value<string>("refresh"));

                return true;
            }
            else
            {
                return false;
            }
        }

        private static async Task<bool> RefreshToken()
        {
            var request = new RestRequest($"api/v0/refresh", Method.POST);
            request.AddParameter("body", refresh.ToString(), "text/plain", ParameterType.RequestBody);

            var reponse = await client.ExecuteTaskAsync(request);

            if (reponse.IsSuccessful)
            {
                var content = JObject.Parse(reponse.Content);

                token = Guid.Parse(content.Value<string>("token"));
                refresh = Guid.Parse(content.Value<string>("refresh"));

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
