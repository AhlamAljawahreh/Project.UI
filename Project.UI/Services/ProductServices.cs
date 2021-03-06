using Microsoft.AspNetCore.Components;
using Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.UI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient httpClient;
        public ProductServices(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await httpClient.GetJsonAsync<Product[]>("api/products");
        }

        public async Task<Product> AddMeal(Product product)
        {
            return await httpClient.PostJsonAsync<Product>("api/products", product);
        }

        public async Task<HttpResponseMessage> EditMeal(Product product , int id)
        {
            return await httpClient.PutJsonAsync<HttpResponseMessage>($"api/products/{id}",product);
        }

        public async Task<Product> GetMeal(int id)
        {
            return await httpClient.GetJsonAsync<Product>($"api/products/{id}");
        }
        public async Task<HttpResponseMessage> DeleteMeal(int id)
        {
            return await httpClient.DeleteAsync($"api/products/{id}");
        }
        public async Task<IEnumerable<Product>> GetOrderProducts(int id)
        {
            return await httpClient.GetJsonAsync<Product[]>($"api/orders/myorder/{id}");
        }
    }
     
}
