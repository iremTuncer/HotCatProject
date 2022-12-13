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
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuService;

        public MenuService(IRepository<Menu> menuService)
        {
            _menuService = menuService;
        }
        public void AddMenu(Menu menu)
        {
            _menuService.Insert(menu);
        }

        public void DeleteMenu(Menu menu)
        {
            _menuService.Delete(menu);
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return _menuService.GetAll().ToList();
        }

        public Menu GetMenuById(int id)
        {
            return _menuService.Get(id);
        }

        public void UpdateMenu(Menu menu)
        {
            _menuService.Update(menu);
        }
    }
}
