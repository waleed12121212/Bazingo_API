using Bazingo_Application.DTO_s.Payment;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("initiate")]
        public async Task<IActionResult> InitiatePayment([FromBody] InitiatePaymentDto dto)
        {
            var result = await _paymentService.InitiatePayment(dto);
            return result ? Ok("Payment initiated successfully") : BadRequest("Payment initiation failed");
        }

        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPaymentStatus(int paymentId)
        {
            var payment = await _paymentService.GetPaymentStatus(paymentId);
            return payment != null ? Ok(payment) : NotFound("Payment not found");
        }

        [HttpPost("refund")]
        public async Task<IActionResult> RefundPayment([FromBody] RefundPaymentDto dto)
        {
            var result = await _paymentService.RefundPayment(dto);
            return result ? Ok("Payment refunded successfully") : BadRequest("Refund failed");
        }
    }
}
