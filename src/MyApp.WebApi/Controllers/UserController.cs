using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;
using MyApp.Application.Models.Responses.UserResponse;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserRes>> CreateUser(CreateUserReq user)

        {

          

                try
                {

                if (await CheckUserExist(user.UserName)) return BadRequest("Username is taken");

                var result = await _userService.CreateUser(user);

                    var response = new ApiResponse()
                    {
                        Success = true,
                        Message = "User created successfully.",
                      
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    // Log the exception
                    // You can add more specific error handling here based on different exception types
                    var errorResponse = new ApiResponse()
                    {
                        Success = false,
                        Message = "Failed to create user."
                    }; 
                    return StatusCode(500, errorResponse);
                }
            }
        
        private async Task<bool> CheckUserExist(string username)
        {
            return await _userService.UserExist(username);
        }
        //[HttpPost]
        //public async Task<ActionResult<ValidateUserRes>> ValidateUser(ValidateUserReq req)
        //{
        //    var result = await _userService.ValidateUser(req);
        //    return Ok(result);
        //}

        [HttpGet]

        public async Task<ActionResult<GetAllActiveUsersRes>> GetAllActiveUsers()
        {



            var result = await _userService.GetAllActiveUsers();
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<ActionResult<GetSingleUseeRes>> GetSingleUser(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        
    }
}
