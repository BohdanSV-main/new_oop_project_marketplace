using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Marketplace
{
    public class UserRepository : IUserRepository
    {
        private readonly string filePath = "users.json";
        private List<User> users = new List<User>();

        public UserRepository()
        {
            LoadUsers();
        }

        public void AddUser(User user)
        {
            users.Add(user);
            SaveUsers();
        }

        public User GetUserByLogin(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }

        private void SaveUsers()
        {
            string json = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, json);
        }

        private void LoadUsers()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
        }
        public void MakeUserAdmin(string login)
        {
            User user = GetUserByLogin(login);
            if (user != null)
            {
                user.IsAdmin = true;
                SaveUsers();
            }
        }

    }
}
