using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Marketplace
{
    public partial class AddProductForm : Form
    {
        public Product NewProduct { get; private set; }

        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtImagePath;
        private PictureBox pictureBoxPreview;
        private Button btnSelectImage;
        private Button btnSave;

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtName = new TextBox();
            this.txtPrice = new TextBox();
            this.txtDescription = new TextBox();
            this.txtImagePath = new TextBox();
            this.pictureBoxPreview = new PictureBox();
            this.btnSelectImage = new Button();
            this.btnSave = new Button();

            this.SuspendLayout();

            this.txtName.PlaceholderText = "Назва товару";
            this.txtName.Location = new Point(20, 20);
            this.txtName.Width = 300;

            this.txtPrice.PlaceholderText = "Ціна (грн)";
            this.txtPrice.Location = new Point(20, 60);
            this.txtPrice.Width = 300;

            this.txtDescription.PlaceholderText = "Опис";
            this.txtDescription.Location = new Point(20, 100);
            this.txtDescription.Width = 300;
            this.txtDescription.Height = 60;
            this.txtDescription.Multiline = true;

            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Location = new Point(20, 180);
            this.txtImagePath.Width = 230;

            this.btnSelectImage.Text = "Обрати...";
            this.btnSelectImage.Location = new Point(260, 180);
            this.btnSelectImage.Click += new EventHandler(this.btnSelectImage_Click);

            this.pictureBoxPreview.Location = new Point(20, 220);
            this.pictureBoxPreview.Size = new Size(100, 100);
            this.pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.BorderStyle = BorderStyle.FixedSingle;

            this.btnSave.Text = "Зберегти";
            this.btnSave.Location = new Point(20, 340);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.btnSave);

            this.Text = "Додати товар";
            this.Size = new Size(350, 420);
            this.ResumeLayout(false);
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Зображення (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = openFileDialog.FileName;
                    pictureBoxPreview.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Заповніть всі обов'язкові поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewProduct = new Product(
                txtName.Text,
                txtPrice.Text,
                txtDescription.Text,
                txtImagePath.Text
            );

            this.DialogResult = DialogResult.OK; 
        }
    }
}
