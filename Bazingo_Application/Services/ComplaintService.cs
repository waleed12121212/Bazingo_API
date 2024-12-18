using Bazingo_Application.DTO_s;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly ApplicationDbContext _context;

        public ComplaintService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComplaintResponseDTO>> GetComplaintsAsync( )
        {
            var complaints = await _context.Complaints.Include(c => c.User).ToListAsync();
            return complaints.Adapt<IEnumerable<ComplaintResponseDTO>>();
        }

        public async Task<ComplaintResponseDTO> CreateComplaintAsync(ComplaintCreateDTO complaintDto)
        {
            var complaint = complaintDto.Adapt<Complaint>();
            complaint.CreatedAt = DateTime.UtcNow;
            complaint.Status = "Open";

            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();

            return complaint.Adapt<ComplaintResponseDTO>();
        }

        public async Task UpdateComplaintStatusAsync(int id , string status)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null) throw new Exception("Complaint not found.");

            complaint.Status = status;
            complaint.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
