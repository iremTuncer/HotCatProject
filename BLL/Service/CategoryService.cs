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
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryService;

        public CategoryService(IRepository<Category> categoryService)
        {
            _categoryService = categoryService;
        }
        public void AddCategory(Category category)
        {
            _categoryService.Insert(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryService.Delete(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryService.GetAll().ToList();
        }
        
        public Category GetCategoryById(int id)
        {
            return _categoryService.Get(id);
        }

        public void UpdateCategory(Category category)
        {
            _categoryService.Update(category);
        }
    }
}
