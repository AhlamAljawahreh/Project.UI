using Microsoft.AspNetCore.Components;
using Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.UI.Services
{
    public class UsersServices : IUserServices
    {

        private readonly HttpClient httpClient;
        public UsersServices(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<User> Register(User user)
        {
            return await httpClient.PostJsonAsync<User>("api/users", user);
        }
    }
}
