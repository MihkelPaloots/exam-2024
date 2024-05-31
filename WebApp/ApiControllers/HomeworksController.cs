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
    public class HomeworksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HomeworksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Homeworks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHomeworks()
        {
            return await _context.Homeworks.ToListAsync();
        }

        // GET: api/Homeworks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homework>> GetHomework(Guid id)
        {
            var homework = await _context.Homeworks.FindAsync(id);

            if (homework == null)
            {
                return NotFound();
            }

            return homework;
        }

        // PUT: api/Homeworks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomework(Guid id, Homework homework)
        {
            if (id != homework.Id)
            {
                return BadRequest();
            }

            _context.Entry(homework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeworkExists(id))
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

        // POST: api/Homeworks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Homework>> PostHomework(Homework homework)
        {
            _context.Homeworks.Add(homework);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomework", new { id = homework.Id }, homework);
        }

        // DELETE: api/Homeworks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomework(Guid id)
        {
            var homework = await _context.Homeworks.FindAsync(id);
            if (homework == null)
            {
                return NotFound();
            }

            _context.Homeworks.Remove(homework);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeworkExists(Guid id)
        {
            return _context.Homeworks.Any(e => e.Id == id);
        }
    }
}
