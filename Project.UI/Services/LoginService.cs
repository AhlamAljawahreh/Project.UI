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
        public Result result { set; get; }
        public string token { set; get; }

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

            this.result = await response.Content.ReadFromJsonAsync<Result>();
            this.token=result.Token;

            Console.WriteLine($"Done?{this.token}");
            Console.WriteLine($"ID?{this.result.UserId}");

            return await response.Content.ReadFromJsonAsync<Result>();
        }

    }

}
