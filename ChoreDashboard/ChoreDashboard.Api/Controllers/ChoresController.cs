using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChoreDashboard.Data;
using ChoreDashboard.Data.Models;

namespace ChoreDashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chore>>> GetChores()
        {
            return await _context.Chores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Chore>> AddChore(Chore chore)
        {
            chore.CreatedAt = DateTime.Now;
            _context.Chores.Add(chore);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChores), new { id = chore.Id }, chore);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null) return NotFound();

            chore.IsCompleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null) return NotFound();

            _context.Chores.Remove(chore);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
