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

        public async Task<Order> CreateOrder(Order order)
        {
            return await httpClient.PostJsonAsync<Order>("api/orders", order);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await httpClient.GetJsonAsync<Order[]>("api/orders");
        }

        public async Task<HttpResponseMessage> DeleteOrder(int id)
        {
            return await httpClient.DeleteAsync($"api/orders/{id}");
        }
    }
}
