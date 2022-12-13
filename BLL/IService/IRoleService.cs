using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();

        void AddRole(Role role);

        void UpdateRole(Role role);

        void DeleteRole(Role role);

        Role GetRoleById(int id);
    }
}
