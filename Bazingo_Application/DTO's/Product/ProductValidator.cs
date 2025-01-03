using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Product
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator( )
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .MaximumLength(100).WithMessage("Product Name must not exceed 100 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be equal to or greater than 0.");

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be equal to or greater than 0.");
        }
    }
}
