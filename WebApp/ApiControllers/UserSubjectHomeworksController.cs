using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSubjectHomeworksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserSubjectHomeworksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserSubjectHomeworks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSubjectHomework>>> GetUserSubjectHomeworks()
        {
            return await _context.UserSubjectHomeworks.ToListAsync();
        }

        // GET: api/UserSubjectHomeworks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSubjectHomework>> GetUserSubjectHomework(Guid id)
        {
            var userSubjectHomework = await _context.UserSubjectHomeworks.FindAsync(id);

            if (userSubjectHomework == null)
            {
                return NotFound();
            }

            return userSubjectHomework;
        }

        // PUT: api/UserSubjectHomeworks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSubjectHomework(Guid id, UserSubjectHomework userSubjectHomework)
        {
            if (id != userSubjectHomework.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSubjectHomework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSubjectHomeworkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserSubjectHomeworks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSubjectHomework>> PostUserSubjectHomework(UserSubjectHomework userSubjectHomework)
        {
            _context.UserSubjectHomeworks.Add(userSubjectHomework);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSubjectHomework", new { id = userSubjectHomework.Id }, userSubjectHomework);
        }

        // DELETE: api/UserSubjectHomeworks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSubjectHomework(Guid id)
        {
            var userSubjectHomework = await _context.UserSubjectHomeworks.FindAsync(id);
            if (userSubjectHomework == null)
            {
                return NotFound();
            }

            _context.UserSubjectHomeworks.Remove(userSubjectHomework);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSubjectHomeworkExists(Guid id)
        {
            return _context.UserSubjectHomeworks.Any(e => e.Id == id);
        }
    }
}
