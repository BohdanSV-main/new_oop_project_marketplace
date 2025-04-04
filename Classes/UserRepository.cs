using Marketplace;
using User = Marketplace.User;//just work

public class UserRepository : GeneralProps<User>, IUserRepository

{

    private readonly IDataStorage<User> _storage;

    public UserRepository(IDataStorage<User> storage) : base(storage)
    {
        _storage = storage;
    }

    public User? GetUserByLogin(string login)
    {
        return _storage.GetAll().FirstOrDefault(u => u.Login == login);
    }

    public int GetNextUserId()
    {
        var users = _storage.GetAll();
        if (users.Count == 0)
        {
            return 1;
        }
        return users.Max(u => u.Id) + 1;
    }

    public List<User> GetAllUsers()
    {
        return _storage.GetAll();
    }
}
