﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BelInt_WebHelper.Models;
using BelInt_WebHelper.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BelInt_WebHelper.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;
        BelIntDbContext _context;
        public UsersController(UserManager<User> userManager, BelIntDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    //Id = user.Id,
                    //Roles = roles,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    DepartmentId = model.DepartmentId,
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    SurName = model.SurName,


                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Roles = _context.Roles.ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id, string name)
        {
            User user = new User();
            if (!string.IsNullOrWhiteSpace(id))
                user = await _userManager.FindByIdAsync(id);
            else
                user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(user);
            EditUserViewModel model = new EditUserViewModel
            {
                Id = user.Id,
                //Roles = roles,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                DepartmentId = user.DepartmentId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Position = user.Position,
                SurName = user.SurName
            };
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Roles = _context.Roles.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.Id);
                if (user != null)
                {
                    user.SurName = model.SurName;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.DateOfBirth = model.DateOfBirth;
                    user.NormalizedEmail = model.Email.ToUpper();
                    user.DepartmentId = model.DepartmentId;
                    user.NormalizedUserName = user.UserName = model.UserName.ToUpper();
                    user.Position = model.Position;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (_userManager.IsInRoleAsync(user, "Admin").Result)
                        {
                            return RedirectToAction("Index", "Users");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Roles = _context.Roles.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        //Изменение пароля
        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, UserName = user.UserName };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }


    }
}