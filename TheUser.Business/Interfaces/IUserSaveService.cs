using TheUser.Business.Models;

namespace TheUser.Business.Interfaces
{
    public interface IUserSaveService
    {
        void Save(IUser user);
    }
}
