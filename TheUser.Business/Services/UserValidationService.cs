using TheUser.Business.Interfaces;
using System.Net.Mail;
using System;

namespace TheUser.Business.Services
{
    public class UserValidationService : IUserValidationService
    {
        public bool Validate(IUser user)
        {
            if (!ValidateEmail(user))
            {
                return false;
            }
            return true;
        }
        public bool ValidateEmail(IUser user)
        {
            try
            {
                MailAddress m = new MailAddress(user.Email);
                return true;
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
    }
}
