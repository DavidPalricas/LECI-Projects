namespace Abrigo_Final_BD
{
    partial class Doador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doador));
            nome = new Label();
            mail = new Label();
            telefone = new Label();
            nif = new Label();
            endereco = new Label();
            Label2 = new Label();
            Label1 = new Label();
            adicionar_doador = new Button();
            nome_input = new TextBox();
            label3 = new Label();
            endereco_input = new TextBox();
            mail_input = new TextBox();
            nif_input = new TextBox();
            telefone_input = new TextBox();
            voltar_atras = new Button();
            SuspendLayout();
            // 
            // nome
            // 
            nome.Location = new Point(0, 0);
            nome.Name = "nome";
            nome.Size = new Size(100, 23);
            nome.TabIndex = 175;
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mail.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            mail.Location = new Point(242, 203);
            mail.Margin = new Padding(4, 4, 4, 1);
            mail.Name = "mail";
            mail.Size = new Size(101, 19);
            mail.TabIndex = 155;
            mail.Text = "Email";
            // 
            // telefone
            // 
            telefone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            telefone.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            telefone.Location = new Point(607, 203);
            telefone.Margin = new Padding(4, 4, 4, 1);
            telefone.Name = "telefone";
            telefone.Size = new Size(105, 19);
            telefone.TabIndex = 149;
            telefone.Text = "Telefone";
            // 
            // nif
            // 
            nif.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nif.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nif.Location = new Point(418, 203);
            nif.Margin = new Padding(4, 4, 4, 1);
            nif.Name = "nif";
            nif.Size = new Size(84, 19);
            nif.TabIndex = 153;
            nif.Text = "NIF";
            // 
            // endereco
            // 
            endereco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            endereco.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            endereco.Location = new Point(240, 138);
            endereco.Margin = new Padding(4, 4, 4, 1);
            endereco.Name = "endereco";
            endereco.Size = new Size(84, 19);
            endereco.TabIndex = 147;
            endereco.Text = "Endereço*";
            // 
            // Label2
            // 
            Label2.Location = new Point(0, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(88, 22);
            Label2.TabIndex = 172;
            // 
            // Label1
            // 
            Label1.Location = new Point(0, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(88, 22);
            Label1.TabIndex = 173;
            // 
            // adicionar_doador
            // 
            adicionar_doador.Location = new Point(384, 325);
            adicionar_doador.Name = "adicionar_doador";
            adicionar_doador.Size = new Size(184, 94);
            adicionar_doador.TabIndex = 171;
            adicionar_doador.Text = "Adicionar Doador";
            adicionar_doador.UseVisualStyleBackColor = true;
            adicionar_doador.Click += adicionar_doador_Click;
            // 
            // nome_input
            // 
            nome_input.Location = new Point(242, 95);
            nome_input.Name = "nome_input";
            nome_input.Size = new Size(398, 23);
            nome_input.TabIndex = 176;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label3.Location = new Point(242, 72);
            label3.Margin = new Padding(4, 4, 4, 1);
            label3.Name = "label3";
            label3.Size = new Size(124, 19);
            label3.TabIndex = 177;
            label3.Text = "Nome do Doador*";
            // 
            // endereco_input
            // 
            endereco_input.Location = new Point(242, 161);
            endereco_input.Name = "endereco_input";
            endereco_input.Size = new Size(398, 23);
            endereco_input.TabIndex = 178;
            // 
            // mail_input
            // 
            mail_input.Location = new Point(242, 234);
            mail_input.Name = "mail_input";
            mail_input.Size = new Size(126, 23);
            mail_input.TabIndex = 179;
            // 
            // nif_input
            // 
            nif_input.Location = new Point(418, 234);
            nif_input.Name = "nif_input";
            nif_input.Size = new Size(126, 23);
            nif_input.TabIndex = 180;
            // 
            // telefone_input
            // 
            telefone_input.Location = new Point(607, 234);
            telefone_input.Name = "telefone_input";
            telefone_input.Size = new Size(126, 23);
            telefone_input.TabIndex = 181;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 192;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // Doador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(934, 519);
            Controls.Add(voltar_atras);
            Controls.Add(telefone_input);
            Controls.Add(nif_input);
            Controls.Add(mail_input);
            Controls.Add(endereco_input);
            Controls.Add(label3);
            Controls.Add(nome_input);
            Controls.Add(adicionar_doador);
            Controls.Add(nome);
            Controls.Add(mail);
            Controls.Add(telefone);
            Controls.Add(nif);
            Controls.Add(endereco);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Doador";
            Text = "Doador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.Label nome;
        internal System.Windows.Forms.Label mail;
        internal System.Windows.Forms.Label telefone;
        internal System.Windows.Forms.Label nif;
        internal System.Windows.Forms.Label endereco;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button adicionar_doador;
        internal TextBox nome_input;
        internal Label label3;
        internal TextBox endereco_input;
        internal TextBox mail_input;
        internal TextBox nif_input;
        internal TextBox telefone_input;
        private Button voltar_atras;
    }
}