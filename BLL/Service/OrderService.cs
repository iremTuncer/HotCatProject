using BLL.IService;
using BLL.Repository;
using DAL.Context;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderService;
        private readonly HotCatDbContext _context;

        public OrderService(IRepository<Order> orderService, HotCatDbContext context)
        {
            _orderService = orderService;
            _context = context;
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
            var orders = _orderService.GetAll().ToList();

            var selectedMenus = _context.SelectedMenus;

            foreach (var item in orders)
            {
                var itemMenus = selectedMenus.Where(x => x.Order.Id == item.Id).ToList();
            }

            return orders;
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
