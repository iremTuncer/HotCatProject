using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetAllMenus();

        void AddMenu(Menu menu);
        void DeleteMenu(Menu menu);
        void UpdateMenu(Menu menu);
        Menu GetMenuById(int id);
    }
}
