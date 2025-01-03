using Bazingo_Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Identity
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator( )
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50).WithMessage("First Name must not exceed 50 characters.");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50).WithMessage("Last Name must not exceed 50 characters.");

            RuleFor(u => u.UserType)
                .Must(t => new[] { "Buyer" , "Seller" }.Contains(t))
                .WithMessage("Invalid User Type.");
        }
    }
}
