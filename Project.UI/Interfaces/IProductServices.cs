using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Project.DataModels;

namespace Project.UI.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddMeal(Product product);
        Task<HttpResponseMessage> EditMeal(Product product,int id);
        Task<Product> GetMeal(int id);
        Task<HttpResponseMessage> DeleteMeal(int id);


    }
}
