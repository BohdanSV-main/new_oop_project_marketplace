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
        public int Quantity
        {
            get
            {
                var text = lblQuantity.Text.Replace("Кількість: ", "");
                return int.TryParse(text, out var result) ? result : 0;
            }
            set => lblQuantity.Text = $"Кількість: {value}";
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
        private Label lblQuantity;
        private NumericUpDown numericQuantity;
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
            lblQuantity = new Label();
            numericQuantity = new NumericUpDown();
            ((ISupportInitialize)pictureBox).BeginInit();
            ((ISupportInitialize)numericQuantity).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(0, 28);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(277, 151);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(3, 182);
            lblName.Name = "lblName";
            lblName.Size = new Size(36, 21);
            lblName.TabIndex = 2;
            lblName.Text = "Text";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Segoe UI", 12F);
            lblPrice.Location = new Point(3, 222);
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
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Location = new Point(3, 254);
            lblDescription.MaximumSize = new Size(0, 250);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.BackColor = Color.Transparent;
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
            addToCartButton.Location = new Point(253, 3);
            addToCartButton.Name = "addToCartButton";
            addToCartButton.Size = new Size(24, 23);
            addToCartButton.TabIndex = 6;
            addToCartButton.UseVisualStyleBackColor = false;
            addToCartButton.Click += addToCartButton_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Location = new Point(137, 7);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(53, 15);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "Quantity";
            // 
            // numericQuantity
            // 
            numericQuantity.Location = new Point(219, 2);
            numericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(28, 23);
            numericQuantity.TabIndex = 8;
            numericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuantity.ValueChanged += numericQuantity_ValueChanged;
            // 
            // ProductItemControl
            // 
            BackColor = Color.LightGray;
            BackgroundImage = new_oop_marketplace.Properties.Resources.bg_productPic;
            Controls.Add(numericQuantity);
            Controls.Add(lblQuantity);
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
            Size = new Size(280, 300);
            Load += ProductItemControl_Load;
            ((ISupportInitialize)pictureBox).EndInit();
            ((ISupportInitialize)numericQuantity).EndInit();
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
            if (Quantity <= 0)
            {
                MessageBox.Show("Товар закінчився");
                return;
            }
            if (SessionManager.CurrentUser == null || SessionManager.CurrentUser.IsAdmin)
            {
                MessageBox.Show("Тільки покупець може купляти");
                return;
            }

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
                null,
                Quantity
            );

            int quantity = (int)numericQuantity.Value;
            MessageBox.Show($"Ви вибрали {quantity} шт.");
            _shoppingCartManager.AddToCart(product, quantity);
            ProductAddedToCart?.Invoke(this, EventArgs.Empty);

        }

        private void numericQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ProductItemControl_Load(object sender, EventArgs e)
        {

        }
    }

}
