using Xunit;
using FluentAssertions;
using Moq;
using TheUser.Business.Interfaces;
using TheUser.Business.Services;
using System.Collections.Generic;
using TheUser.Business.Models;

namespace TheUser.Tests.UserValidationServiceTests
{
    public class Validate
    {
        private readonly IUserValidationService _userValidationService;
        private readonly Mock<IUserRepository> _userRepository;

        public Validate ()
        {
            _userRepository = new Mock<IUserRepository>();
            _userValidationService = new UserValidationService(_userRepository.Object);
        }

        [Theory]
        [InlineData("johndoe@example.com")]
        [InlineData("123@test.com")]
        public void ItShouldAcceptValidEmails(string email)
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.Email).Returns(email);

            // Act
            bool result = _userValidationService.ValidateEmail(mockUser.Object);

            // Assert
            result.Should().Be(true);
        }

        [Theory]
        [InlineData("Hello World")]
        [InlineData("test")]
        [InlineData("1")]
        [InlineData("@.com")]
        [InlineData("test@.com")]
        [InlineData("")]
        public void ItShouldRejectInvalidEmails(string notAnEmail)
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.Email).Returns(notAnEmail);

            // Act
            bool result = _userValidationService.ValidateEmail(mockUser.Object);

            // Assert
            result.Should().Be(false);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("prefix lastname")]
        public void ItShouldAcceptLastNames(string lastName)
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.LastName).Returns(lastName);

            // Act
            bool result = _userValidationService.ValidateLastName(mockUser.Object);

            // Assert
            result.Should().Be(true);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ItShouldRejectEmptyLastNames(string lastName)
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.LastName).Returns(lastName);

            // Act
            bool result = _userValidationService.ValidateLastName(mockUser.Object);

            // Assert
            result.Should().Be(false);
        }

        [Fact]
        public void ItShouldRejectDuplicateEmails()
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.Email).Returns("duplicate@example.com");

            _userRepository.Setup(x => x.GetAll()).Returns(
                new List<IUser>
                {
                    new User { Email = "duplicate@example.com" }
                }
            );

            // Act
            bool result = _userValidationService.ValidateEmail(mockUser.Object);

            // Assert
            result.Should().Be(false);
        }

        [Fact]
        public void ItShouldMarkUsersWithoutLastNameInvalid()
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.Email).Returns("test@example.com");

            // Act
            bool result = _userValidationService.Validate(mockUser.Object);

            // Assert
            result.Should().Be(false);
        }

        [Fact]
        public void ItShouldMarkUsersWithoutEmailInvalid()
        {
            // Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.LastName).Returns("Doe");

            // Act
            bool result = _userValidationService.Validate(mockUser.Object);

            // Assert
            result.Should().Be(false);
        }
    }
}
