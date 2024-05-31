using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.Controllers
{
    public class UserSubjectsController : Controller
    {
        private readonly AppDbContext _context;

        public UserSubjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserSubjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserSubjects.Include(u => u.AppUser).Include(u => u.Role).Include(u => u.Subject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserSubjects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubject = await _context.UserSubjects
                .Include(u => u.AppUser)
                .Include(u => u.Role)
                .Include(u => u.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubject == null)
            {
                return NotFound();
            }

            return View(userSubject);
        }

        // GET: UserSubjects/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Code");
            return View();
        }

        // POST: UserSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppUserId,SubjectId,RoleId,Mark,Id")] UserSubject userSubject)
        {
            userSubject.Id = Guid.NewGuid();
            _context.Add(userSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: UserSubjects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubject = await _context.UserSubjects.FindAsync(id);
            if (userSubject == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userSubject.AppUserId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", userSubject.RoleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Code", userSubject.SubjectId);
            return View(userSubject);
        }

        // POST: UserSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AppUserId,SubjectId,RoleId,Mark,Id")] UserSubject userSubject)
        {
            if (id != userSubject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSubjectExists(userSubject.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName", userSubject.AppUserId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName", userSubject.RoleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Code", userSubject.SubjectId);
            return View(userSubject);
        }

        // GET: UserSubjects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubject = await _context.UserSubjects
                .Include(u => u.AppUser)
                .Include(u => u.Role)
                .Include(u => u.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubject == null)
            {
                return NotFound();
            }

            return View(userSubject);
        }

        // POST: UserSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userSubject = await _context.UserSubjects.FindAsync(id);
            if (userSubject != null)
            {
                _context.UserSubjects.Remove(userSubject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSubjectExists(Guid id)
        {
            return _context.UserSubjects.Any(e => e.Id == id);
        }
    }
}
