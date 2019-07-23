using Animations.DataModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Animations.Services
{
    class ProductService
    {
        //<ObservableCollection<Product>>
        public static ObservableCollection<Product> GetAllProduct()
        {
            var client = new RestClient("http://ec2-52-34-35-1.us-west-2.compute.amazonaws.com:8080/api/product/list");
            var request = new RestRequest(Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhYmNAaG90bWFpbC5jb20iLCJleHAiOjE1NjQ3MzkyMjB9.673p_6OvJGr8MizOa0c7jhf2RikXY09b0ewI_LNEDAkHBZXb9Rk6cvskoDx1mhGuB-OFtZdCywXqqchHRuhRrg");
            //client.ExecuteAsync<Product>(request, r => JsonConvert.DeserializeObject<ObservableCollection<Product>>(r.Content));

            IRestResponse<Product> response = client.Execute<Product>(request);

            return JsonConvert.DeserializeObject<ObservableCollection<Product>>(response.Content);

            // easy async support
            //client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});
        }
    }
}
