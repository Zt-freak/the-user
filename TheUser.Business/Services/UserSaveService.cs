using System;
using TheUser.Business.Interfaces;
using TheUser.Business.Models;

namespace TheUser.Business.Services
{
    public class UserSaveService : IUserSaveService
    {
        private IUserValidationService _userValidationService { get; set; }
        private IUserRepository _userRepository { get; set; }
        public UserSaveService(IUserRepository userRepository, IUserValidationService userValidationService)
        {
            _userValidationService = userValidationService;
            _userRepository = userRepository;
        }
        public void Save(IUser user)
        {
            if (_userValidationService.Validate(user))
            {
                _userRepository.Add(user);
            }
            else {
                throw new ArgumentException();
            }
        }
    }
}
