﻿using System;
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
        private Label Quan;
        private NumericUpDown numericQuantity;
        private Button btnSave;

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            txtImagePath = new TextBox();
            pictureBoxPreview = new PictureBox();
            btnSelectImage = new Button();
            btnSave = new Button();
            Quan = new Label();
            numericQuantity = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 20);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Назва товару";
            txtName.Size = new Size(300, 23);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(20, 60);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Ціна (грн)";
            txtPrice.Size = new Size(300, 23);
            txtPrice.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 100);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Опис";
            txtDescription.Size = new Size(300, 60);
            txtDescription.TabIndex = 2;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(20, 180);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.ReadOnly = true;
            txtImagePath.Size = new Size(230, 23);
            txtImagePath.TabIndex = 3;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPreview.Location = new Point(20, 220);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(100, 100);
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.TabIndex = 5;
            pictureBoxPreview.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(260, 180);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(75, 23);
            btnSelectImage.TabIndex = 4;
            btnSelectImage.Text = "Обрати...";
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(20, 340);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Зберегти";
            btnSave.Click += btnSave_Click;
            // 
            // Quan
            // 
            Quan.AutoSize = true;
            Quan.Location = new Point(126, 225);
            Quan.Name = "Quan";
            Quan.Size = new Size(59, 15);
            Quan.TabIndex = 7;
            Quan.Text = "Кількість:";
            // 
            // numericQuantity
            // 
            numericQuantity.Location = new Point(191, 225);
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(120, 23);
            numericQuantity.TabIndex = 8;
            // 
            // AddProductForm
            // 
            ClientSize = new Size(334, 381);
            Controls.Add(numericQuantity);
            Controls.Add(Quan);
            Controls.Add(txtName);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtImagePath);
            Controls.Add(btnSelectImage);
            Controls.Add(pictureBoxPreview);
            Controls.Add(btnSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddProductForm";
            Text = "Додати товар";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
            int newId = Product.GenerateId();

            var product = new Product(
                newId,
                txtName.Text,
                txtPrice.Text,
                txtDescription.Text,
                txtImagePath.Text,
                (int)numericQuantity.Value
            );

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(product, null, null);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(product, context, results, true);

            if (!isValid)
            {
                string errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show(errors, "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NewProduct = product;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
