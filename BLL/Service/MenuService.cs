using BLL.IService;
using BLL.Repository;
using Entity.Entity;

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
            try
            {
                _menuService.Insert(menu);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
           
        }

        public void DeleteMenu(Menu menu)
        {
            _menuService.Delete(menu);
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return _menuService.GetAll();
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
