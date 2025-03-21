using System;
using System.Windows.Forms;
using BCrypt.Net;
using Marketplace;

namespace new_oop_marketplace
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository _userRepository;
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
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
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
            lblLogin.Location = new Point(419, 146);
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
            lblPassword.Location = new Point(419, 196);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Пароль:";
            lblPassword.Click += lblPassword_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(496, 144);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 23);
            txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(496, 194);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnAction
            // 
            btnAction.Font = new Font("Segoe UI", 12F);
            btnAction.Location = new Point(463, 285);
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

            if (isRegisterMode)
            {
                RegisterUser(login, password);
            }
            else
            {
                LoginUser(login, password);
            }
        }
        private void RegisterUser(string login, string password)
        {
            if (_userRepository.GetUserByLogin(login) != null)
            {
                MessageBox.Show("Такий користувач вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            bool isAdmin = false; 

            if (login.ToLower() == "admin")
            {
                isAdmin = true;
            }

            _userRepository.AddUser(new User(login, hashedPassword, isAdmin));

            MessageBox.Show("Реєстрація успішна!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SwitchMode();
        }


        private void LoginUser(string login, string password)
        {
            User user = _userRepository.GetUserByLogin(login);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                SessionManager.SetCurrentUser(user); 

                MessageBox.Show($"Вітаємо, {user.Login}!", "Успішний вхід", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 mainForm = new Form1();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
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

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
    }
}