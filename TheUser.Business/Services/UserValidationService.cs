using TheUser.Business.Interfaces;
using System.Net.Mail;
using System;
using System.Linq;

namespace TheUser.Business.Services
{
    public class UserValidationService : IUserValidationService
    {
        private IUserRepository _userRepository { get; set; }
        public UserValidationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Validate(IUser user)
        {
            bool emailValid = ValidateEmail(user);
            bool lastNameValid = ValidateLastName(user);

            if (!emailValid || !lastNameValid)
            {
                return false;
            }
            return true;
        }

        public bool ValidateEmail(IUser user)
        {
            if (_userRepository.GetAll().Where(u => u.Email.Equals(user.Email)).Any())
            {
                return false;
            }

            try
            {
                MailAddress m = new(user.Email);
                if (!string.IsNullOrWhiteSpace(m.Address))
                {
                    return true;
                }
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidateLastName(IUser user)
        {
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                return false;
            }
            return true;
        }
    }
}
