using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.DataModels;

namespace Project.UI.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
