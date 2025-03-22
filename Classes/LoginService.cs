using BCrypt.Net;
using Marketplace;
using System;
using System.Windows.Forms;

namespace new_oop_marketplace
{
    public class LoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public bool RegisterUser(string login, string password)
        {
            if (_userRepository.GetUserByLogin(login) != null)
            {
                MessageBox.Show("Такий користувач вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 13);
            bool isAdmin = login.ToLower() == "admin";

            _userRepository.AddUser(new User(login, hashedPassword, isAdmin));

            MessageBox.Show("Реєстрація успішна!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public bool LoginUser(string login, string password)
        {
            User user = _userRepository.GetUserByLogin(login);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                SessionManager.SetCurrentUser(user);
                MessageBox.Show($"Вітаємо, {user.Login}!", "Успішний вхід", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            MessageBox.Show("Невірний логін або пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
