using Xunit;
using Moq;
using TheUser.Business.Interfaces;
using TheUser.Business.Services;

namespace TheUser.Tests.UserValidationServiceTests
{
    public class Validate
    {
        private readonly IUserValidationService _userValidationService;

        public Validate ()
        {
            _userValidationService = new UserValidationService();
        }

        [Theory]
        [InlineData("johndoe@example.com")]
        [InlineData("123@test.com")]
        public void ItShouldMarkEmailsAsValid(string email)
        {
            //Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.Email).Returns(email);

            // Act
            bool result = _userValidationService.Validate(mockUser.Object);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Hello World")]
        [InlineData("test")]
        [InlineData("1")]
        [InlineData("@.com")]
        [InlineData("")]
        public void ItShouldMarkNonEmailsAsInvalid(string notAnEmail)
        {
            //Arrange
            var mockUser = new Mock<IUser>();
            mockUser.SetupGet(x => x.Email).Returns(notAnEmail);

            // Act
            bool result = _userValidationService.Validate(mockUser.Object);

            // Assert
            Assert.False(result);
        }
    }
}
