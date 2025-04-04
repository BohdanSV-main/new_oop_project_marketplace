using System.Collections.Generic;

namespace Marketplace
{
    public interface IUserRepository : IGeneralProps<User>
    {
        User GetUserByLogin(string login);
        int GetNextUserId();
    }
}
