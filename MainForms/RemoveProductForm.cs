using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Marketplace
{
    public partial class RemoveProductForm : Form
    {
        private readonly IProductRepository _repository;
        public event EventHandler<Product> OnProductRemoved; // Подія для видалення

        public RemoveProductForm(IProductRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            LoadProductNames();
        }

        private void InitializeComponent()
        {
            cmbProducts = new ComboBox();
            btnRemove = new Button();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.Location = new Point(-1, 12);
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
            Name = "RemoveProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Видалення товару";
            ResumeLayout(false);
        }

        private void LoadProductNames()
        {
            ComboBox cmbProducts = this.Controls.Find("cmbProducts", true).FirstOrDefault() as ComboBox;
            if (cmbProducts == null) return;

            cmbProducts.Items.Clear();
            List<Product> products = _repository.GetAllProducts();
            foreach (var product in products)
            {
                cmbProducts.Items.Add(product.Name);
            }

            if (cmbProducts.Items.Count > 0)
            {
                cmbProducts.SelectedIndex = 0; // Вибрати перший товар
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            ComboBox cmbProducts = this.Controls.Find("cmbProducts", true).FirstOrDefault() as ComboBox;
            if (cmbProducts == null || cmbProducts.SelectedItem == null) return;

            string selectedProductName = cmbProducts.SelectedItem.ToString();
            Product productToRemove = _repository.GetAllProducts().FirstOrDefault(p => p.Name == selectedProductName);

            if (productToRemove != null)
            {
                _repository.RemoveProduct(productToRemove);
                OnProductRemoved?.Invoke(this, productToRemove); // Викликаємо подію для оновлення UI
                MessageBox.Show($"Товар \"{selectedProductName}\" видалено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductNames(); // Оновити список
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
