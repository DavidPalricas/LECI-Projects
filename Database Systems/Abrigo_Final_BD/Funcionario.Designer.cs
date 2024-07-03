namespace Abrigo_Final_BD
{
    partial class Funcionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Funcionario));
            nome_input = new TextBox();
            nome = new Label();
            mail = new Label();
            telefone = new Label();
            nif = new Label();
            endereco = new Label();
            horario = new Label();
            Label2 = new Label();
            Label1 = new Label();
            adicionar_funcionario = new Button();
            horario_input = new TextBox();
            endereco_input = new TextBox();
            mail_input = new TextBox();
            nif_input = new TextBox();
            telefone_input = new TextBox();
            voltar_atras = new Button();
            remover_funcionario = new Button();
            submit_button = new Button();
            num = new Label();
            num_input = new TextBox();
            SuspendLayout();
            // 
            // nome_input
            // 
            nome_input.Location = new Point(263, 124);
            nome_input.Margin = new Padding(3, 4, 3, 4);
            nome_input.Name = "nome_input";
            nome_input.Size = new Size(454, 27);
            nome_input.TabIndex = 172;
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(261, 89);
            nome.Margin = new Padding(5, 1, 5, 5);
            nome.Name = "nome";
            nome.Size = new Size(181, 25);
            nome.TabIndex = 157;
            nome.Text = "Nome do Funcionario*";
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mail.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            mail.Location = new Point(261, 193);
            mail.Margin = new Padding(5, 5, 5, 1);
            mail.Name = "mail";
            mail.Size = new Size(115, 25);
            mail.TabIndex = 155;
            mail.Text = "Email*";
            // 
            // telefone
            // 
            telefone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            telefone.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            telefone.Location = new Point(675, 193);
            telefone.Margin = new Padding(5, 5, 5, 1);
            telefone.Name = "telefone";
            telefone.Size = new Size(120, 25);
            telefone.TabIndex = 149;
            telefone.Text = "Telefone*";
            // 
            // nif
            // 
            nif.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nif.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nif.Location = new Point(457, 193);
            nif.Margin = new Padding(5, 5, 5, 1);
            nif.Name = "nif";
            nif.Size = new Size(96, 25);
            nif.TabIndex = 153;
            nif.Text = "NIF*";
            // 
            // endereco
            // 
            endereco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            endereco.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            endereco.Location = new Point(261, 309);
            endereco.Margin = new Padding(5, 5, 5, 1);
            endereco.Name = "endereco";
            endereco.Size = new Size(96, 25);
            endereco.TabIndex = 147;
            endereco.Text = "Endereço*";
            // 
            // horario
            // 
            horario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            horario.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            horario.Location = new Point(251, 414);
            horario.Margin = new Padding(5, 5, 5, 1);
            horario.Name = "horario";
            horario.Size = new Size(455, 25);
            horario.TabIndex = 145;
            horario.Text = "Horário (No formato hh:mm)*";
            // 
            // Label2
            // 
            Label2.Location = new Point(0, 0);
            Label2.Margin = new Padding(5, 0, 5, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(133, 35);
            Label2.TabIndex = 159;
            // 
            // Label1
            // 
            Label1.Location = new Point(0, 0);
            Label1.Margin = new Padding(5, 0, 5, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(133, 35);
            Label1.TabIndex = 160;
            // 
            // adicionar_funcionario
            // 
            adicionar_funcionario.Location = new Point(241, 175);
            adicionar_funcionario.Margin = new Padding(3, 4, 3, 4);
            adicionar_funcionario.Name = "adicionar_funcionario";
            adicionar_funcionario.Size = new Size(210, 125);
            adicionar_funcionario.TabIndex = 171;
            adicionar_funcionario.Text = "Adicionar Funcionário";
            adicionar_funcionario.UseVisualStyleBackColor = true;
            adicionar_funcionario.Click += adicionar_funcionario_Click;
            // 
            // horario_input
            // 
            horario_input.Location = new Point(251, 456);
            horario_input.Margin = new Padding(3, 4, 3, 4);
            horario_input.Name = "horario_input";
            horario_input.Size = new Size(454, 27);
            horario_input.TabIndex = 173;
            // 
            // endereco_input
            // 
            endereco_input.Location = new Point(251, 339);
            endereco_input.Margin = new Padding(3, 4, 3, 4);
            endereco_input.Name = "endereco_input";
            endereco_input.Size = new Size(454, 27);
            endereco_input.TabIndex = 174;
            // 
            // mail_input
            // 
            mail_input.Location = new Point(251, 243);
            mail_input.Margin = new Padding(3, 4, 3, 4);
            mail_input.Name = "mail_input";
            mail_input.Size = new Size(181, 27);
            mail_input.TabIndex = 175;
            // 
            // nif_input
            // 
            nif_input.Location = new Point(457, 243);
            nif_input.Margin = new Padding(3, 4, 3, 4);
            nif_input.Name = "nif_input";
            nif_input.Size = new Size(181, 27);
            nif_input.TabIndex = 176;
            // 
            // telefone_input
            // 
            telefone_input.Location = new Point(675, 243);
            telefone_input.Margin = new Padding(3, 4, 3, 4);
            telefone_input.Name = "telefone_input";
            telefone_input.Size = new Size(181, 27);
            telefone_input.TabIndex = 177;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(14, 16);
            voltar_atras.Margin = new Padding(3, 4, 3, 4);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(130, 32);
            voltar_atras.TabIndex = 192;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // remover_funcionario
            // 
            remover_funcionario.Location = new Point(575, 175);
            remover_funcionario.Margin = new Padding(3, 4, 3, 4);
            remover_funcionario.Name = "remover_funcionario";
            remover_funcionario.Size = new Size(210, 125);
            remover_funcionario.TabIndex = 193;
            remover_funcionario.Text = "Remover Funcionário";
            remover_funcionario.UseVisualStyleBackColor = true;
            remover_funcionario.Click += remover_funcionario_Click;
            // 
            // submit_button
            // 
            submit_button.Location = new Point(376, 531);
            submit_button.Margin = new Padding(3, 4, 3, 4);
            submit_button.Name = "submit_button";
            submit_button.Size = new Size(210, 125);
            submit_button.TabIndex = 194;
            submit_button.UseVisualStyleBackColor = true;
            submit_button.Click += submit_button_Click;
            // 
            // num
            // 
            num.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            num.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            num.Location = new Point(397, 193);
            num.Margin = new Padding(5, 5, 5, 1);
            num.Name = "num";
            num.Size = new Size(207, 25);
            num.TabIndex = 195;
            num.Text = "Número do Funcionário*";
            // 
            // num_input
            // 
            num_input.Location = new Point(405, 233);
            num_input.Margin = new Padding(3, 4, 3, 4);
            num_input.Name = "num_input";
            num_input.Size = new Size(181, 27);
            num_input.TabIndex = 196;
            // 
            // Funcionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1067, 692);
            Controls.Add(num_input);
            Controls.Add(num);
            Controls.Add(submit_button);
            Controls.Add(remover_funcionario);
            Controls.Add(voltar_atras);
            Controls.Add(telefone_input);
            Controls.Add(nif_input);
            Controls.Add(mail_input);
            Controls.Add(endereco_input);
            Controls.Add(horario_input);
            Controls.Add(adicionar_funcionario);
            Controls.Add(nome_input);
            Controls.Add(nome);
            Controls.Add(mail);
            Controls.Add(telefone);
            Controls.Add(nif);
            Controls.Add(endereco);
            Controls.Add(horario);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "Funcionario";
            Text = "Funcionário";
            Load += Funcionario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.TextBox nome_input;
        internal System.Windows.Forms.Label nome;
        internal System.Windows.Forms.Label mail;
        internal System.Windows.Forms.Label telefone;
        internal System.Windows.Forms.Label nif;
        internal System.Windows.Forms.Label endereco;
        internal System.Windows.Forms.Label horario;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button adicionar_funcionario;
        internal TextBox horario_input;
        internal TextBox endereco_input;
        internal TextBox mail_input;
        internal TextBox nif_input;
        internal TextBox telefone_input;
        private Button voltar_atras;
        private Button remover_funcionario;
        private Button submit_button;
        internal Label num;
        internal TextBox num_input;
    }
}