using MyApp.Application.Models.Requests;
using MyApp.Domain.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Domain.Exceptions;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Application.Core.Repositories;
using MyApp.Application.Core.Services;
using MyApp.Application.Models.Responses.UserResponse;
using System.Security.Cryptography;
using System.Text;

namespace MyApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;
      

        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<CreateUserRes> CreateUser(CreateUserReq req)
        {
            
              using  var hmac = new HMACSHA512(); 
            
            
            
            var user = await _unitOfWork.Repository<User>().AddAsync(new User
            {   Email = req.Email,
                UserName = req.UserName,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(req.Password)),
                PasswordSalt = hmac.Key
              
            });
            await _unitOfWork.SaveChangesAsync();
            return new CreateUserRes() { Data = new UserDTO(user) };
        }

       public async Task<bool> UserExist(string username)
        {
            var specification = UserSpecifications.GetUserByUsername(username);
            return await _unitOfWork.Repository<User>().EntityExists(specification);
        }

        public async Task<GetSingleUseeRes> GetUserById(int id)
        {
            var getUser = UserSpecifications.GetUserById(id);
            var user = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(getUser);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            
            return new GetSingleUseeRes()
            {
                UserName = user.UserName
        
               
            };

        }

        public async Task<GetAllActiveUsersRes> GetAllActiveUsers()
        {
            //var activeUsersSpec = UserSpecifications.GetAllActiveUsersSpec();
            var users = await _unitOfWork.Repository<User>().ListAllAsync();

            return new GetAllActiveUsersRes()
            {
                Data = users.Select(x => new UserDTO(x)).ToList()
            };
        }

       
    }
}