using Xunit;
using Moq;
using TheUser.Business.Interfaces;
using TheUser.Business.Services;

namespace TheUser.Tests.UserSaveServiceTests
{
    public class Save
    {
        private readonly Mock<IUserValidationService> _userValidationService;
        private readonly IUserSaveService _userSaveService;

        public Save()
        {
            _userValidationService = new Mock<IUserValidationService>();
            _userSaveService = new UserSaveService(_userValidationService.Object);
        }

        [Fact]
        public void ItShouldSaveANewUser()
        {

        }

        [Fact]
        public void ItShouldNotSaveAUserWhenUserDataIsInvalid()
        {

        }
    }
}
