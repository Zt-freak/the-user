using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUser.Business.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<IUser> GetAll();
        void Add(IUser user);
        void Update(IUser user);
        void Delete(int userId);
    }
}
