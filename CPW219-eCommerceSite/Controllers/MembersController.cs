﻿using CPW219_eCommerceSite.Data;
using CPW219_eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219_eCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly MenuItemContext _context;
        public MembersController(MenuItemContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel) 
        {
            if(ModelState.IsValid)
            {
                //Map RegisterViewModel data to Member object
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                //redirect to homepage
                return RedirectToAction("Index", "Home");

            }
            return View(regModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //Check DB for credentials
                Member? m = (from member in _context.Members
                           where member.Email == loginModel.Email &&
                           member.Password == loginModel.Password
                           select member).SingleOrDefault();

                //If exists, send to homepage
                if (m != null)
                {
                    HttpContext.Session.SetString("Email", loginModel.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Oops! Couldn't find ya! Make sure ya spelled everything right!");
            }
            //If not, display error
            return View(loginModel);
        }
    }
}