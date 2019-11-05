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
        private static readonly RestClient client = new RestClient("");

        public static async Task<Category[]> GetCategoriesAsync()
        {
            var request = new RestRequest("api/v1/Category", Method.GET);
            var reponse = await client.ExecuteTaskAsync(request);

            if (reponse.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Category[]>(reponse.Content);
            }
            else
            {
                return null;
            }
        }

        public static async Task<Product[]> GetProductsAsync(Category category)
        {
            var request = new RestRequest($"api/v1/Product/{category.Id}", Method.GET);
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
