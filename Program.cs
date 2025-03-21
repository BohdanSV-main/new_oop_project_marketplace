using System;
using System.Windows.Forms;
using new_oop_marketplace;

namespace Marketplace
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IUserRepository userRepository = new UserRepository();
            LoginForm loginForm = new LoginForm(userRepository);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1()); // Запускаємо головне вікно після успішного входу
            }
        }
    }
}
