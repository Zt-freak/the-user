using TheUser.Business.Models;

namespace TheUser.Business.Interfaces
{
    public interface IUserValidationService
    {
        bool Validate(IUser user);
        bool ValidateEmail(IUser user);
        bool ValidateLastName(IUser user);
    }
}
