using System;
using Marketplace;
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.DataAnnotations;

namespace Marketplace
{
    public class LoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<string> ValidateLoginModel(User model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var errors = new List<string>();

            if (!Validator.TryValidateObject(model, context, results, true))
            {
                foreach (var validationResult in results)
                {
                    errors.Add(validationResult.ErrorMessage);
                }
            }

            return errors;
        }

        public bool LoginUser(string login, string password)
        {
            var user = _userRepository.GetUserByLogin(login);

            if (user == null)
            {
                return false;
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return false;
            }

            SessionManager.SetCurrentUser(user);
            return true;
        }


        public bool RegisterUser(string login, string password)
        {
            if (_userRepository.GetUserByLogin(login) != null)
            {
                return false;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            int userId = _userRepository.GetNextUserId();

            var user = new User(userId, login, hashedPassword, false);
            _userRepository.Add(user);
            return true;
        }
    }
}