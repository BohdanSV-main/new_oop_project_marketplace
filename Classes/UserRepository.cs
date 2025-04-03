using Marketplace;
using User = Marketplace.User;//just work

public class UserRepository : IUserRepository
{
    private readonly IDataStorage<User> _storage;

    public UserRepository(IDataStorage<User> storage)
    {
        _storage = storage;
    }

    public void AddUser(User user)
    {
        _storage.Add(user);
        _storage.Save();
    }

    public void UpdateUser(User user)
    {
        _storage.Update(user);
    }

    public void DeleteUser(int id)
    {
        _storage.Delete(id);
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
