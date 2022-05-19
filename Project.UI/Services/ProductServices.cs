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

    }
}
