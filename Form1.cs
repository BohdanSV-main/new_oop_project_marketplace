using Marketplace;

namespace new_oop_marketplace
{
    public partial class Form1 : Form
    {
        private ProductRepository _productRepository;
        public Form1()
        {
            InitializeComponent();
            _productRepository = new ProductRepository();
            LoadProducts();
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
            if (product == null) return;

            ProductItemControl productItem = new ProductItemControl
            


            {

                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductDescription = product.Description
            };

            if (!string.IsNullOrEmpty(product.ImagePath) && System.IO.File.Exists(product.ImagePath))
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

        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void marketName_Click(object sender, EventArgs e)
        {

        }
    }

}
