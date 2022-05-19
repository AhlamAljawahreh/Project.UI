using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DataModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private readonly MyDBContext context;
       // public List<User> users;


        public LoginController(IJWTAuthenticationManager jWTAuthenticationManager, MyDBContext context)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this.context = context;

        }

        // GET: api/<signinController>
      

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCred userCred)
        {
             List<User> users = await context.Users.ToListAsync();
             Console.WriteLine(users);
           


            if (!users.Any(u => u.Username == userCred.Username && u.Password == userCred.Password))
            {
                
                    return Unauthorized();
                
            }
            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            Result result = new Result();
            User myUser = users.Find(u => u.Username == userCred.Username && u.Password == userCred.Password);
            result.FirstName = myUser.FirstName;
            result.Role = myUser.Role;
            result.Username = myUser.Username;
            result.UserId = myUser.UserId;
            result.LastName = myUser.LastName;


            result.Token = token;
           

            return Ok( result);
        }

       
    }
}
