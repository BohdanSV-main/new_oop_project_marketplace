using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Marketplace
{
    public partial class ProductItemControl : UserControl
    {
        public string ProductName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public string ProductPrice
        {
            get => lblPrice.Text;
            set => lblPrice.Text = "Ціна: " + value + " грн";
        }

        public string ProductDescription
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }

        public Image ProductImage
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public string ProductId
        {
            get => lblId.Text;
            set => lblId.Text = "ID: " + value;
        }

        public ProductItemControl()
        {
            InitializeComponent();
        }
        private Label lblName;
        private Label lblPrice;
        private Label lblDescription;
        private Label lblId;
        private Button addToCartButton;
        private PictureBox pictureBox;
        private ShoppingCartManager _shoppingCartManager;
        public event EventHandler ProductAddedToCart;

        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            lblName = new Label();
            lblPrice = new Label();
            lblDescription = new Label();
            lblId = new Label();
            addToCartButton = new Button();
            ((ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(0, 28);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(244, 132);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(4, 163);
            lblName.Name = "lblName";
            lblName.Size = new Size(36, 21);
            lblName.TabIndex = 2;
            lblName.Text = "Text";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F);
            lblPrice.Location = new Point(4, 203);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(44, 21);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price";
            lblPrice.Click += lblPrice_Click;
            // 
            // lblDescription
            // 
            lblDescription.AutoEllipsis = true;
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(4, 235);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(3, 4);
            lblId.Name = "lblId";
            lblId.Size = new Size(25, 21);
            lblId.TabIndex = 5;
            lblId.Text = "ID";
            // 
            // addToCartButton
            // 
            addToCartButton.BackColor = Color.FromArgb(128, 255, 128);
            addToCartButton.BackgroundImage = new_oop_marketplace.Properties.Resources.shopping_cart;
            addToCartButton.BackgroundImageLayout = ImageLayout.Stretch;
            addToCartButton.Location = new Point(220, 2);
            addToCartButton.Name = "addToCartButton";
            addToCartButton.Size = new Size(24, 23);
            addToCartButton.TabIndex = 6;
            addToCartButton.UseVisualStyleBackColor = false;
            addToCartButton.Click += addToCartButton_Click;
            // 
            // ProductItemControl
            // 
            BackColor = Color.LightGray;
            Controls.Add(addToCartButton);
            Controls.Add(lblId);
            Controls.Add(lblDescription);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(pictureBox);
            DoubleBuffered = true;
            ForeColor = Color.Black;
            Margin = new Padding(15);
            Name = "ProductItemControl";
            Size = new Size(254, 281);
            ((ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        public void SetCartManager(ShoppingCartManager cartManager)
        {
            _shoppingCartManager = cartManager;
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null || SessionManager.CurrentUser.IsAdmin) return;

            if (_shoppingCartManager == null)
            {
                MessageBox.Show("Кошик не ініціалізований");
                return;
            }

            Product product = new Product(
                int.Parse(ProductId.Replace("ID: ", "")),
                ProductName,
                ProductPrice.Replace("Ціна: ", "").Replace(" грн", ""),
                ProductDescription,
                null // Якщо немає шляху до картинки
            );

            _shoppingCartManager.AddToCart(product);
            MessageBox.Show("Товар додано в корзину");
            ProductAddedToCart?.Invoke(this, EventArgs.Empty);
        }
    }
}
