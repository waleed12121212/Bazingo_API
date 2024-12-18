using Bazingo_Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.Services
{
    public interface IComplaintService
    {
        Task<IEnumerable<ComplaintResponseDTO>> GetComplaintsAsync( );
        Task<ComplaintResponseDTO> CreateComplaintAsync(ComplaintCreateDTO complaintDto);
        Task UpdateComplaintStatusAsync(int id , string status);
    }
}
