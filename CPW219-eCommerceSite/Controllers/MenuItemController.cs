using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing.Text;

namespace CPW219_eCommerceSite.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly MenuItemContext _context;
        public MenuItemController(MenuItemContext context)
        {
                _context = context;
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                //Add to DB
                _context.MenuItems.Add(menuItem); //prepares insert
                await _context.SaveChangesAsync();//executes pending insert

                //Show success message on page
                ViewData["Message"] = $"{menuItem.MenuItemName} was added successfully!";

                return View();
            }
            return View(menuItem);
        } 

        public async Task<IActionResult> Edit(int id) 
        {
            MenuItem menuItemToEdit = await _context.MenuItems.FindAsync(id);
            if (menuItemToEdit != null)
            {
                return NotFound();
            }
            return View(menuItemToEdit);
        }
    }
}
