using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Order
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator( )
        {
            RuleFor(o => o.BuyerID)
                .NotEmpty().WithMessage("Buyer ID is required.");

            RuleFor(o => o.TotalAmount)
                .GreaterThan(0).WithMessage("Total Amount must be greater than 0.");

            RuleFor(o => o.Status)
                .Must(s => new[] { "Pending" , "Shipped" , "Completed" , "Canceled" }.Contains(s))
                .WithMessage("Invalid order status.");
        }
    }
}
