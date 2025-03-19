namespace new_oop_marketplace
{
    public partial class RoleSelectorForm : Form
    {
        public RoleSelectorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Question_text = new Label();
            SuspendLayout();



            Question_text.AutoSize = true;
            Question_text.Location = new Point(74, 49);
            Question_text.Name = "Question_text";
            Question_text.Size = new Size(0, 15);
            Question_text.TabIndex = 0;



            ClientSize = new Size(284, 261);
            Controls.Add(Question_text);
            Name = "RoleSelectorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label Question_text;
    }
}
