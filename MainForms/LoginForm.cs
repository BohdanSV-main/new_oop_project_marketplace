using System;
using System.Windows.Forms;
using BCrypt.Net;
using Marketplace;

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
        public LoginForm(IUserRepository userRepository)
        {
            InitializeComponent();
            _loginService = new LoginService(userRepository);
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
            lblLogin.Click += lblLogin_Click;
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
            lblPassword.Click += lblPassword_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(463, 146);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 23);
            txtLogin.TabIndex = 2;
            txtLogin.TextChanged += txtLogin_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(463, 194);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 3;
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
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = isRegisterMode ?
                _loginService.RegisterUser(login, password) :
                _loginService.LoginUser(login, password);

            if (success && !isRegisterMode)
            {
                this.Hide();
                using (Form1 mainForm = new Form1())
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            else if (success)
            {
                SwitchMode();
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

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }
    }
}