using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WOMB_Final.Data;
using WOMB_Final.Models;

namespace WOMB_Final.Controllers
{
    public class UserViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserViewModelsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;

            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModel = new List<UserViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserViewModel();
                //thisViewModel.Id = user.Id;
                //thisViewModel.Email = user.Email;
                thisViewModel.title = user.title;
                thisViewModel.LastName = user.LastName;
                thisViewModel.gender = user.gender;
                thisViewModel.Occupation = user.Occupation;
                userViewModel.Add(thisViewModel);
            }
            return View(userViewModel);
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        //public UserViewModelsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: UserViewModels
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.UserViewModel.ToListAsync());
        //}

        // GET: UserViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = await _context.UserViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userViewModel == null)
            {
                return NotFound();
            }

            return View(userViewModel);
        }

        // GET: UserViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,FirstName,LastName,gender,Address,Occupation,DOB,Bio,ConsultationFee,HPCSAnumber,URL,PhoneNumber,Email")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // GET: UserViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = await _context.UserViewModel.FindAsync(id);
            if (userViewModel == null)
            {
                return NotFound();
            }
            return View(userViewModel);
        }

        // POST: UserViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,FirstName,LastName,gender,Address,Occupation,DOB,Bio,ConsultationFee,HPCSAnumber,URL,PhoneNumber,Email")] UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserViewModelExists(userViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // GET: UserViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = await _context.UserViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userViewModel == null)
            {
                return NotFound();
            }

            return View(userViewModel);
        }

        // POST: UserViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userViewModel = await _context.UserViewModel.FindAsync(id);
            _context.UserViewModel.Remove(userViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserViewModelExists(int id)
        {
            return _context.UserViewModel.Any(e => e.Id == id);
        }
    }
}
