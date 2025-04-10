using Marketplace;

namespace new_oop_marketplace
{
    public partial class Form1 : Form
    {
        private ProductManager _productManager;
        private UserManager _userManager;
        private ProductRepository _productRepository;
        private UserRepository _userRepository;
        private ShoppingCartManager _shoppingCartManager;
        // Removed duplicate declaration of cartPanel
        // public Panel cartPanel;

        public Form1()
        {
            InitializeComponent();
            IDataStorage<Product> productStorage = new JsonStorage<Product>("products.json");
            IDataStorage<User> userStorage = new JsonStorage<User>("users.json");
            _productRepository = new ProductRepository(productStorage);
            _userRepository = new UserRepository(userStorage);

            var cartStorage = new JsonStorage<CartItem>("shopping_cart.json");
            var cartRepository = new ShoppingCartRepository(cartStorage);
            _shoppingCartManager = new ShoppingCartManager(cartRepository);

            _productManager = new ProductManager(_productRepository, flowLayoutPanelProducts, _shoppingCartManager);
            _userManager = new UserManager(mainFrame, addProductPage);

            _productManager.LoadProducts();
            _userManager.CheckUserAccess();
        }

        private void mainFrame_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            using (AddProductForm addProductForm = new AddProductForm())
            {
                if (addProductForm.ShowDialog() == DialogResult.OK)
                {
                    _productRepository.Add(addProductForm.NewProduct);
                    _productManager.AddProductToUI(addProductForm.NewProduct);
                }
            }
        }
        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void marketName_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenRemoveForm_Click(object sender, EventArgs e)
        {
            RemoveProductForm removeForm = new RemoveProductForm(_productRepository.GetStorage());
            removeForm.OnProductRemoved += (s, product) => _productManager.LoadProducts();
            removeForm.ShowDialog();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            userMenu.Show(btnUser, new Point(0, btnUser.Height));
        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();

            LoginForm loginForm = new LoginForm(_userRepository);

            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedItem != null)
            {
                _productManager.SortProducts(comboBoxSort.SelectedItem.ToString());
            }
        }

        public void cartPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public void DisplayCartItems(FlowLayoutPanel cartPanel)
        {
            cartPanel.Controls.Clear();

            var items = _shoppingCartManager.GetUserCart();

            foreach (var item in items)
            {
                Label label = new Label
                {
                    Text = $"{item.ProductName} - {item.ProductPrice} грн",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    Padding = new Padding(5),
                    Margin = new Padding(5),
                    BackColor = Color.WhiteSmoke
                };
                cartPanel.Controls.Add(label);
            }
        }

        public void UpdateCartUI()
        {
            DisplayCartItems(cartPanel);
        }
        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            _shoppingCartManager.ConfirmOrder();
            UpdateCartUI();
            MessageBox.Show("Замовлення підтверджено!");
        }
    }
}
