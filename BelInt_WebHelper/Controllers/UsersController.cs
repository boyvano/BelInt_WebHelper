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

        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, DateOfBirth = model.DateOfBirth };
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
            EditUserViewModel model = new EditUserViewModel
            {
                Id = user.Id,
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
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    user.Id = model.Id;
                    user.Email = model.Email;
                    user.NormalizedEmail = model.Email.ToUpper();
                    user.DateOfBirth = model.DateOfBirth;
                    user.DepartmentId = model.DepartmentId;
                    user.UserName = model.UserName;
                    user.NormalizedUserName = user.UserName = model.UserName.ToUpper();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Position = model.Position;
                    user.SurName = model.SurName;

                    var result = await _userManager.UpdateAsync(user);
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
            }
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
    }
}