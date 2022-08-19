using Assignments.Entity;
using FluentValidation;
using System;

namespace Assignments.ValidationRules
{
    public class StaffRules : AbstractValidator<Staff>
    {
        public StaffRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This field cannot be  empty");
            RuleFor(x => x.Name).MinimumLength(20).MaximumLength(120).WithMessage("It must be 20 to 120 characters long");
            RuleFor(x => x.Name).Matches(@"^[a-zA-Z]+$").WithMessage("Invalid Format");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("This field cannot be  empty");
            RuleFor(x => x.LastName).MinimumLength(20).MaximumLength(120).WithMessage("It must be between 20 and 120 characters.");
            RuleFor(x => x.LastName).Matches(@"^[a-za-z-']*$").WithMessage("Invalid Format");
            RuleFor(x => x.DateOfBirth.Date).NotEmpty().WithMessage("This field cannot be  empty");
            RuleFor(x => x.DateOfBirth.Date).InclusiveBetween(new DateTime(1945, 11, 11), new DateTime(2002, 10, 10)).WithMessage("Date is out of range.It must be between 2000 and 9000 . 1945, 11, 11 / 2002, 10, 10");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("This field cannot be  empty");
            RuleFor(x => x.Salary).GreaterThan(2000).LessThan(9000).WithMessage("Salary is out of the range.It must be between 2000 and 9000 .");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("This field cannot be  empty");
            RuleFor(x => x.PhoneNumber).Matches(@"^([\+]?90[-]?|[0])?[1-9][0-9]{8}$").WithMessage("Invalid Phone Number");
            RuleFor(x => x.Email).NotEmpty().WithMessage("This field cannot be  empty");
            RuleFor(x => x.Email).EmailAddress().Matches(@"[a-zA-Z_\-.]").WithMessage("Invalid Format");
        }
    }
}
