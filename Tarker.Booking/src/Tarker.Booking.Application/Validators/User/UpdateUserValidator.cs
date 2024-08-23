using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("No Puede ser nulo")
                                  .GreaterThan(0);

            RuleFor(x => x.FirstName).NotNull().WithMessage("No Puede ser nulo")
                                     .NotEmpty().WithMessage("No Puede ser vacio")
                                     .MaximumLength(50).WithMessage("Excede el tamaño máximo");

            RuleFor(x => x.LastName).NotNull().WithMessage("No Puede ser nulo")
                                    .NotEmpty().WithMessage("No Puede ser vacio")
                                    .MaximumLength(50).WithMessage("Excede el tamaño máximo");

            RuleFor(x => x.UserName).NotNull().WithMessage("No Puede ser nulo")
                                    .NotEmpty().WithMessage("No Puede ser vacio")
                                    .MaximumLength(50).WithMessage("Excede el tamaño máximo");

            RuleFor(x => x.Password).NotNull().WithMessage("No Puede ser nulo")
                                    .NotEmpty().WithMessage("No Puede ser vacio")
                                    .MaximumLength(10).WithMessage("Excede el tamaño máximo");
        }
    }
}