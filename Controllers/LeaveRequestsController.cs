using Microsoft.AspNetCore.Mvc;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LeaveRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequests()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        // GET: api/LeaveRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetLeaveRequest(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }
            return leave;
        }

        // POST: api/LeaveRequests
        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> PostLeaveRequest(LeaveRequest leave)
        {
            _context.LeaveRequests.Add(leave);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeaveRequest), new { id = leave.Id }, leave);
        }

        // PUT: api/LeaveRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveRequest(int id, LeaveRequest leave)
        {
            if (id != leave.Id)
            {
                return BadRequest("Leave request ID mismatch.");
            }

            _context.Entry(leave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.LeaveRequests.Any(e => e.Id == id))
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

        // DELETE: api/LeaveRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            _context.LeaveRequests.Remove(leave);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
