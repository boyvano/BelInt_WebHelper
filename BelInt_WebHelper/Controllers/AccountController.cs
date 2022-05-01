using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BelInt_WebHelper.Models;
using BelInt_WebHelper.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BelInt_WebHelper.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly List<Department> _departamentList; // Выбрать из БД список отделов

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(_departamentList);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { FirstName=model.FirstName, SurName = model.SurName, LastName = model.LastName, Email = model.Email, Department = model.Department, UserName = model.Email, DateOfBirth = model.DateOfBirth };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}