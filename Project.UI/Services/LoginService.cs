using Microsoft.AspNetCore.Components;
using Project.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Project.UI.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient httpClient;

        public LoginService(HttpClient _httpClient) 
        {
            this.httpClient = _httpClient;
        }

        public async Task< Result> Authenticate(UserCred user)
        {
            var response =  await httpClient.PostAsJsonAsync("api/login/Authenticate",user);

            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error");
            }

            return await response.Content.ReadFromJsonAsync<Result>();
        }

    }

}
