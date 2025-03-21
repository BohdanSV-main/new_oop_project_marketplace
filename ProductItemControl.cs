//using System;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;

//namespace Marketplace
//{
//    public class ProductItemControl : UserControl
//    {
//        private Label lblName;
//        private Label lblPrice;
//        private Label lblDescription;
//        private PictureBox pictureBox;
//        private Button btnRemove;

//        public string ProductName { get => lblName.Text; set => lblName.Text = value; }


//        public string ProductPrice { get => lblPrice.Text; set => lblPrice.Text = "Ціна: " + value + " грн"; }


//        public string ProductDescription { get => lblDescription.Text; set => lblDescription.Text = value; }


//        public Image ProductImage { get => pictureBox.Image; set => pictureBox.Image = value; }

//        public event EventHandler RemoveClicked;

//        public ProductItemControl()
//        {
//            InitializeComponent();
//        }

//        private void InitializeComponent()
//        {
//            lblName = new Label();
//            lblPrice = new Label();
//            lblDescription = new Label();
//            pictureBox = new PictureBox();
//            btnRemove = new Button();

//            this.Size = new Size(250, 120);
//            this.BorderStyle = BorderStyle.FixedSingle;

//            lblName.AutoSize = true;
//            lblName.Font = new Font("Arial", 10, FontStyle.Bold);
//            lblName.Location = new Point(110, 10);

//            lblPrice.AutoSize = true;
//            lblPrice.Font = new Font("Arial", 9);
//            lblPrice.Location = new Point(110, 35);

//            lblDescription.AutoSize = true;
//            lblDescription.Font = new Font("Arial", 8);
//            lblDescription.Size = new Size(130, 40);
//            lblDescription.Location = new Point(110, 55);

//            pictureBox.Size = new Size(90, 90);
//            pictureBox.Location = new Point(10, 10);
//            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

//            btnRemove.Text = "×";
//            btnRemove.Size = new Size(25, 25);
//            btnRemove.Location = new Point(220, 5);
//            btnRemove.Click += (sender, e) => RemoveClicked?.Invoke(this, EventArgs.Empty);

//            this.Controls.Add(lblName);
//            this.Controls.Add(lblPrice);
//            this.Controls.Add(lblDescription);
//            this.Controls.Add(pictureBox);
//            this.Controls.Add(btnRemove);
//        }
//    }
//}
