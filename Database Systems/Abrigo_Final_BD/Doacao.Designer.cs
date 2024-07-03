namespace Abrigo_Final_BD
{
    partial class Doacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doacao));
            tipo = new Label();
            data = new Label();
            Label2 = new Label();
            Label1 = new Label();
            adicionar_doacao = new Button();
            label4 = new Label();
            voltar_atras = new Button();
            data_doacao = new TextBox();
            quantidade_input = new TextBox();
            label3 = new Label();
            nif_doador = new TextBox();
            tipo_doacao = new ComboBox();
            telefone_input = new TextBox();
            mail_input = new TextBox();
            endereco_input = new TextBox();
            label5 = new Label();
            nome_input = new TextBox();
            mail = new Label();
            telefone = new Label();
            endereco = new Label();
            SuspendLayout();
            // 
            // tipo
            // 
            tipo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tipo.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            tipo.Location = new Point(58, 68);
            tipo.Margin = new Padding(4, 1, 4, 4);
            tipo.Name = "tipo";
            tipo.Size = new Size(158, 19);
            tipo.TabIndex = 157;
            tipo.Text = "Tipo da Doação*";
            // 
            // data
            // 
            data.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            data.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            data.Location = new Point(57, 129);
            data.Margin = new Padding(4, 4, 4, 1);
            data.Name = "data";
            data.Size = new Size(402, 19);
            data.TabIndex = 145;
            data.Text = "Data da Doação (No formato AAAA-MM-DD)*";
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
            // adicionar_doacao
            // 
            adicionar_doacao.Location = new Point(377, 339);
            adicionar_doacao.Name = "adicionar_doacao";
            adicionar_doacao.Size = new Size(184, 94);
            adicionar_doacao.TabIndex = 171;
            adicionar_doacao.Text = "Adicionar Doação";
            adicionar_doacao.UseVisualStyleBackColor = true;
            adicionar_doacao.Click += adicionar_doacao_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label4.Location = new Point(57, 187);
            label4.Margin = new Padding(4, 1, 4, 4);
            label4.Name = "label4";
            label4.Size = new Size(158, 19);
            label4.TabIndex = 172;
            label4.Text = "Quantidade*";
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 193;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // data_doacao
            // 
            data_doacao.Location = new Point(58, 152);
            data_doacao.Name = "data_doacao";
            data_doacao.Size = new Size(402, 23);
            data_doacao.TabIndex = 195;
            // 
            // quantidade_input
            // 
            quantidade_input.Location = new Point(57, 213);
            quantidade_input.Name = "quantidade_input";
            quantidade_input.Size = new Size(402, 23);
            quantidade_input.TabIndex = 196;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label3.Location = new Point(58, 256);
            label3.Margin = new Padding(4, 1, 4, 4);
            label3.Name = "label3";
            label3.Size = new Size(158, 19);
            label3.TabIndex = 197;
            label3.Text = "NIF do Doador*";
            // 
            // nif_doador
            // 
            nif_doador.Location = new Point(58, 282);
            nif_doador.Name = "nif_doador";
            nif_doador.Size = new Size(402, 23);
            nif_doador.TabIndex = 198;
            // 
            // tipo_doacao
            // 
            tipo_doacao.DropDownStyle = ComboBoxStyle.DropDownList;
            tipo_doacao.FormattingEnabled = true;
            tipo_doacao.Items.AddRange(new object[] { "Monetária(€)", "Alimentar(Kg)", "Medicinal(Unidade)", "Acessórios(Unidade)" });
            tipo_doacao.Location = new Point(57, 93);
            tipo_doacao.Name = "tipo_doacao";
            tipo_doacao.Size = new Size(402, 23);
            tipo_doacao.TabIndex = 199;
            // 
            // telefone_input
            // 
            telefone_input.Location = new Point(666, 210);
            telefone_input.Name = "telefone_input";
            telefone_input.Size = new Size(126, 23);
            telefone_input.TabIndex = 209;
            // 
            // mail_input
            // 
            mail_input.Location = new Point(507, 210);
            mail_input.Name = "mail_input";
            mail_input.Size = new Size(126, 23);
            mail_input.TabIndex = 207;
            // 
            // endereco_input
            // 
            endereco_input.Location = new Point(507, 152);
            endereco_input.Name = "endereco_input";
            endereco_input.Size = new Size(398, 23);
            endereco_input.TabIndex = 206;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label5.Location = new Point(507, 70);
            label5.Margin = new Padding(4, 4, 4, 1);
            label5.Name = "label5";
            label5.Size = new Size(124, 19);
            label5.TabIndex = 205;
            label5.Text = "Nome do Doador*";
            // 
            // nome_input
            // 
            nome_input.Location = new Point(507, 93);
            nome_input.Name = "nome_input";
            nome_input.Size = new Size(398, 23);
            nome_input.TabIndex = 204;
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mail.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            mail.Location = new Point(507, 187);
            mail.Margin = new Padding(4, 4, 4, 1);
            mail.Name = "mail";
            mail.Size = new Size(101, 19);
            mail.TabIndex = 203;
            mail.Text = "Email*";
            // 
            // telefone
            // 
            telefone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            telefone.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            telefone.Location = new Point(666, 187);
            telefone.Margin = new Padding(4, 4, 4, 1);
            telefone.Name = "telefone";
            telefone.Size = new Size(105, 19);
            telefone.TabIndex = 201;
            telefone.Text = "Telefone*";
            // 
            // endereco
            // 
            endereco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            endereco.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            endereco.Location = new Point(505, 129);
            endereco.Margin = new Padding(4, 4, 4, 1);
            endereco.Name = "endereco";
            endereco.Size = new Size(84, 19);
            endereco.TabIndex = 200;
            endereco.Text = "Endereço*";
            // 
            // Doacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(934, 519);
            Controls.Add(telefone_input);
            Controls.Add(mail_input);
            Controls.Add(endereco_input);
            Controls.Add(label5);
            Controls.Add(nome_input);
            Controls.Add(mail);
            Controls.Add(telefone);
            Controls.Add(endereco);
            Controls.Add(tipo_doacao);
            Controls.Add(nif_doador);
            Controls.Add(label3);
            Controls.Add(quantidade_input);
            Controls.Add(data_doacao);
            Controls.Add(voltar_atras);
            Controls.Add(label4);
            Controls.Add(adicionar_doacao);
            Controls.Add(tipo);
            Controls.Add(data);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Doacao";
            Text = "Doação";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.Label tipo;
        internal System.Windows.Forms.Label data;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button adicionar_doacao;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion

        internal Label label4;
        private Button voltar_atras;
        internal TextBox data_doacao;
        internal TextBox quantidade_input;
        internal Label label3;
        internal TextBox nif_doador;
        private ComboBox tipo_doacao;
        internal TextBox telefone_input;
        internal TextBox mail_input;
        internal TextBox endereco_input;
        internal Label label5;
        internal TextBox nome_input;
        internal Label mail;
        internal Label telefone;
        internal Label endereco;
    }
}