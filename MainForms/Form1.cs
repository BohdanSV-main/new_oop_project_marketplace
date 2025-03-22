using Marketplace;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace new_oop_marketplace
{
    public partial class Form1 : Form
    {
        private ProductManager _productManager;
        private UserManager _userManager;
        private ProductRepository _productRepository = new ProductRepository();

        public Form1()
        {
            InitializeComponent();
            _productManager = new ProductManager(_productRepository, flowLayoutPanelProducts);
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
                    _productRepository.AddProduct(addProductForm.NewProduct);
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
            RemoveProductForm removeForm = new RemoveProductForm(_productRepository);
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
            LoginForm loginForm = new LoginForm(new UserRepository());
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

    }
}
