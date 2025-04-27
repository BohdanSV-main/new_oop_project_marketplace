using Marketplace;

namespace new_oop_marketplace
{
    public partial class Form1 : Form
    {
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private ShoppingCartManager _shoppingCartManager;

        private ProductManager _productManager;
        private UserManager _userManager;

        public Form1(IProductRepository productRepository, IUserRepository userRepository, ShoppingCartManager shoppingCartManager)
        {
            InitializeComponent();

            _productRepository = productRepository;
            _userRepository = userRepository;
            _shoppingCartManager = shoppingCartManager;

            _productManager = new ProductManager(_productRepository, flowLayoutPanelProducts, _shoppingCartManager);
            _userManager = new UserManager(mainFrame, addProductPage, pageShoppingList);

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

            LoginForm loginForm = new LoginForm(_userRepository, _productRepository, _shoppingCartManager);

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
                    Text = $"{item.ProductName} - {item.ProductPrice} грн х {item.Quantity} шт.",
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
            if (SessionManager.CurrentUser == null || SessionManager.CurrentUser.IsAdmin)
            {
                MessageBox.Show("Тільки покупець може підтверджувати замовлення");
                return;
            }
            if (_shoppingCartManager.GetUserCart().Count == 0)
            {
                MessageBox.Show("Ваш кошик порожній!");
                return;
            }
            _shoppingCartManager.ConfirmOrder();
            UpdateCartUI();
            _productManager.LoadProducts();
            MessageBox.Show("Замовлення підтверджено!");
        }
    }
}
