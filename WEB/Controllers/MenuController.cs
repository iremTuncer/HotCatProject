using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
