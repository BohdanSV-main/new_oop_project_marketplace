public class User
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public bool IsAdmin { get; set; } 

    public User(string login, string passwordHash, bool isAdmin = false)
    {
        Login = login;
        PasswordHash = passwordHash;
        IsAdmin = isAdmin;
    }
}
