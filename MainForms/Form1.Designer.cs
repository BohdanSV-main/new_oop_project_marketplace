namespace new_oop_marketplace
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            mainFrame = new TabControl();
            mainPage = new TabPage();
            comboBoxSort = new ComboBox();
            flowLayoutPanelProducts = new FlowLayoutPanel();
            addProductPage = new TabPage();
            btnOpenRemoveForm = new Button();
            addProduct = new Button();
            panel1 = new Panel();
            marketName = new Label();
            btnUser = new Button();
            userMenu = new ContextMenuStrip(components);
            menuItemLogout = new ToolStripMenuItem();
            mainFrame.SuspendLayout();
            mainPage.SuspendLayout();
            addProductPage.SuspendLayout();
            panel1.SuspendLayout();
            userMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainFrame
            // 
            mainFrame.Controls.Add(mainPage);
            mainFrame.Controls.Add(addProductPage);
            mainFrame.Location = new Point(12, 65);
            mainFrame.Name = "mainFrame";
            mainFrame.SelectedIndex = 0;
            mainFrame.Size = new Size(1421, 727);
            mainFrame.TabIndex = 0;
            mainFrame.SelectedIndexChanged += mainFrame_SelectedIndexChanged;
            // 
            // mainPage
            // 
            mainPage.BackColor = Color.FromArgb(224, 224, 224);
            mainPage.Controls.Add(comboBoxSort);
            mainPage.Controls.Add(flowLayoutPanelProducts);
            mainPage.Location = new Point(4, 24);
            mainPage.Name = "mainPage";
            mainPage.Padding = new Padding(3);
            mainPage.Size = new Size(1413, 699);
            mainPage.TabIndex = 0;
            mainPage.Text = "Головна сторінка";
            // 
            // comboBoxSort
            // 
            comboBoxSort.BackColor = Color.FromArgb(224, 224, 224);
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Items.AddRange(new object[] { "За назвою (А-Я)", "За назвою (Я-А)", "За ціною (зростання)", "За ціною (спадання)" });
            comboBoxSort.Location = new Point(32, 27);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(121, 23);
            comboBoxSort.TabIndex = 1;
            comboBoxSort.SelectedIndexChanged += comboBoxSort_SelectedIndexChanged;
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.Location = new Point(199, 30);
            flowLayoutPanelProducts.Margin = new Padding(10);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(1145, 671);
            flowLayoutPanelProducts.TabIndex = 0;
            flowLayoutPanelProducts.Paint += flowLayoutPanelProducts_Paint;
            // 
            // addProductPage
            // 
            addProductPage.BackColor = Color.FromArgb(224, 224, 224);
            addProductPage.Controls.Add(btnOpenRemoveForm);
            addProductPage.Controls.Add(addProduct);
            addProductPage.Location = new Point(4, 24);
            addProductPage.Name = "addProductPage";
            addProductPage.Padding = new Padding(3);
            addProductPage.Size = new Size(1413, 699);
            addProductPage.TabIndex = 1;
            addProductPage.Text = "Додати продукт";
            // 
            // btnOpenRemoveForm
            // 
            btnOpenRemoveForm.BackColor = Color.LightGray;
            btnOpenRemoveForm.Location = new Point(198, 24);
            btnOpenRemoveForm.Name = "btnOpenRemoveForm";
            btnOpenRemoveForm.Size = new Size(124, 61);
            btnOpenRemoveForm.TabIndex = 1;
            btnOpenRemoveForm.Text = "Видалити продукт";
            btnOpenRemoveForm.UseVisualStyleBackColor = false;
            btnOpenRemoveForm.Click += btnOpenRemoveForm_Click;
            // 
            // addProduct
            // 
            addProduct.BackColor = Color.LightGray;
            addProduct.Location = new Point(68, 24);
            addProduct.Name = "addProduct";
            addProduct.Size = new Size(124, 61);
            addProduct.TabIndex = 0;
            addProduct.Text = "Додати новий продукт";
            addProduct.UseVisualStyleBackColor = false;
            addProduct.Click += addProduct_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(marketName);
            panel1.Controls.Add(btnUser);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1445, 48);
            panel1.TabIndex = 1;
            // 
            // marketName
            // 
            marketName.AutoSize = true;
            marketName.Font = new Font("Segoe UI", 14F);
            marketName.ForeColor = SystemColors.ButtonHighlight;
            marketName.Location = new Point(12, 9);
            marketName.Name = "marketName";
            marketName.Size = new Size(116, 25);
            marketName.TabIndex = 0;
            marketName.Text = "Marketplace";
            marketName.Click += marketName_Click;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.White;
            btnUser.BackgroundImage = (Image)resources.GetObject("btnUser.BackgroundImage");
            btnUser.BackgroundImageLayout = ImageLayout.Stretch;
            btnUser.ContextMenuStrip = userMenu;
            btnUser.Location = new Point(1280, 3);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(43, 39);
            btnUser.TabIndex = 1;
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // userMenu
            // 
            userMenu.Items.AddRange(new ToolStripItem[] { menuItemLogout });
            userMenu.Name = "contextMenuStrip1";
            userMenu.Size = new Size(108, 26);
            userMenu.Text = "Вийти";
            // 
            // menuItemLogout
            // 
            menuItemLogout.Name = "menuItemLogout";
            menuItemLogout.Size = new Size(107, 22);
            menuItemLogout.Text = "Вийти";
            menuItemLogout.Click += menuItemLogout_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1445, 804);
            Controls.Add(panel1);
            Controls.Add(mainFrame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Sky Marketplace";
            Load += Form1_Load;
            mainFrame.ResumeLayout(false);
            mainPage.ResumeLayout(false);
            addProductPage.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            userMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainFrame;
        private TabPage mainPage;
        private TabPage addProductPage;
        private Button addProduct;
        private FlowLayoutPanel flowLayoutPanelProducts;
        private Panel panel1;
        private Label marketName;
        private Button btnOpenRemoveForm;
        private Button btnUser;
        private ContextMenuStrip userMenu;
        private ToolStripMenuItem menuItemLogout;
        private ComboBox comboBoxSort;
    }
}
