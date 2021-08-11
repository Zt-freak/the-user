using TheUser.Business.Interfaces;
using TheUser.Business.Models;

namespace TheUser.Business.Services
{
    public class UserSaveService : IUserSaveService
    {
        private IUserValidationService _userValidationService { get; set; }
        public UserSaveService(IUserValidationService userValidationService)
        {
            _userValidationService = userValidationService;
        }
        public void Save(IUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
