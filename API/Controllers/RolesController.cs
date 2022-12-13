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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            try
            {
                var AllRoles = _roleService.GetAllRoles();
                if(AllRoles == null)
                { 
                    return NotFound();
                }
                List<RoleDto> roles = new List<RoleDto>();

                foreach(var role in AllRoles)
                {
                    RoleDto roleDto = new RoleDto();
                    roleDto.Id = role.Id;
                    roleDto.RoleName = role.RoleName;
                    roles.Add(roleDto);
                }
                return Ok(roles);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddRole(RoleDto roleDto)
        {
            try
            {
                Role role = new Role()
                {Id = 0,
                 RoleName = roleDto.RoleName,
                };

                if (role.Id == null)
                    return BadRequest();
                _roleService.AddRole(role);
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
                var role = _roleService.GetRoleById(id);
                RoleDto roleDto = new RoleDto();
                roleDto.RoleName = role.RoleName;
                roleDto.Id = role.Id;
                return Ok(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateRole(RoleDto roleDto)
        {
            try
            {
                var savedrole = GetById(roleDto.Id);
                if (savedrole == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Role role = new Role()
                {
                    Id = roleDto.Id,
                    RoleName = roleDto.RoleName,
                };
                _roleService.UpdateRole(role);
                return Ok("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteRole(RoleDto roleDto)
        {
            try
            {
                var savedrole = GetById(roleDto.Id);
                if (savedrole == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Role role = new Role()
                {
                    Id = roleDto.Id,
                    RoleName=roleDto.RoleName,
                };
                _roleService.DeleteRole(role);
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
