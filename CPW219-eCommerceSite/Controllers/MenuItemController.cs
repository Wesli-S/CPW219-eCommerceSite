using Microsoft.AspNetCore.Mvc;

namespace CPW219_eCommerceSite.Controllers
{
    public class MenuItemController : Controller
    {
        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }
    }
}
