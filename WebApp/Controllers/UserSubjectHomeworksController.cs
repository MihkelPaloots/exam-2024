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
    public class UserSubjectHomeworksController : Controller
    {
        private readonly AppDbContext _context;

        public UserSubjectHomeworksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserSubjectHomeworks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserSubjectHomeworks.Include(u => u.Homework).Include(u => u.UserSubject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserSubjectHomeworks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubjectHomework = await _context.UserSubjectHomeworks
                .Include(u => u.Homework)
                .Include(u => u.UserSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubjectHomework == null)
            {
                return NotFound();
            }

            return View(userSubjectHomework);
        }

        // GET: UserSubjectHomeworks/Create
        public IActionResult Create()
        {
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "Id", "Description");
            ViewData["UserSubjectId"] = new SelectList(_context.UserSubjects, "Id", "Id");
            return View();
        }

        // POST: UserSubjectHomeworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserSubjectId,HomeworkId,Mark,Id")] UserSubjectHomework userSubjectHomework)
        {
            if (ModelState.IsValid)
            {
                userSubjectHomework.Id = Guid.NewGuid();
                _context.Add(userSubjectHomework);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "Id", "Description", userSubjectHomework.HomeworkId);
            ViewData["UserSubjectId"] = new SelectList(_context.UserSubjects, "Id", "Id", userSubjectHomework.UserSubjectId);
            return View(userSubjectHomework);
        }

        // GET: UserSubjectHomeworks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubjectHomework = await _context.UserSubjectHomeworks.FindAsync(id);
            if (userSubjectHomework == null)
            {
                return NotFound();
            }
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "Id", "Description", userSubjectHomework.HomeworkId);
            ViewData["UserSubjectId"] = new SelectList(_context.UserSubjects, "Id", "Id", userSubjectHomework.UserSubjectId);
            return View(userSubjectHomework);
        }

        // POST: UserSubjectHomeworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserSubjectId,HomeworkId,Mark,Id")] UserSubjectHomework userSubjectHomework)
        {
            if (id != userSubjectHomework.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSubjectHomework);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSubjectHomeworkExists(userSubjectHomework.Id))
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
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "Id", "Description", userSubjectHomework.HomeworkId);
            ViewData["UserSubjectId"] = new SelectList(_context.UserSubjects, "Id", "Id", userSubjectHomework.UserSubjectId);
            return View(userSubjectHomework);
        }

        // GET: UserSubjectHomeworks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubjectHomework = await _context.UserSubjectHomeworks
                .Include(u => u.Homework)
                .Include(u => u.UserSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubjectHomework == null)
            {
                return NotFound();
            }

            return View(userSubjectHomework);
        }

        // POST: UserSubjectHomeworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userSubjectHomework = await _context.UserSubjectHomeworks.FindAsync(id);
            if (userSubjectHomework != null)
            {
                _context.UserSubjectHomeworks.Remove(userSubjectHomework);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSubjectHomeworkExists(Guid id)
        {
            return _context.UserSubjectHomeworks.Any(e => e.Id == id);
        }
    }
}
