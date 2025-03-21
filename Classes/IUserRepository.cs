using System.Collections.Generic;

namespace Marketplace
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByLogin(string login);
    }
}
