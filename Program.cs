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

            var connectionString = "server=localhost;port=3306;database=marketplacebd;user=root;password=root;";

            IProductRepository productRepository = new MySqlProductRepository(connectionString);
            IUserRepository userRepository = new MySqlUserRepository(connectionString);

            IDataStorage<CartItem> cartStorage = new InMemoryStorage<CartItem>();
            var cartRepository = new ShoppingCartRepository(cartStorage);
            var shoppingCartManager = new ShoppingCartManager(cartRepository, productRepository);

            LoginForm loginForm = new LoginForm(userRepository, productRepository, shoppingCartManager);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1(productRepository, userRepository, shoppingCartManager));
            }
        }
    }
}
