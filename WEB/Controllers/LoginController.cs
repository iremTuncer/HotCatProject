using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEB.Externals.Requets;
using Microsoft.IdentityModel.Tokens;
using WEB.Externals;
using BLL.IService;

namespace WEB.Controllers
{
    public class LoginController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;

        public LoginController(IEmployeeService employeeService, IRoleService roleService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
        }
        public string Id { get; set; }
        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        private bool ValidateLogin(string userName, string password)
        {
            var Isvalid = LoginRequets.IsLogin(userName, password);

            if (!Isvalid.IsNullOrEmpty())
            {
                Id = Isvalid.ToString();
                return true;
            }

            return false;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            // Normally Identity handles sign in, but you can do it directly
            if (ValidateLogin(userName, password))
            {
                RoleManagement role = new RoleManagement(_employeeService, _roleService);
                string userRole =role.GetRole(Convert.ToInt32(Id));

                var claims = new List<Claim>
                {
                    new Claim("user", userName),
                    new Claim("role", userRole)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "user", "role")));

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
