using Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataModels
{
    public class UserCred
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Result
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } = "USER";

    }
}
