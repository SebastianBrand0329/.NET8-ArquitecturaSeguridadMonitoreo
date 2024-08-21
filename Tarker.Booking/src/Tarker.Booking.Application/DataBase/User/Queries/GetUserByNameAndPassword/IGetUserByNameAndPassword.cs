namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword
{
    public interface IGetUserByNameAndPassword
    {
        Task<GetUserByNameAndPasswordModel> Execute(string userName, string password);
    }
}
