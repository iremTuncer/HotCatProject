using BLL.IService;
using BLL.Repository;
using BLL.Service;
using DTO.DTO;
using Entity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public IActionResult GetAllMenu()
        {
            try
            {
                List<Menu> AllMenus = _menuService.GetAllMenus().ToList();
                if (AllMenus == null)
                {

                    return NotFound();
                }
                List<MenuDto> menuListDto = new List<MenuDto>();
                foreach (var menu in AllMenus)
                {
                    MenuDto menuDto = new MenuDto();
                    menuDto.Id = menu.Id;
                    menuDto.Name = menu.Name;
                    menuDto.UnitInPrice = menu.UnitInPrice;
                    menuDto.MenuCategoryId = menu.MenuCategoryId;

                    if (!menu.ProductList.IsNullOrEmpty()) { 
                    List<ProductDto> productListDto = new List<ProductDto>();
                    foreach (var item in menu.ProductList)
                    {
                        ProductDto productDto = new ProductDto();
                        productDto.Id = item.Id;
                        productDto.ProductName = item.ProductName;
                        productDto.UnitInStock = item.UnitInStock;
                        productListDto.Add(productDto);
                    }
                    menuDto.ProductList = productListDto;
                    }
                    menuListDto.Add(menuDto);
                }
                return Ok(menuListDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPost]
        public IActionResult AddMenu(MenuDto menuDto)
        {
            try
            {
                List<Product> productListDto = new List<Product>();
                foreach (var item in menuDto.ProductList)
                {
                    Product product = new Product();
                    product.Id = item.Id;
                    product.ProductName = item.ProductName;
                    product.UnitInStock = item.UnitInStock;
                    product.UnitPrice = item.UnitPrice;
                    product.CategoryNameId = item.CategoryNameId;
                    productListDto.Add(product);

                }
                Menu menu = new Menu()
                {
                    Id = 0,
                    Name = menuDto.Name,
                    UnitInPrice = menuDto.UnitInPrice,
                    MenuCategoryId = menuDto.MenuCategoryId.Value,
                    ProductList = productListDto,
                };
                if (menu.Id == null)
                    return BadRequest();
                _menuService.AddMenu(menu);
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
                var menu = _menuService.GetMenuById(id);
                List<ProductDto> productListDto = new List<ProductDto>();
                foreach (var item in menu.ProductList)
                {
                    ProductDto productDto = new ProductDto();
                    productDto.Id = item.Id;
                    productDto.ProductName = item.ProductName;
                    productDto.UnitInStock = item.UnitInStock;
                    productListDto.Add(productDto);
                }
                MenuDto menuDto = new MenuDto()
                {
                    Id = menu.Id,
                    Name = menu.Name,
                    UnitInPrice = menu.UnitInPrice,
                    MenuCategoryId = menu.MenuCategoryId,
                    ProductList = productListDto
                };
                return Ok(menuDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPut]
        public IActionResult UpdateMenu(MenuDto menuDto)
        {
            try
            {
                var savedmenu = GetById(menuDto.Id);
                if (savedmenu == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                List<Product> productListDto = new List<Product>();
                foreach (var item in menuDto.ProductList)
                {
                    Product product = new Product();
                    product.Id = item.Id;
                    product.ProductName = item.ProductName;
                    product.UnitInStock = item.UnitInStock;
                    product.UnitPrice = item.UnitPrice;
                    
                    product.CategoryNameId = item.CategoryNameId;
                    productListDto.Add(product);

                }
                Menu menu = new Menu()
                {
                    Id = menuDto.Id,
                    Name = menuDto.Name,
                    UnitInPrice = menuDto.UnitInPrice,
                    MenuCategoryId = menuDto.MenuCategoryId.Value,
                    ProductList = productListDto,
                };
                _menuService.UpdateMenu(menu);
                return Ok("Kayıt başarılı!");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpDelete]
        public IActionResult DeleteMenu(MenuDto menuDto)
        {
            try
            {
                var savedmenu = GetById(menuDto.Id);
                if (savedmenu == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Menu menu = new Menu()
                {
                    Id = menuDto.Id,
                    Name = menuDto.Name,
                    UnitInPrice = menuDto.UnitInPrice,
                    MenuCategoryId = menuDto.MenuCategoryId.Value,
                  
                };
                _menuService.DeleteMenu(menu);
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
