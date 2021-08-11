using TheUser.Business.Models;

namespace TheUser.Business.Interfaces
{
    public interface IUserValidationService
    {
        bool Validate(IUser user);
    }
}
