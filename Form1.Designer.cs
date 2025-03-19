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
            mainFrame = new TabControl();
            mainPage = new TabPage();
            flowLayoutPanelProducts = new FlowLayoutPanel();
            addProductPage = new TabPage();
            addProduct = new Button();
            panel1 = new Panel();
            marketName = new Label();
            mainFrame.SuspendLayout();
            mainPage.SuspendLayout();
            addProductPage.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainFrame
            // 
            mainFrame.Controls.Add(mainPage);
            mainFrame.Controls.Add(addProductPage);
            mainFrame.Location = new Point(22, 42);
            mainFrame.Name = "mainFrame";
            mainFrame.SelectedIndex = 0;
            mainFrame.Size = new Size(1371, 750);
            mainFrame.TabIndex = 0;
            mainFrame.SelectedIndexChanged += mainFrame_SelectedIndexChanged;
            // 
            // mainPage
            // 
            mainPage.Controls.Add(flowLayoutPanelProducts);
            mainPage.Location = new Point(4, 24);
            mainPage.Name = "mainPage";
            mainPage.Padding = new Padding(3);
            mainPage.Size = new Size(1363, 722);
            mainPage.TabIndex = 0;
            mainPage.Text = "Головна сторінка";
            mainPage.UseVisualStyleBackColor = true;
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
            addProductPage.Controls.Add(addProduct);
            addProductPage.Location = new Point(4, 24);
            addProductPage.Name = "addProductPage";
            addProductPage.Padding = new Padding(3);
            addProductPage.Size = new Size(1363, 722);
            addProductPage.TabIndex = 1;
            addProductPage.Text = "Додати продукт";
            addProductPage.UseVisualStyleBackColor = true;
            // 
            // addProduct
            // 
            addProduct.Location = new Point(68, 24);
            addProduct.Name = "addProduct";
            addProduct.Size = new Size(124, 61);
            addProduct.TabIndex = 0;
            addProduct.Text = "Додати новий продукт";
            addProduct.UseVisualStyleBackColor = true;
            addProduct.Click += addProduct_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(marketName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1405, 36);
            panel1.TabIndex = 1;
            // 
            // marketName
            // 
            marketName.AutoSize = true;
            marketName.Font = new Font("Segoe UI", 14F);
            marketName.ForeColor = SystemColors.ButtonHighlight;
            marketName.Location = new Point(12, 0);
            marketName.Name = "marketName";
            marketName.Size = new Size(116, 25);
            marketName.TabIndex = 0;
            marketName.Text = "Marketplace";
            marketName.Click += marketName_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1405, 804);
            Controls.Add(panel1);
            Controls.Add(mainFrame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            mainFrame.ResumeLayout(false);
            mainPage.ResumeLayout(false);
            addProductPage.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}
