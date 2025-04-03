using System.Text.Json.Serialization;
namespace Marketplace
{
    public class User : IIdentifiable
    {
        public int Id { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("isAdmin")]
        public bool IsAdmin { get; set; }

        [JsonConstructor]
        public User(int id, string login, string password, bool isAdmin)
        {
            Id = id;
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
