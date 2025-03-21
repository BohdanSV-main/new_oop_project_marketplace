using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Marketplace
{
    public partial class ProductItemControl : UserControl
    {
        public event EventHandler RemoveClicked;

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

        public ProductItemControl()
        {
            InitializeComponent();
        }

        private Button btnRemove;
        private Label lblName;
        private Label lblPrice;
        private Label lblDescription;
        private PictureBox pictureBox;

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ProductItemControl));
            btnRemove = new Button();
            pictureBox = new PictureBox();
            lblName = new Label();
            lblPrice = new Label();
            lblDescription = new Label();
            ((ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Tomato;
            btnRemove.BackgroundImage = (Image)resources.GetObject("btnRemove.BackgroundImage");
            btnRemove.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemove.Location = new Point(216, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(31, 29);
            btnRemove.TabIndex = 0;
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click_1;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(3, 4);
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
            lblName.Location = new Point(7, 139);
            lblName.Name = "lblName";
            lblName.Size = new Size(36, 21);
            lblName.TabIndex = 2;
            lblName.Text = "Text";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F);
            lblPrice.Location = new Point(7, 179);
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
            lblDescription.Location = new Point(7, 211);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // ProductItemControl
            // 
            BackColor = Color.LightGray;
            Controls.Add(lblDescription);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(btnRemove);
            Controls.Add(pictureBox);
            DoubleBuffered = true;
            ForeColor = Color.Black;
            Name = "ProductItemControl";
            Size = new Size(252, 252);
            ((ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
                RemoveClicked?.Invoke(this, EventArgs.Empty);

        }
    }
}
