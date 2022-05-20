using Microsoft.AspNetCore.Components;
using Project.DataModels;
using Project.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.UI.Services
{
    public class OrderServices : IOrderServices
    {

        private readonly HttpClient httpClient;

        public OrderServices(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await httpClient.GetJsonAsync<Order[]>("api/orders");
        }
       
    
    }
}
