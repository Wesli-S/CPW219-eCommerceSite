using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index(int? id)
        {
            const int NumItemsToDisplayPerPage = 3;
            const int PageOffset = 1; //Needed in order to use current page aand figure out the num of items

            int currPage = id.HasValue ? id.Value : 1; //if id hasValue, return value. else id = 1.

            // Get all menu items from the DB
            List<MenuItem> menu = await (from menuItem in _context.MenuItems 
                                         select menuItem)
                                         .Skip(NumItemsToDisplayPerPage * (currPage - PageOffset))
                                         .Take(NumItemsToDisplayPerPage)
                                         .ToListAsync();

            //Show them on the page
            return View(menu);
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
            MenuItem? menuItemToEdit = await _context.MenuItems.FindAsync(id);
            if(menuItemToEdit == null)
            {
                return NotFound();
            }

            return View(menuItemToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (MenuItem menuItemModel)
        {
            if(ModelState.IsValid)
            {
                _context.MenuItems.Update(menuItemModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{menuItemModel.MenuItemName} was updated successfully!";
                return RedirectToAction("Index");
            }
            return View(menuItemModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            MenuItem? menuItemToDelete = await _context.MenuItems.FindAsync(id);

            if( menuItemToDelete == null)
            {
                return NotFound();
            }
            return View(menuItemToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            MenuItem menuItemToDelete = await _context.MenuItems.FindAsync(id);
            if(menuItemToDelete != null)
            {
                _context.Remove(menuItemToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = menuItemToDelete.MenuItemName + " was deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = menuItemToDelete.MenuItemName + " has already been deleted before!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            MenuItem? menuItemDetails = await _context.MenuItems.FindAsync(id);

            if (menuItemDetails == null)
            {
                return NotFound();
            }
            return View(menuItemDetails);
        }
    }
}
