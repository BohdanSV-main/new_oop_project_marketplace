using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Marketplace
{
    public class User : IIdentifiable
    {
        public int Id { get; set; }

        [JsonPropertyName("login"), Required(ErrorMessage = "Логін є обов'язковим"), StringLength(20, MinimumLength = 3, ErrorMessage = "Логін має бути від 3 до 20 символів"), RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Логін може містити лише латинські літери, цифри та _")]
        public string Login { get; set; }

        [JsonPropertyName("password"), RegularExpression("^[a-zA-Z0-9_]+$"), StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль має бути щонайменше 6 символів")]
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
