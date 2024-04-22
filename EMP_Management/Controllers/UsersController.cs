using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMP_Management.Data;
using EMP_Management.Models;

namespace EMP_Management.Controllers
{
    public class UsersController : Controller
    {
        private readonly EmployeeDbContext _context;

        public UsersController(EmployeeDbContext context)
        {
            _context = context;
        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");


        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user)
        {
            var existingUser = _context.User.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existingUser != null)
            {
                // User authenticated
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                // Invalid credentials
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }

        //    // GET: Users
        //    public async Task<IActionResult> Index()
        //    {
        //        return View(await _context.User.ToListAsync());
        //    }

        //    // GET: Users/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var users = await _context.User
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (users == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(users);
        //    }

        //    // GET: Users/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Users/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,Email,Password,IsAdmin")] Users users)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(users);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(users);
        //    }

        //    // GET: Users/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var users = await _context.User.FindAsync(id);
        //        if (users == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(users);
        //    }

        //    // POST: Users/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,IsAdmin")] Users users)
        //    {
        //        if (id != users.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(users);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!UsersExists(users.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(users);
        //    }

        //    // GET: Users/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var users = await _context.User
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (users == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(users);
        //    }

        //    // POST: Users/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var users = await _context.User.FindAsync(id);
        //        if (users != null)
        //        {
        //            _context.User.Remove(users);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool UsersExists(int id)
        //    {
        //        return _context.User.Any(e => e.Id == id);
        //    }
        //
        }
    }
