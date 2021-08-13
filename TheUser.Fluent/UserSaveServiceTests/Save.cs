using Xunit;
using FluentAssertions;
using Moq;
using TheUser.Business.Interfaces;
using TheUser.Business.Services;
using System;

namespace TheUser.Tests.UserSaveServiceTests
{
    public class Save
    {
        private readonly Mock<IUserValidationService> _userValidationService;
        private readonly IUserSaveService _userSaveService;
        private readonly Mock<IUserRepository> _userRepository;

        public Save()
        {
            _userRepository = new Mock<IUserRepository>();
            _userValidationService = new Mock<IUserValidationService>();
            _userSaveService = new UserSaveService(_userRepository.Object, _userValidationService.Object);
        }

        [Fact]
        public void ItShouldSaveANewUserWhenUserDataIsValid()
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            _userValidationService.Setup(x => x.Validate(mockUser.Object)).Returns(true);
            _userRepository.Setup(x => x.Add(mockUser.Object));

            // Act
            _userSaveService.Save(mockUser.Object);

            // Assert
            _userRepository.Verify(m => m.Add(mockUser.Object), Times.Once());

        }

        [Fact]
        public void ItShouldNotSaveAUserWhenUserDataIsInvalid()
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            _userValidationService.Setup(x => x.Validate(mockUser.Object)).Returns(false);
            _userRepository.Setup(x => x.Add(mockUser.Object));

            // Act & Assert
            _userSaveService.Invoking(x => x.Save(mockUser.Object))
                .Should().Throw<ArgumentException>();
        }
    }
}
