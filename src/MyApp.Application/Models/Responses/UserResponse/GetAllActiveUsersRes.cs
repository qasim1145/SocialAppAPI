using MyApp.Application.Models.DTOs;

namespace MyApp.Application.Models.Responses.UserResponse
{
    public class GetAllActiveUsersRes
    {
        public IList<UserDTO> Data { get; set; }
    }
}
