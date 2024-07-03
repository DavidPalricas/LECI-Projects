namespace Abrigo_Final_BD
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            label1 = new Label();
            adicionar_registo = new Button();
            password_input = new TextBox();
            username_input = new TextBox();
            horario = new Label();
            login_button = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 13F);
            label1.Location = new Point(264, 21);
            label1.Margin = new Padding(4, 4, 4, 1);
            label1.Name = "label1";
            label1.Size = new Size(113, 19);
            label1.TabIndex = 184;
            label1.Text = "Username*";
            // 
            // adicionar_registo
            // 
            adicionar_registo.Location = new Point(395, 182);
            adicionar_registo.Name = "adicionar_registo";
            adicionar_registo.Size = new Size(159, 57);
            adicionar_registo.TabIndex = 183;
            adicionar_registo.Text = "Register";
            adicionar_registo.UseVisualStyleBackColor = true;
            adicionar_registo.Click += adicionar_registo_Click;
            // 
            // password_input
            // 
            password_input.Location = new Point(264, 111);
            password_input.Name = "password_input";
            password_input.PasswordChar = '*';
            password_input.Size = new Size(398, 23);
            password_input.TabIndex = 182;
            // 
            // username_input
            // 
            username_input.Location = new Point(264, 44);
            username_input.Name = "username_input";
            username_input.Size = new Size(398, 23);
            username_input.TabIndex = 181;
            // 
            // horario
            // 
            horario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            horario.BackColor = Color.Transparent;
            horario.Font = new Font("Verdana", 13F);
            horario.Location = new Point(264, 88);
            horario.Margin = new Padding(4, 4, 4, 1);
            horario.Name = "horario";
            horario.Size = new Size(113, 19);
            horario.TabIndex = 180;
            horario.Text = "Password*";
            // 
            // login_button
            // 
            login_button.Location = new Point(345, 269);
            login_button.Name = "login_button";
            login_button.Size = new Size(261, 29);
            login_button.TabIndex = 185;
            login_button.Text = "Login";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += login_button_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 9F);
            label2.Location = new Point(345, 246);
            label2.Margin = new Padding(4, 4, 4, 1);
            label2.Name = "label2";
            label2.Size = new Size(261, 19);
            label2.TabIndex = 186;
            label2.Text = "Caso já esteja registado...";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.abirgo_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(955, 605);
            Controls.Add(login_button);
            Controls.Add(label1);
            Controls.Add(password_input);
            Controls.Add(username_input);
            Controls.Add(horario);
            Controls.Add(label2);
            Controls.Add(adicionar_registo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label label1;
        private Button adicionar_registo;
        internal TextBox password_input;
        internal TextBox username_input;
        internal Label horario;
        private Button login_button;
        internal Label label2;
    }
}