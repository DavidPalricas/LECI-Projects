namespace Abrigo_Final_BD
{
    partial class Adotante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adotante));
            nome_input = new TextBox();
            nome = new Label();
            mail = new Label();
            telefone = new Label();
            nif = new Label();
            endereco = new Label();
            data_adocao = new Label();
            Label2 = new Label();
            Label1 = new Label();
            adicionar_adotante = new Button();
            adocao_input = new TextBox();
            endereco_input = new TextBox();
            telefone_input = new TextBox();
            mail_input = new TextBox();
            nif_input = new TextBox();
            voltar_atras = new Button();
            SuspendLayout();
            // 
            // nome_input
            // 
            nome_input.Location = new Point(257, 85);
            nome_input.Name = "nome_input";
            nome_input.Size = new Size(403, 23);
            nome_input.TabIndex = 171;
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(258, 59);
            nome.Margin = new Padding(4, 1, 4, 4);
            nome.Name = "nome";
            nome.Size = new Size(158, 19);
            nome.TabIndex = 157;
            nome.Text = "Nome do Adotante*";
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mail.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            mail.Location = new Point(259, 274);
            mail.Margin = new Padding(4, 4, 4, 1);
            mail.Name = "mail";
            mail.Size = new Size(112, 19);
            mail.TabIndex = 155;
            mail.Text = "Email*";
            // 
            // telefone
            // 
            telefone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            telefone.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            telefone.Location = new Point(492, 206);
            telefone.Margin = new Padding(4, 4, 4, 1);
            telefone.Name = "telefone";
            telefone.Size = new Size(116, 19);
            telefone.TabIndex = 149;
            telefone.Text = "Telefone*";
            // 
            // nif
            // 
            nif.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nif.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nif.Location = new Point(492, 274);
            nif.Margin = new Padding(4, 4, 4, 1);
            nif.Name = "nif";
            nif.Size = new Size(102, 19);
            nif.TabIndex = 153;
            nif.Text = "NIF*";
            // 
            // endereco
            // 
            endereco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            endereco.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            endereco.Location = new Point(257, 206);
            endereco.Margin = new Padding(4, 4, 4, 1);
            endereco.Name = "endereco";
            endereco.Size = new Size(102, 19);
            endereco.TabIndex = 147;
            endereco.Text = "Endereço*";
            // 
            // data_adocao
            // 
            data_adocao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            data_adocao.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            data_adocao.Location = new Point(257, 129);
            data_adocao.Margin = new Padding(4, 4, 4, 1);
            data_adocao.Name = "data_adocao";
            data_adocao.Size = new Size(403, 19);
            data_adocao.TabIndex = 145;
            data_adocao.Text = "Data de Adoção (No formato AAAA-MM-DD)*";
            // 
            // Label2
            // 
            Label2.Location = new Point(0, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(88, 22);
            Label2.TabIndex = 162;
            // 
            // Label1
            // 
            Label1.Location = new Point(0, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(88, 22);
            Label1.TabIndex = 163;
            // 
            // adicionar_adotante
            // 
            adicionar_adotante.Location = new Point(368, 351);
            adicionar_adotante.Name = "adicionar_adotante";
            adicionar_adotante.Size = new Size(184, 94);
            adicionar_adotante.TabIndex = 170;
            adicionar_adotante.Text = "Adicionar Adotante";
            adicionar_adotante.UseVisualStyleBackColor = true;
            adicionar_adotante.Click += adicionar_adotante_Click;
            // 
            // adocao_input
            // 
            adocao_input.Location = new Point(257, 152);
            adocao_input.Name = "adocao_input";
            adocao_input.Size = new Size(403, 23);
            adocao_input.TabIndex = 172;
            // 
            // endereco_input
            // 
            endereco_input.Location = new Point(257, 226);
            endereco_input.Name = "endereco_input";
            endereco_input.Size = new Size(159, 23);
            endereco_input.TabIndex = 173;
            // 
            // telefone_input
            // 
            telefone_input.Location = new Point(492, 229);
            telefone_input.Name = "telefone_input";
            telefone_input.Size = new Size(159, 23);
            telefone_input.TabIndex = 174;
            // 
            // mail_input
            // 
            mail_input.Location = new Point(257, 297);
            mail_input.Name = "mail_input";
            mail_input.Size = new Size(159, 23);
            mail_input.TabIndex = 175;
            // 
            // nif_input
            // 
            nif_input.Location = new Point(492, 297);
            nif_input.Name = "nif_input";
            nif_input.Size = new Size(159, 23);
            nif_input.TabIndex = 176;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 177;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // Adotante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(934, 519);
            Controls.Add(voltar_atras);
            Controls.Add(nif_input);
            Controls.Add(mail_input);
            Controls.Add(telefone_input);
            Controls.Add(endereco_input);
            Controls.Add(adocao_input);
            Controls.Add(adicionar_adotante);
            Controls.Add(nome_input);
            Controls.Add(nome);
            Controls.Add(mail);
            Controls.Add(telefone);
            Controls.Add(nif);
            Controls.Add(endereco);
            Controls.Add(data_adocao);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Adotante";
            Text = "Adotante";
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
        internal System.Windows.Forms.Label data_adocao;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button adicionar_adotante;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion

        internal TextBox adocao_input;
        internal TextBox endereco_input;
        internal TextBox telefone_input;
        internal TextBox mail_input;
        internal TextBox nif_input;
        private Button voltar_atras;
    }
}