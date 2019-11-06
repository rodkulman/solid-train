using Newtonsoft.Json;
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

        public static async Task<Category[]> GetCategoriesAsync()
        {
            var request = new RestRequest("api/v0/Categories", Method.GET);
            var reponse = await client.ExecuteTaskAsync(request);

            if (reponse.IsSuccessful)
            {
                var retVal = JsonConvert.DeserializeObject<Category[]>(reponse.Content);

                Array.Resize(ref retVal, retVal.Length + 1);

                retVal[^1] = Category.All;

                return retVal;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Product[]> GetProductsAsync(Category category)
        {
            var request = new RestRequest($"api/v0/Products/{category.Id}", Method.GET);
            var reponse = await client.ExecuteTaskAsync(request);

            if (reponse.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Product[]>(reponse.Content);
            }
            else
            {
                return null;
            }
        }
    }
}
