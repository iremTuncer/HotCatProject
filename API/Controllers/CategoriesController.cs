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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var AllCategories = _categoryService.GetAllCategories();
                if (AllCategories == null)
                {
                    return NotFound();
                }
                List<CategoryDto> categories = new List<CategoryDto>();

                foreach (var category in AllCategories)
                {
                    CategoryDto categoryDto = new CategoryDto();
                    categoryDto.Id = category.Id;
                    categoryDto.CategoryName = category.CategoryName;
                    categories.Add(categoryDto);
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            try
            {
                Category category = new Category()
                {
                    Id = 0,
                    CategoryName = categoryDto.CategoryName,
                };

                if (category.Id == null)
                    return BadRequest();
                _categoryService.AddCategory(category);
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
                var category = _categoryService.GetCategoryById(id);
                CategoryDto categoryDto = new CategoryDto();
                categoryDto.Id = category.Id;
                categoryDto.CategoryName = category.CategoryName;
                return Ok(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryDto categoryDto)
        {
            try
            {
                var savedcategory = GetById(categoryDto.Id);
                if (savedcategory == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Category category = new Category()
                {
                    Id = 0,
                    CategoryName = categoryDto.CategoryName,
                };
                _categoryService.UpdateCategory(category);
                return Ok("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory(CategoryDto categoryDto)
        {
            try
            {
                var savedcategory = GetById(categoryDto.Id);
                if (savedcategory == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Category category = new Category()
                {
                    Id = 0,
                    CategoryName = categoryDto.CategoryName,
                };
                _categoryService.DeleteCategory(category);
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
