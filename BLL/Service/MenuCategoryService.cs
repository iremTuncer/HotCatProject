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
    public class MenuCategoryService : IMenuCategoryService
    {
        private readonly IRepository<MenuCategory> _menuCategoryService;
        public MenuCategoryService(IRepository<MenuCategory> menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }
        public void AddMenuCategory(MenuCategory menuCategory)
        {
            _menuCategoryService.Insert(menuCategory);
        }

        public void DeleteMenuCategory(MenuCategory menuCategory)
        {
            _menuCategoryService.Delete(menuCategory);
        }

        public IEnumerable<MenuCategory> GetAllMenuCategories()
        {
            return _menuCategoryService.GetAll().ToList();
        }

        public MenuCategory GetMenuCategoryById(int id)
        {
            return _menuCategoryService.Get(id);
        }

        public void UpdateMenuCategory(MenuCategory menuCategory)
        {
            _menuCategoryService.Update(menuCategory);
        }
    }
}
