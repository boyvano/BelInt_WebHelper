using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BelInt_WebHelper.Models;
using BelInt_WebHelper.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace BelInt_WebHelper.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        BelIntDbContext _context;
        private readonly List<Department> _departamentList; // Выбрать из БД список отделов

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,BelIntDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { FirstName=model.FirstName, Position=model.Position,  SurName = model.SurName, LastName = model.LastName, Email = model.Email, DepartmentId = model.DepartmentId, UserName = model.Email, DateOfBirth = model.DateOfBirth };
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