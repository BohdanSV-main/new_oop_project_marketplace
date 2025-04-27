using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Marketplace
{
    public partial class RemoveProductForm : Form
    {
        private readonly IDataStorage<Product> _storage;
        public event EventHandler<Product> OnProductRemoved;

        public RemoveProductForm(IDataStorage<Product> storage)
        {
            InitializeComponent();
            _storage = storage;
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RemoveProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Видалення товару";
            ResumeLayout(false);
        }

        private void LoadProductNames()
        {
            cmbProducts.Items.Clear();
            List<Product> products = _storage.GetAll(); // Отримуємо всі продукти з бази даних
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

            // Отримуємо назву вибраного продукту
            string selectedProductName = cmbProducts.SelectedItem.ToString();

            // Шукаємо продукт за назвою в репозиторії
            Product productToRemove = _storage.GetAll().FirstOrDefault(p => p.Name == selectedProductName);

            if (productToRemove != null)
            {
                // Видаляємо продукт з бази даних через MySqlProductRepository
                _storage.Delete(productToRemove.Id);

                // Викликаємо подію, щоб оновити інтерфейс або інші форми
                OnProductRemoved?.Invoke(this, productToRemove);

                // Сповіщаємо користувача
                MessageBox.Show($"Товар \"{selectedProductName}\" видалено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Оновлюємо список продуктів у ComboBox
                LoadProductNames();
            }
            else
            {
                // Якщо продукт не знайдено, виводимо повідомлення
                MessageBox.Show("Товар не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private ComboBox cmbProducts;
        private Button btnRemove;
    }
}
