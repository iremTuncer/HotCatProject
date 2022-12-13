using BLL.IService;
using BLL.Repository;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderService;
        public OrderService(IRepository<Order> orderService)
        {
            _orderService = orderService;
        }
        public void AddOrder(Order order)
        {
            _orderService.Insert(order);
        }

        public void DeleteOrder(Order order)
        {
            _orderService.Delete(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderService.GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderService.Get(id);
        }

        public void UpdateOrder(Order order)
        {
            _orderService.Update(order);
        }
    }
}
