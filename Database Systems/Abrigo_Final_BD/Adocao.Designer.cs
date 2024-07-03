namespace Abrigo_Final_BD
{
    partial class Adocao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adocao));
            adicionar_adocao = new Button();
            nif_adotante = new TextBox();
            label2 = new Label();
            numero_animal = new TextBox();
            texto = new Label();
            telefone_input = new TextBox();
            endereco_input = new TextBox();
            adocao_input = new TextBox();
            nome_input = new TextBox();
            nome = new Label();
            telefone = new Label();
            endereco = new Label();
            data_adocao = new Label();
            mail_input = new TextBox();
            mail = new Label();
            voltar_atras = new Button();
            SuspendLayout();
            // 
            // adicionar_adocao
            // 
            adicionar_adocao.Location = new Point(360, 441);
            adicionar_adocao.Margin = new Padding(3, 4, 3, 4);
            adicionar_adocao.Name = "adicionar_adocao";
            adicionar_adocao.Size = new Size(197, 92);
            adicionar_adocao.TabIndex = 204;
            adicionar_adocao.Text = "Adicionar Adoção";
            adicionar_adocao.UseVisualStyleBackColor = true;
            adicionar_adocao.Click += adicionar_adocao_Click;
            // 
            // nif_adotante
            // 
            nif_adotante.Location = new Point(40, 196);
            nif_adotante.Margin = new Padding(3, 4, 3, 4);
            nif_adotante.Name = "nif_adotante";
            nif_adotante.Size = new Size(341, 27);
            nif_adotante.TabIndex = 203;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label2.Location = new Point(40, 161);
            label2.Margin = new Padding(5, 1, 5, 5);
            label2.Name = "label2";
            label2.Size = new Size(342, 25);
            label2.TabIndex = 202;
            label2.Text = "NIF do Adotante";
            // 
            // numero_animal
            // 
            numero_animal.Location = new Point(40, 103);
            numero_animal.Margin = new Padding(3, 4, 3, 4);
            numero_animal.Name = "numero_animal";
            numero_animal.Size = new Size(341, 27);
            numero_animal.TabIndex = 200;
            // 
            // texto
            // 
            texto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            texto.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            texto.Location = new Point(40, 68);
            texto.Margin = new Padding(5, 1, 5, 5);
            texto.Name = "texto";
            texto.Size = new Size(342, 25);
            texto.TabIndex = 199;
            texto.Text = "Número do Animal a Adotar";
            // 
            // telefone_input
            // 
            telefone_input.Location = new Point(709, 295);
            telefone_input.Margin = new Padding(3, 4, 3, 4);
            telefone_input.Name = "telefone_input";
            telefone_input.Size = new Size(191, 27);
            telefone_input.TabIndex = 212;
            // 
            // endereco_input
            // 
            endereco_input.Location = new Point(440, 291);
            endereco_input.Margin = new Padding(3, 4, 3, 4);
            endereco_input.Name = "endereco_input";
            endereco_input.Size = new Size(181, 27);
            endereco_input.TabIndex = 211;
            // 
            // adocao_input
            // 
            adocao_input.Location = new Point(440, 196);
            adocao_input.Margin = new Padding(3, 4, 3, 4);
            adocao_input.Name = "adocao_input";
            adocao_input.Size = new Size(460, 27);
            adocao_input.TabIndex = 210;
            // 
            // nome_input
            // 
            nome_input.Location = new Point(440, 103);
            nome_input.Margin = new Padding(3, 4, 3, 4);
            nome_input.Name = "nome_input";
            nome_input.Size = new Size(460, 27);
            nome_input.TabIndex = 209;
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(441, 68);
            nome.Margin = new Padding(5, 1, 5, 5);
            nome.Name = "nome";
            nome.Size = new Size(181, 25);
            nome.TabIndex = 208;
            nome.Text = "Nome do Adotante*";
            // 
            // telefone
            // 
            telefone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            telefone.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            telefone.Location = new Point(709, 264);
            telefone.Margin = new Padding(5, 5, 5, 1);
            telefone.Name = "telefone";
            telefone.Size = new Size(133, 25);
            telefone.TabIndex = 207;
            telefone.Text = "Telefone*";
            // 
            // endereco
            // 
            endereco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            endereco.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            endereco.Location = new Point(440, 260);
            endereco.Margin = new Padding(5, 5, 5, 1);
            endereco.Name = "endereco";
            endereco.Size = new Size(117, 25);
            endereco.TabIndex = 206;
            endereco.Text = "Endereço*";
            // 
            // data_adocao
            // 
            data_adocao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            data_adocao.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            data_adocao.Location = new Point(440, 165);
            data_adocao.Margin = new Padding(5, 5, 5, 1);
            data_adocao.Name = "data_adocao";
            data_adocao.Size = new Size(461, 25);
            data_adocao.TabIndex = 205;
            data_adocao.Text = "Data de Adoção (No formato AAAA-MM-DD)*";
            // 
            // mail_input
            // 
            mail_input.Location = new Point(441, 375);
            mail_input.Margin = new Padding(3, 4, 3, 4);
            mail_input.Name = "mail_input";
            mail_input.Size = new Size(459, 27);
            mail_input.TabIndex = 214;
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mail.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            mail.Location = new Point(443, 344);
            mail.Margin = new Padding(5, 5, 5, 1);
            mail.Name = "mail";
            mail.Size = new Size(406, 25);
            mail.TabIndex = 213;
            mail.Text = "Email*";
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(14, 16);
            voltar_atras.Margin = new Padding(3, 4, 3, 4);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(130, 32);
            voltar_atras.TabIndex = 215;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // Adocao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(914, 600);
            Controls.Add(voltar_atras);
            Controls.Add(mail_input);
            Controls.Add(mail);
            Controls.Add(telefone_input);
            Controls.Add(endereco_input);
            Controls.Add(adocao_input);
            Controls.Add(nome_input);
            Controls.Add(nome);
            Controls.Add(telefone);
            Controls.Add(endereco);
            Controls.Add(data_adocao);
            Controls.Add(adicionar_adocao);
            Controls.Add(nif_adotante);
            Controls.Add(label2);
            Controls.Add(numero_animal);
            Controls.Add(texto);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Adocao";
            Text = "Adoção";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button adicionar_adocao;
        internal TextBox nif_adotante;
        internal Label label2;
        internal TextBox numero_animal;
        internal Label texto;
        internal TextBox telefone_input;
        internal TextBox endereco_input;
        internal TextBox adocao_input;
        internal TextBox nome_input;
        internal Label nome;
        internal Label telefone;
        internal Label endereco;
        internal Label data_adocao;
        internal TextBox mail_input;
        internal Label mail;
        private Button voltar_atras;
    }
}