using Xunit;
using MyApp.Application.Services;
using MyApp.Application.Models.Requests;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Domain.Exceptions;
using MyApp.Domain.Core.Specifications;
using MyApp.Application.Core.Services;
using MyApp.Application.Core.Repositories;
using Moq;

namespace MyApp.Application.Test.Services
{
    public class UserServiceTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<ILoggerService> _loggerMock = new Mock<ILoggerService>();
        private UserService _userService;

        public UserServiceTest()
        {
            _userService = new UserService(_unitOfWorkMock.Object, _loggerMock.Object);
        }

    }
}