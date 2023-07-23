using MyApp.Domain.Entities;

namespace MyApp.Application.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        //public int Status { get; set; }
        //public string StatusText { get; set; }

        public UserDTO(User user)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            Email = user.Email;
            PasswordSalt = user.PasswordSalt;
            PasswordHash = user.PasswordHash;
            //Status = (int)user.Status;
            //StatusText = user.Status.ToString();
        }
    }
}