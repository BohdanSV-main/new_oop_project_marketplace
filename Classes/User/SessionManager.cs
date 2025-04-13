using Marketplace;
public static class SessionManager
{
    public static User CurrentUser { get; private set; }

    public static void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }

    public static void Logout()
    {
        CurrentUser = null;
    }
}
