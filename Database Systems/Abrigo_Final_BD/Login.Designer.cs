namespace Abrigo_Final_BD
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            password_input = new TextBox();
            username_input = new TextBox();
            horario = new Label();
            login_button = new Button();
            label1 = new Label();
            register_button = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // password_input
            // 
            password_input.Location = new Point(307, 147);
            password_input.Margin = new Padding(3, 4, 3, 4);
            password_input.Name = "password_input";
            password_input.PasswordChar = '*';
            password_input.Size = new Size(454, 27);
            password_input.TabIndex = 177;
            // 
            // username_input
            // 
            username_input.Location = new Point(307, 57);
            username_input.Margin = new Padding(3, 4, 3, 4);
            username_input.Name = "username_input";
            username_input.Size = new Size(454, 27);
            username_input.TabIndex = 176;
            // 
            // horario
            // 
            horario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            horario.BackColor = Color.Transparent;
            horario.Font = new Font("Verdana", 13F);
            horario.Location = new Point(307, 116);
            horario.Margin = new Padding(5, 5, 5, 1);
            horario.Name = "horario";
            horario.Size = new Size(129, 25);
            horario.TabIndex = 174;
            horario.Text = "Password*";
            // 
            // login_button
            // 
            login_button.Location = new Point(455, 235);
            login_button.Margin = new Padding(3, 4, 3, 4);
            login_button.Name = "login_button";
            login_button.Size = new Size(182, 76);
            login_button.TabIndex = 178;
            login_button.Text = "Login";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += button_login_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 13F);
            label1.Location = new Point(307, 27);
            label1.Margin = new Padding(5, 5, 5, 1);
            label1.Name = "label1";
            label1.Size = new Size(129, 25);
            label1.TabIndex = 179;
            label1.Text = "Username*";
            // 
            // register_button
            // 
            register_button.Location = new Point(395, 351);
            register_button.Margin = new Padding(3, 4, 3, 4);
            register_button.Name = "register_button";
            register_button.Size = new Size(298, 39);
            register_button.TabIndex = 187;
            register_button.Text = "Register";
            register_button.UseVisualStyleBackColor = true;
            register_button.Click += register_button_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 9F);
            label2.Location = new Point(395, 320);
            label2.Margin = new Padding(5, 5, 5, 1);
            label2.Name = "label2";
            label2.Size = new Size(298, 25);
            label2.TabIndex = 188;
            label2.Text = "Caso não esteja registado...";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.abirgo_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1091, 807);
            Controls.Add(register_button);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(login_button);
            Controls.Add(password_input);
            Controls.Add(username_input);
            Controls.Add(horario);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal TextBox password_input;
        internal TextBox username_input;
        internal Label horario;
        private Button login_button;
        internal Label label1;
        private Button register_button;
        internal Label label2;
    }
}