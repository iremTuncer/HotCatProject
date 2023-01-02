using BLL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WEB.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menu;

        [BindProperty]
        public int table { get; set; }
        //public void OnPost()
        //{
        //    // posted value is assigned to the Number property automatically
        //    var number = Request.Form["tables"];
        //}

        public MenuController(IMenuService menu)
        {
            _menu = menu;
        }

        public IActionResult Index()
        {
            var menus = _menu.GetAllMenus().ToList();
            return View(menus);
        }

        public IActionResult TableNo()
        {
            var data = this.table;

            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddHours(2);
            cookieOptions.Path = "/";
            Response.Cookies.Append("table", data.ToString());



            return Redirect("https://localhost:7043/Menu");
        }



    }
}
