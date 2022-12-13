using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();

        void AddOrder(Order order);
        void UpdateOrder(Order order);

        void DeleteOrder(Order order);
        Order GetOrderById(int id);
    }
}
