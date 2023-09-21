using NewwebApp.Data;
using NewwebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewwebApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Xml.Linq;

namespace NewwebApp.Controllers
{
    [Authorize (Roles ="Admin")]
    public class UsersViewController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public UsersViewController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
                _userManager = userManager;
                _roleManager = roleManager;
        }

        // GET: UsersViewController
        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users.Select( u => new UserViewmodel
            {
               Id=u.Id,
               Name=u.Name,
               Address = u.Address,
               DateOfBirth=u.DOB,
               Gender=u.Gender,
               Email=u.Email,
               PhoneNumbber=u.Numbber,
               Age = DateTime.Now.Year - u.DOB.Year,
               Roles= (List<string>)_userManager.GetRolesAsync(u).Result

        }).ToListAsync();
            
            return View(users);
        }


        // GET: UsersViewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersViewController/Create
        public async Task<ActionResult> Create()
        {
            
            var roles =await _roleManager.Roles.Select(r=> new RoleViewmodel

            { RoleId = r.Id , RoleName = r.Name}).ToListAsync();

            var model = new AddUserviewmodel
            {
                Roles = roles
              
            };

            return View(model);
        }



        // POST: UsersViewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddUserviewmodel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            if(!model.Roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("Roles", "Please select at least one role");
                return View(model);
            }

            if(await _userManager.FindByEmailAsync(model.Email) != null)
            {

                ModelState.AddModelError("Email", "Email is already exist");
                return View(model);
            }

            if (await _userManager.FindByNameAsync(model.Name) != null)
            {

                ModelState.AddModelError("Name", "Name is already exist");
                return View(model);
            }

            var user = new ApplicationUser();

            
            user.Email = model.Email;
       
            user.Name = model.Name;
            user.Gender = model.Gender;
            user.Address = model.Address;
            user.DOB = model.DOB;
            user.Numbber = model.Numbber;

            var result = await _userManager.CreateAsync(user, model.Password);


            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Roles", error.Description);
                }
            }

            await _userManager.AddToRolesAsync(user, model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName));

            return RedirectToAction(nameof(Index));
        }

        // GET: UsersViewController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                ViewBag.ErrorMessage = $"user with id  = {id} cannt be found";
                return View("NotFound");
            }
            var model = new EditUserViewmodel
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address,
                DOB = user.DOB,
                Gender = user.Gender,
                Email = user.Email,
                Numbber = user.Numbber,
              
            };

            return View(model);
        }

        // POST: UsersViewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( EditUserViewmodel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"user with id  = {model.Id} cannt be found";
                return View("NotFound");
            }
            else
            {
                user.Id = model.Id;
                user.Name = model.Name;
                user.Address = model.Address;
                user.DOB = model.DOB;
                user.Gender = model.Gender;
                user.Email = model.Email;
                user.Numbber = model.Numbber;


                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                { return RedirectToAction("Index"); }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }


        }

        //// GET: UsersViewController/Delete/5
        //public async Task<ActionResult> Delete(DeleteUserViewmodel model)
        //{
        //    var user = await _userManager.FindByIdAsync(model.Id);

        //    return View(user);
        //}

        //// POST: UsersViewController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"user with id  = {id} cannt be found";
        //        return View("NotFound");
        //    }

        //    else
        //    {

        //        var result = await _userManager.DeleteAsync(user);

        //        if (result.Succeeded)
        //        { return RedirectToAction("Index"); }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }

        //        return View("Index");
        //    }
        //}

        //[HttpDelete]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();

        //    }

        //    var result = await _userManager.DeleteAsync(user);

        //    if (!result.Succeeded)
        //    {
        //        throw new Exception();
        //    }

        //    return Ok();
        //}
    }
}
