﻿using System;
using System.Windows.Forms;
using BCrypt.Net;
using Marketplace;
using Microsoft.VisualBasic.ApplicationServices;

namespace new_oop_marketplace
{
    public partial class LoginForm : Form
    {
        private readonly LoginService _loginService;
        private Label lblLogin;
        private Label lblPassword;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnAction;
        private Button btnSwitch;
        private bool isRegisterMode = false;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private ShoppingCartManager _shoppingCartManager;

        public LoginForm(IUserRepository userRepository, IProductRepository productRepository, ShoppingCartManager shoppingCartManager)
        {
            InitializeComponent();
            _loginService = new LoginService(userRepository);
            _userRepository = userRepository;
            _productRepository = productRepository;
            _shoppingCartManager = shoppingCartManager;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lblLogin = new Label();
            lblPassword = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            btnAction = new Button();
            btnSwitch = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.BackColor = Color.White;
            lblLogin.Font = new Font("Segoe UI", 12F);
            lblLogin.Location = new Point(391, 146);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(52, 21);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логін:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.White;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(391, 196);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Пароль:";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(463, 146);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 23);
            txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(463, 194);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnAction
            // 
            btnAction.Font = new Font("Segoe UI", 12F);
            btnAction.Location = new Point(463, 286);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(189, 28);
            btnAction.TabIndex = 4;
            btnAction.Text = "Увійти";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // btnSwitch
            // 
            btnSwitch.BackColor = Color.White;
            btnSwitch.Location = new Point(619, 12);
            btnSwitch.Name = "btnSwitch";
            btnSwitch.Size = new Size(116, 23);
            btnSwitch.TabIndex = 5;
            btnSwitch.Text = "Зареєструватись";
            btnSwitch.UseVisualStyleBackColor = false;
            btnSwitch.Click += btnSwitch_Click;
            // 
            // LoginForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(758, 452);
            Controls.Add(btnSwitch);
            Controls.Add(btnAction);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            RightToLeft = RightToLeft.No;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            var loginModel = new Marketplace.User(
                0,
                txtLogin.Text.Trim(),
                txtPassword.Text.Trim(),
                false
            );

            var validationErrors = _loginService.ValidateLoginModel(loginModel);
            if (validationErrors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", validationErrors), "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = isRegisterMode
                ? _loginService.RegisterUser(loginModel.Login, loginModel.Password)
                : _loginService.LoginUser(loginModel.Login, loginModel.Password);

            if (success && !isRegisterMode)
            {
                this.Hide();
                using (Form1 mainForm = new Form1(_productRepository, _userRepository, _shoppingCartManager))
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            else if (success)
            {
                SwitchMode();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SwitchMode()
        {
            isRegisterMode = !isRegisterMode;
            btnAction.Text = isRegisterMode ? "Зареєструватися" : "Увійти";
            btnSwitch.Text = isRegisterMode ? "Увійти" : "Зареєструватися";
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            SwitchMode();
        }
    }
}
