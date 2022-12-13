using BLL.IService;
using BLL.Service;
using DTO.DTO;
using Entity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var AllOrders = _orderService.GetAllOrders();
                if(AllOrders == null)
                {
                    return NotFound();
                }
                List<OrderDto> orders = new List<OrderDto>();
                
                foreach (var order in AllOrders)
                {
                    OrderDto orderDto = new OrderDto();
                    orderDto.Id = order.Id;
                    orderDto.TableNo = order.TableNo;
                    orderDto.TotalPrice = order.TotalPrice;
                    orderDto.IsPaid = order.IsPaid;
                    List<MenuDto> menu = new List<MenuDto>();
                    foreach (var item in order.OrderList)
                    {
                        MenuDto menuDto = new MenuDto();
                        menuDto.Name = item.Name;
                        menuDto.UnitInPrice = item.UnitInPrice;
                        menuDto.MenuCategoryId = item.MenuCategoryId;
                        menuDto.Id = item.Id;
                        menu.Add(menuDto);
                    }
                    orderDto.OrderList = menu;
                    orders.Add(orderDto);
                }
                
                return Ok(orders);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPost]
        public IActionResult AddOrder(OrderDto orderDto)
        {
            try
            {
                Order order = new Order()
                {
                    Id = 0,
                    TableNo = orderDto.TableNo,
                    TotalPrice = orderDto.TotalPrice,
                    IsPaid = orderDto.IsPaid,

                    
                };
                if (order.Id == null)
                    return BadRequest();
                _orderService.AddOrder(order);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();
                var order = _orderService.GetOrderById(id);
                OrderDto orderDto = new OrderDto();
                orderDto.Id = order.Id;
                orderDto.TableNo = order.TableNo;
                orderDto.TotalPrice = order.TotalPrice;
                List<MenuDto> menu = new List<MenuDto>();
                foreach (var item in order.OrderList)
                {
                    MenuDto menuDto = new MenuDto();
                    menuDto.Name = item.Name;
                    menuDto.UnitInPrice = item.UnitInPrice;
                    menuDto.MenuCategoryId = item.MenuCategoryId;
                    menuDto.Id = item.Id;
                    menu.Add(menuDto);
                }
                orderDto.OrderList = menu;
                return Ok(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPut]
        public IActionResult UpdateOrder(OrderDto orderDto)
        {
            try
            {
                var savedorder = GetById(orderDto.Id);
                if (savedorder == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                List<Menu> menuList = new List<Menu>();
                foreach (var item in orderDto.OrderList)
                {
                    Menu menu = new Menu();
                    menu.Name = item.Name;
                    menu.Id = item.Id;
                    menuList.Add(menu);
                }
                Order order = new Order()
                {
                    Id = orderDto.Id,
                    TableNo = orderDto.TableNo,
                    TotalPrice = orderDto.TotalPrice,
                    IsPaid = orderDto.IsPaid,
                    OrderList = menuList
                };
                _orderService.UpdateOrder(order);
                return Ok("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteOrder(OrderDto orderDto)
        {
            try
            {
                var savedorder = GetById(orderDto.Id);
                if (savedorder == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                
                Order order = new Order()
                {
                    Id = orderDto.Id,
                    TableNo = orderDto.TableNo,
                    TotalPrice = orderDto.TotalPrice,
                    IsPaid = orderDto.IsPaid,
                    
                };
                _orderService.DeleteOrder(order);
                return Ok("Silme başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

    }
}
