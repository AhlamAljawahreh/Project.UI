
//using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json;
//using System.Text.Json.Serialization;

namespace Project.DataModels
{
   public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } = "USER";

      // [JsonIgnore]
        public string Password { get; set; }


    }
}
