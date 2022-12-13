using BLL.IService;
using BLL.Repository;
using Entity.Entity;

namespace BLL.Service
{
    public class RoleService:IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository=roleRepository;
        }

        public void AddRole(Role role)
        {
            _roleRepository.Insert(role);
        }

        public void DeleteRole(Role role)
        {
            _roleRepository.Delete(role);
        }

        public IEnumerable<Role> GetAllRoles()
        {
           return _roleRepository.GetAll().ToList();
        }

        public Role GetRoleById(int id)
        {
            return _roleRepository.Get(id);
        }

        public void UpdateRole(Role role)
        {
           _roleRepository.Update(role);
        }
    }
}
