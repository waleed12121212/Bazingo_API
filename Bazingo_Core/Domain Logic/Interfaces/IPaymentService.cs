using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> InitiatePayment(InitiatePaymentDto dto);
        Task<PaymentDto> GetPaymentStatus(int paymentId);
        Task<bool> RefundPayment(RefundPaymentDto dto);
        Task<IEnumerable<PaymentDto>> GetUserPayments(string userId);
        Task<IEnumerable<PaymentDto>> AdminViewAllPayments( );
    }
}
