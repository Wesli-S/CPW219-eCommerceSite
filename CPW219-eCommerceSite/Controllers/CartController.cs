using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CPW219_eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly MenuItemContext _context;
        private const string Cart = "ShoppingCart"; 

        public CartController(MenuItemContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            MenuItem? itemToCart = _context.MenuItems.Where(m => m.MenuItemID == id).SingleOrDefault();

            if (itemToCart == null)
            {
                TempData["Message"] = "Sorry! This item is no longer available";
                return RedirectToAction("Index", "MenuItem");
            }

            CartItemViewModel cartItem = new()//object mapping
            {
                ItemId = itemToCart.MenuItemID,
                ItemName = itemToCart.MenuItemName,
                ItemPrice = itemToCart.MenuItemPrice
            };

            List<CartItemViewModel> cartItems = GetExistingCartData();
            cartItems.Add(cartItem);
            WriteShoppingCartCookie(cartItems);
            //ToDo: Add item to a shopping cart cookie
            TempData["Message"] = "Item added to cart!";
            return RedirectToAction("Index", "MenuItem"); ;
        }

        private void WriteShoppingCartCookie(List<CartItemViewModel> cartItems)
        {
            string cookieData = JsonConvert.SerializeObject(cartItems);//returns a string

            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            });
        }

        /// <returns>
        /// Current List of items in the users shopping cart cookie.
        /// If there is no cookie, an empty list should be returned
        /// </returns>
        private List<CartItemViewModel> GetExistingCartData()
        {
            string? cookie = HttpContext.Request.Cookies[Cart];
            if (string.IsNullOrWhiteSpace(cookie))
            {
                return new List<CartItemViewModel>();
            }
            return JsonConvert.DeserializeObject<List<CartItemViewModel>>(cookie);
        }

        public IActionResult Summary()
        {
            //Read shopping cart data and convert to list of view model
            List<CartItemViewModel> cartItems = GetExistingCartData();
            return View(cartItems);
        }

        public IActionResult Remove(int id)
        {
            //Remove specified item from the cookie
            List<CartItemViewModel> cartItems = GetExistingCartData();

            CartItemViewModel targetItem =
                cartItems.Where(m => m.ItemId == id).FirstOrDefault();

            cartItems.Remove(targetItem);

            WriteShoppingCartCookie(cartItems);

            return RedirectToAction("Summary");

        }
    }
}
