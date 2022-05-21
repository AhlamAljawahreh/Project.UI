using Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.UI.Interfaces
{
   public interface IOrderServices
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> CreateOrder(Order order);
        Task<HttpResponseMessage> DeleteOrder(int id);
    }
}
