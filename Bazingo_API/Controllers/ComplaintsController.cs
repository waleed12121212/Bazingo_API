using Bazingo_Application.DTO_s;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazingo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // حماية الـ Endpoints
    public class ComplaintsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComplaintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Get All Complaints with Pagination and Filtering
        [HttpGet]
        public async Task<IActionResult> GetComplaints(
            [FromQuery] string? status , // فلترة حسب الحالة
            [FromQuery] int pageNumber = 1 ,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.Complaints.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(c => c.Status == status);
            }

            var totalRecords = await query.CountAsync();
            var complaints = await query
                .Include(c => c.User) // تضمين بيانات المستخدم
                .OrderByDescending(c => c.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var complaintDtos = complaints.Adapt<IEnumerable<ComplaintResponseDTO>>();

            return Ok(new
            {
                TotalRecords = totalRecords ,
                PageNumber = pageNumber ,
                PageSize = pageSize ,
                Data = complaintDtos
            });
        }

        // 2. Get Complaint By ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplaint(int id)
        {
            var complaint = await _context.Complaints
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.ComplaintID == id);

            if (complaint == null)
                return NotFound("Complaint not found.");

            var complaintDto = complaint.Adapt<ComplaintResponseDTO>();
            return Ok(complaintDto);
        }

        // 3. Create New Complaint
        [HttpPost]
        public async Task<IActionResult> CreateComplaint([FromBody] ComplaintCreateDTO complaintDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var complaint = complaintDto.Adapt<Complaint>();
            complaint.CreatedAt = DateTime.UtcNow;
            complaint.Status = "Open"; // الحالة الافتراضية عند إنشاء شكوى جديدة

            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();

            var responseDto = complaint.Adapt<ComplaintResponseDTO>();
            return CreatedAtAction(nameof(GetComplaint) , new { id = responseDto.ComplaintID } , responseDto);
        }

        // 4. Update Complaint Status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateComplaintStatus(int id , [FromBody] UpdateComplaintStatusDTO statusDto)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
                return NotFound("Complaint not found.");

            complaint.Status = statusDto.Status;
            complaint.UpdatedAt = DateTime.UtcNow;

            _context.Complaints.Update(complaint);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Complaint status updated successfully." });
        }

        // 5. Delete Complaint
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
                return NotFound("Complaint not found.");

            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
