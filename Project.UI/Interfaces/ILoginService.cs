using Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.UI.Services
{
   public interface ILoginService
    {
        Task<Result> Authenticate(UserCred user);
    }
}
