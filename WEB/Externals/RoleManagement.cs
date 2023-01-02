using BLL.IService;
using BLL.Service;

namespace WEB.Externals
{
    public class RoleManagement
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;

        public RoleManagement(IEmployeeService employeeService, IRoleService roleService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
        }

        public string GetRole(int id)
        {
           var user= _employeeService.GetEmployeeById( id);

            if (user.RoleId!=null)
            {
               var role = _roleService.GetRoleById(user.RoleId.Value);
               return role.RoleName;
            }

            return "";
        }
    }
}
