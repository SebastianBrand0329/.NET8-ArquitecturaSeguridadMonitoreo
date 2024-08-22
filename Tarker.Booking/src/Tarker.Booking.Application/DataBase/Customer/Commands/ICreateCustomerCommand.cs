using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;

namespace Tarker.Booking.Application.DataBase.Customer.Commands
{
    public interface ICreateCustomerCommand
    {
        Task<CreateCustomerModel> Execute(CreateCustomerModel model);
    }
}
