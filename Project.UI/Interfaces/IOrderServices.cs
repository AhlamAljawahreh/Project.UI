using Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Interfaces
{
   public interface IOrderServices
    {
        Task<IEnumerable<Order>> GetOrders();
    }
}
