using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
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
