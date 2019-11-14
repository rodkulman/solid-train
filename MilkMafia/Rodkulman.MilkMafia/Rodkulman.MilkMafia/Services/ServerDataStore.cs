using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Rodkulman.MilkMafia.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodkulman.MilkMafia.Services
{
    public static class ServerDataStore
    {
        private static readonly RestClient client = new RestClient("http://192.168.0.18/MilkMafia");

        public static async Task<Category[]> GetDatabase()
        {
            var request = new RestRequest("api/v0/Categories/All", Method.GET);
            var reponse = await client.ExecuteTaskAsync(request);

            if (reponse.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Category[]>(reponse.Content.Substring(1, reponse.Content.Length - 2));
            }
            else
            {
                return null;
            }
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
            var request = new RestRequest($"api/v0/Images/{id}", Method.GET);
            var reponse = await client.ExecuteTaskAsync(request);

            if (reponse.IsSuccessful)
            {
                return reponse.RawBytes;
            }
            else
            {
                return null;
            }
        }
    }
}
