using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IComplaintService
    {
        Task<bool> SubmitComplaint(string userId , SubmitComplaintDto dto);
        Task<IEnumerable<ComplaintDto>> GetUserComplaints(string userId);
        Task<ComplaintDto> GetComplaintById(int complaintId);
        Task<bool> UpdateComplaintStatus(UpdateComplaintStatusDto dto);
        Task<IEnumerable<ComplaintDto>> AdminGetAllComplaints( );
    }
}
