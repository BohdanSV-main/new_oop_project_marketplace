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

            JsonStorage<Product> productStorage = new JsonStorage<Product>("products.json");
            JsonStorage<User> userStorage = new JsonStorage<User>("users.json");
            IDataStorage<CartItem> cartStorage = new JsonStorage<CartItem>("cart.json");
            var shoppingCartRepository = new ShoppingCartRepository(cartStorage);


            IProductRepository productRepository = new ProductRepository(productStorage);
            IUserRepository userRepository = new UserRepository(userStorage);

            LoginForm loginForm = new LoginForm(userRepository);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }
    }
}
