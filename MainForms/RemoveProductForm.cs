using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Marketplace
{
    public partial class RemoveProductForm : Form
    {
        private readonly IProductRepository _productRepository;
        public event EventHandler<Product> OnProductRemoved;

        public RemoveProductForm(IProductRepository productRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;
            LoadProductNames();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveProductForm));
            cmbProducts = new ComboBox();
            btnRemove = new Button();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.Location = new Point(12, 12);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(121, 23);
            cmbProducts.TabIndex = 1;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(197, 12);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Видалити";
            btnRemove.Click += BtnRemove_Click;
            // 
            // RemoveProductForm
            // 
            ClientSize = new Size(284, 111);
            Controls.Add(cmbProducts);
            Controls.Add(btnRemove);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RemoveProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Видалення товару";
            ResumeLayout(false);
        }

        private void LoadProductNames()
        {
            cmbProducts.Items.Clear();
            List<Product> products = _productRepository.GetAll();
            if (products == null)
            {
                MessageBox.Show("No products found or failed to load products.");
                return;
            }
            foreach (var product in products)
            {
                cmbProducts.Items.Add(product.Name);
            }

            if (cmbProducts.Items.Count > 0)
            {
                cmbProducts.SelectedIndex = 0; // Вибір першого продукту
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            ComboBox cmbProducts = this.Controls.Find("cmbProducts", true).FirstOrDefault() as ComboBox;
            if (cmbProducts == null || cmbProducts.SelectedItem == null) return;

            string selectedProductName = cmbProducts.SelectedItem.ToString();

            Product productToRemove = _productRepository.GetAll().FirstOrDefault(p => p.Name == selectedProductName);

            if (productToRemove != null)
            {
                _productRepository.Delete(productToRemove.Id);

                OnProductRemoved?.Invoke(this, productToRemove);

                MessageBox.Show($"Товар \"{selectedProductName}\" видалено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProductNames();
            }
            else
            {
                MessageBox.Show("Товар не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private ComboBox cmbProducts;
        private Button btnRemove;
    }
}
