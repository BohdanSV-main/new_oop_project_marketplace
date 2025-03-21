using Marketplace;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace new_oop_marketplace
{
    public partial class Form1 : Form
    {
        private string currentUserName;
        private ProductRepository _productRepository;
        private List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            _productRepository = new ProductRepository();
            LoadProducts();
            HideTabsForUser();
        }

        private void HideTabsForUser()
        {
            UserRepository repo = new UserRepository();
            repo.MakeUserAdmin("admin");
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Помилка: користувач не знайдений!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!SessionManager.CurrentUser.IsAdmin)
            {
                if (mainFrame.TabPages.Contains(addProductPage))
                {
                    mainFrame.TabPages.Remove(addProductPage);
                }
            }
            else
            {
                if (!mainFrame.TabPages.Contains(addProductPage))
                {
                    mainFrame.TabPages.Add(addProductPage);
                }
            }
        }
        private void LoadProducts()
        {
            flowLayoutPanelProducts.Controls.Clear();

            foreach (var product in _productRepository.GetAllProducts())
            {
                AddProductToUI(product);
            }
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
                    AddProductToUI(addProductForm.NewProduct);
                }
            }
        }
        private void AddProductToUI(Product product)
        {
            ProductItemControl productItem = new ProductItemControl
            {
                ProductName = product.Name,
                ProductPrice = product.Price.ToString(),
                ProductDescription = product.Description
            };

            if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
            {
                productItem.ProductImage = Image.FromFile(product.ImagePath);
            }

            productItem.RemoveClicked += (sender, e) =>
            {
                _productRepository.RemoveProduct(product);
                flowLayoutPanelProducts.Controls.Remove(productItem);
            };

            flowLayoutPanelProducts.Controls.Add(productItem);
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
            removeForm.OnProductRemoved += ProductDeleted;
            removeForm.ShowDialog();
        }
        private void ProductDeleted(object sender, Product product)
        {
            LoadProducts();
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

        private void HideTabsForUser(User user)
        {
            if (!user.IsAdmin)
            {
                mainFrame.TabPages.Remove(addProductPage);
            }
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedItem == null) return;

            string selectedSort = comboBoxSort.SelectedItem.ToString();

            products = _productRepository.GetAllProducts();

            if (selectedSort == "За назвою (А-Я)")
            {
                products = products.OrderBy(p => p.Name).ToList();
            }
            else if (selectedSort == "За назвою (Я-А)")
            {
                products = products.OrderByDescending(p => p.Name).ToList();
            }
            else if (selectedSort == "За ціною (зростання)")
            {
                products = products.OrderBy(p => Convert.ToDecimal(p.Price)).ToList();
            }
            else if (selectedSort == "За ціною (спадання)")
            {
                products = products.OrderByDescending(p => Convert.ToDecimal(p.Price)).ToList();
            }

            UpdateProductList();
        }

        private void UpdateProductList()
        {
            flowLayoutPanelProducts.Controls.Clear();

            foreach (var product in products)
            {
                ProductItemControl productItem = new ProductItemControl
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductDescription = product.Description
                };

                if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                {
                    productItem.ProductImage = Image.FromFile(product.ImagePath);
                }

                productItem.Margin = new Padding(10);
                flowLayoutPanelProducts.Controls.Add(productItem);

                productItem.RemoveClicked += (sender, e) =>
                {
                    flowLayoutPanelProducts.Controls.Remove(productItem);
                };
            }
        }

    }
}
