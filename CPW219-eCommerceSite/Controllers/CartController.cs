using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219_eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly MenuItemContext _context;

        public CartController(MenuItemContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            MenuItem? itemToCart = _context.MenuItems.Where(m => m.MenuItemID == id).SingleOrDefault();

            if(itemToCart == null)
            {
                TempData["Message"] = "Sorry! This item is no longer available";
                return RedirectToAction("Index", "MenuItem");
            }

            //ToDo: Add item to a shopping cart cookie
            TempData["Message"] = "Item added to cart!";
            return RedirectToAction("Index", "MenuItem"); ;
        }
    }
}
