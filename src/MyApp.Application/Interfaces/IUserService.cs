using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses.UserResponse;

namespace MyApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserRes> CreateUser(CreateUserReq req);

        //Task<ValidateUserRes> ValidateUser(ValidateUserReq req);
        Task<bool> UserExist(string username);
        Task<GetAllActiveUsersRes> GetAllActiveUsers();

        Task<GetSingleUseeRes> GetUserById(int id);
    }
}