using System.Collections.Generic;

namespace Marketplace
{
    public interface IUserRepository
    {
        User GetUserByLogin(string login);
        void AddUser(User user);
        int GetNextUserId();
    }
}
