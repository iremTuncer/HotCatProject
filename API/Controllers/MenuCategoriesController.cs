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
    public class MenuCategoriesController : ControllerBase
    {
        private readonly IMenuCategoryService _menuCategoryService;
        public MenuCategoriesController(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService; 
        }

        [HttpGet]
        public IActionResult GetAllMenuCategories()
        {
            try
            {
                var AllMenuCategories = _menuCategoryService.GetAllMenuCategories();
                if (AllMenuCategories == null)
                {
                    return NotFound();
                }
                List<MenuCategoryDto> menuCategories = new List<MenuCategoryDto>();

                foreach (var menuCategory in AllMenuCategories)
                {
                    MenuCategoryDto menuCategoryDto = new MenuCategoryDto();
                    menuCategoryDto.Id = menuCategory.Id;
                    menuCategoryDto.CategoryName = menuCategory.CategoryName;
                    menuCategories.Add(menuCategoryDto);
                }
                return Ok(menuCategories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddMenuCategory(MenuCategoryDto menuCategoryDto)
        {
            try
            {
                MenuCategory menuCategory = new MenuCategory()
                {
                    Id = 0,
                    CategoryName = menuCategoryDto.CategoryName,
                };

                if (menuCategory.Id == null)
                    return BadRequest();
                _menuCategoryService.AddMenuCategory(menuCategory);
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
                var menuCategory = _menuCategoryService.GetMenuCategoryById(id);
                MenuCategoryDto menuCategoryDto = new MenuCategoryDto();
                menuCategoryDto.Id = menuCategory.Id;
                menuCategoryDto.CategoryName = menuCategory.CategoryName;
                return Ok(menuCategory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateMenuCategory(MenuCategoryDto menuCategoryDto)
        {
            try
            {
                var savedmenuCategory = GetById(menuCategoryDto.Id);
                if (savedmenuCategory == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                MenuCategory menuCategory = new MenuCategory()
                {
                    Id = menuCategoryDto.Id,
                    CategoryName = menuCategoryDto.CategoryName,
                };
                _menuCategoryService.UpdateMenuCategory(menuCategory);
                return Ok("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteMenuCategory(MenuCategoryDto menuCategoryDto)
        {
            try
            {
                var savedmenuCategory = GetById(menuCategoryDto.Id);
                if (savedmenuCategory == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                MenuCategory menuCategory = new MenuCategory()
                {
                    Id = menuCategoryDto.Id,
                    CategoryName = menuCategoryDto.CategoryName,
                };
                _menuCategoryService.DeleteMenuCategory(menuCategory);
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
