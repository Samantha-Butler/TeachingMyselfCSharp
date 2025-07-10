using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTrackr.Api.Data;
using JobTrackr.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobTrackr.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /api/applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetAll()
        {
            var userId = User.FindFirst("uid")?.Value;
            var apps = await _context.Applications
                .Where(a => a.UserId == userId)
                .ToListAsync();

            return Ok(apps);
        }

        // GET: /api/applications/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetById(int id)
        {
            var userId = User.FindFirst("uid")?.Value;
            var app = await _context.Applications
                .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

            if (app == null) return NotFound();
            return Ok(app);
        }

        // POST: /api/applications
        [HttpPost]
        public async Task<ActionResult<Application>> Create(Application application)
        {
            var userId = User.FindFirst("uid")?.Value;
            application.UserId = userId;

            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }

        // PUT: /api/applications/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Application updatedApplication)
        {
            var userId = User.FindFirst("uid")?.Value;
            if (id != updatedApplication.Id)
                return BadRequest("ID mismatch");

            var existing = await _context.Applications
                .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

            if (existing == null) return NotFound();

            // Update fields...
            existing.CompanyName = updatedApplication.CompanyName;
            existing.Role = updatedApplication.Role;
            existing.Stage = updatedApplication.Stage;
            existing.AppliedDate = updatedApplication.AppliedDate;
            existing.Location = updatedApplication.Location;
            existing.Notes = updatedApplication.Notes;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst("uid")?.Value;
            var application = await _context.Applications
                .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

            if (application == null) return NotFound();

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
