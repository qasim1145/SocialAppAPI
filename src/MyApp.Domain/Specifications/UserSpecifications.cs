using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Domain.Core.Specifications;
using System.Linq.Expressions;

namespace MyApp.Domain.Specifications
{
    public static class UserSpecifications
    {
       
        public static BaseSpecification<User> GetUserById(int id)
        {
            return new BaseSpecification<User>(x=>x.UserId == id);
        }

        //public static BaseSpecification<User> GetAllActiveUsersSpec()
        //{
        //    return new BaseSpecification<User>(x => x.Status == UserStatus.Active);
        //}

        public static Expression<Func<User, bool>> GetUserByUsername(string username,string email)
        {
            return user => user.UserName == username || user.Email == email;
        }
        public static Expression<Func<User, bool>> CheckUserNameAndEmail(string credential)
        {
            return user => user.UserName == credential || user.Email == credential;
        }

    }
}
