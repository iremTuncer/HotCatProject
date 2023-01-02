using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.IService;
using NuGet.Configuration;
using NuGet.Protocol.Plugins;
using Entity.Entity;

namespace WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMenuService _menu;
        private readonly IOrderService _order;


        public OrderController(IMenuService menu, IOrderService order)
        {
            _menu = menu;
            _order = order;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var cookie = Request.Cookies["table"];
            if (cookie == null) return Redirect("/");

            int table = Convert.ToInt32(cookie);
            var order = _order.GetAllOrders().FirstOrDefault(x => x.TableNo == table && x.IsPaid == false);
            if (order == null) return Redirect("/");

            foreach (var item in order.MenuList)
            {
                order.TotalPrice = order.TotalPrice + (item.UnitInPrice * item.piece);
            }
            return View(order);
        }

        //[HttpGet, Route("id")]
        public IActionResult AddItem(int id)
        {
            var item = _menu.GetMenuById(id);

            var cookie = Request.Cookies["table"];
            int table = Convert.ToInt32(cookie);


            var orders = _order.GetAllOrders().ToList();
            var order = orders.FirstOrDefault(x => x.TableNo == table && x.IsPaid == false);

            if (order != null)
            {
                var selectItem = order.MenuList.Where(o => o.Name == item.Name).FirstOrDefault();
                if (selectItem != null)
                {
                    selectItem.piece = selectItem.piece + 1;
                    order.MenuList.Add(selectItem);
                    _order.UpdateOrder(order);
                }

                else
                {
                    SelectedMenu selectedMenu = new SelectedMenu() { UnitInPrice = item.UnitInPrice, Name = item.Name, piece = 1 };
                    order.MenuList.Add(selectedMenu);
                    _order.UpdateOrder(order);
                }
            }
            else
            {
                SelectedMenu selectedMenu = new SelectedMenu() { UnitInPrice = item.UnitInPrice, Name = item.Name ,piece=1};
                Order newOrder = new Order()
                {
                    TableNo = table,
                    TotalPrice = 0,
                    IsPaid = false,
                    MenuList = new List<SelectedMenu>() { selectedMenu }
                };

                _order.AddOrder(newOrder);
            }

            return Redirect("https://localhost:7043/Menu");

        }

        public IActionResult PayItem(int id)
        {
            var order =_order.GetOrderById(id);
            order.IsPaid = true;
            _order.UpdateOrder(order);

            return View();
        }
    }
}
