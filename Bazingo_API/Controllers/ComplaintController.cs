using Bazingo_Application.DTO_s.Complaint;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitComplaint([FromBody] SubmitComplaintDto dto)
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var result = await _complaintService.SubmitComplaint(userId , dto);
            return result ? Ok("Complaint submitted successfully") : BadRequest("Failed to submit complaint");
        }

        [HttpGet("user-complaints")]
        public async Task<IActionResult> GetUserComplaints( )
        {
            var userId = User.Identity?.Name ?? "Unknown";
            var complaints = await _complaintService.GetUserComplaints(userId);
            return Ok(complaints);
        }

        [HttpGet("{complaintId}")]
        public async Task<IActionResult> GetComplaintById(int complaintId)
        {
            var complaint = await _complaintService.GetComplaintById(complaintId);
            return complaint != null ? Ok(complaint) : NotFound("Complaint not found");
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateComplaintStatus([FromBody] UpdateComplaintStatusDto dto)
        {
            var result = await _complaintService.UpdateComplaintStatus(dto);
            return result ? Ok("Complaint status updated successfully") : BadRequest("Update failed");
        }
    }
}
