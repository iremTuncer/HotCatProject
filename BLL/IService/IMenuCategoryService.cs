using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IMenuCategoryService
    {
        IEnumerable<MenuCategory> GetAllMenuCategories();
        void AddMenuCategory(MenuCategory menuCategory);
        void DeleteMenuCategory(MenuCategory menuCategory);
        void UpdateMenuCategory(MenuCategory menuCategory);
        MenuCategory GetMenuCategoryById(int id);
    }
}
