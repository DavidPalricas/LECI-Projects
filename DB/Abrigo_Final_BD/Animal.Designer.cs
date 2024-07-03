namespace Abrigo_Final_BD
{
    partial class Animal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Animal));
            nome_input = new TextBox();
            nome = new Label();
            microchips = new Label();
            idade = new Label();
            altura = new Label();
            data = new Label();
            origem = new Label();
            adicionar_animal = new Button();
            label1 = new Label();
            altura_input = new TextBox();
            microchips_input = new TextBox();
            idade_input = new TextBox();
            peso_input = new TextBox();
            data_input = new TextBox();
            Origem_Historia = new TextBox();
            voltar_atras = new Button();
            SuspendLayout();
            // 
            // nome_input
            // 
            nome_input.Location = new Point(219, 89);
            nome_input.Margin = new Padding(3, 4, 3, 4);
            nome_input.Name = "nome_input";
            nome_input.Size = new Size(420, 27);
            nome_input.TabIndex = 183;
            nome_input.TextChanged += nome_input_TextChanged;
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(219, 55);
            nome.Margin = new Padding(5, 1, 5, 5);
            nome.Name = "nome";
            nome.Size = new Size(181, 25);
            nome.TabIndex = 157;
            nome.Text = "Nome do Animal*";
            // 
            // microchips
            // 
            microchips.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            microchips.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            microchips.Location = new Point(354, 155);
            microchips.Margin = new Padding(5, 5, 5, 1);
            microchips.Name = "microchips";
            microchips.Size = new Size(141, 25);
            microchips.TabIndex = 149;
            microchips.Text = "Nº MicroChips*";
            // 
            // idade
            // 
            idade.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            idade.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            idade.Location = new Point(505, 155);
            idade.Margin = new Padding(5, 5, 5, 1);
            idade.Name = "idade";
            idade.Size = new Size(96, 25);
            idade.TabIndex = 153;
            idade.Text = "Idade*";
            // 
            // altura
            // 
            altura.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            altura.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            altura.Location = new Point(219, 155);
            altura.Margin = new Padding(5, 5, 5, 1);
            altura.Name = "altura";
            altura.Size = new Size(96, 25);
            altura.TabIndex = 147;
            altura.Text = "Altura*";
            // 
            // data
            // 
            data.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            data.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            data.Location = new Point(747, 155);
            data.Margin = new Padding(5, 5, 5, 1);
            data.Name = "data";
            data.Size = new Size(367, 25);
            data.TabIndex = 175;
            data.Text = "Data de Entrada (No formato AAAA-MM-DD)*";
            // 
            // origem
            // 
            origem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            origem.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            origem.Location = new Point(219, 257);
            origem.Margin = new Padding(5, 5, 5, 1);
            origem.Name = "origem";
            origem.Size = new Size(147, 25);
            origem.TabIndex = 177;
            origem.Text = "Origem/História";
            // 
            // adicionar_animal
            // 
            adicionar_animal.Location = new Point(469, 404);
            adicionar_animal.Margin = new Padding(3, 4, 3, 4);
            adicionar_animal.Name = "adicionar_animal";
            adicionar_animal.Size = new Size(210, 125);
            adicionar_animal.TabIndex = 171;
            adicionar_animal.Text = "Adicionar Animal";
            adicionar_animal.UseVisualStyleBackColor = true;
            adicionar_animal.Click += adicionar_animal_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label1.Location = new Point(626, 155);
            label1.Margin = new Padding(5, 5, 5, 1);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 184;
            label1.Text = "Peso*";
            // 
            // altura_input
            // 
            altura_input.Location = new Point(219, 185);
            altura_input.Margin = new Padding(3, 4, 3, 4);
            altura_input.Name = "altura_input";
            altura_input.Size = new Size(95, 27);
            altura_input.TabIndex = 185;
            // 
            // microchips_input
            // 
            microchips_input.Location = new Point(354, 185);
            microchips_input.Margin = new Padding(3, 4, 3, 4);
            microchips_input.Name = "microchips_input";
            microchips_input.Size = new Size(119, 27);
            microchips_input.TabIndex = 186;
            // 
            // idade_input
            // 
            idade_input.Location = new Point(505, 185);
            idade_input.Margin = new Padding(3, 4, 3, 4);
            idade_input.Name = "idade_input";
            idade_input.Size = new Size(90, 27);
            idade_input.TabIndex = 187;
            // 
            // peso_input
            // 
            peso_input.Location = new Point(626, 185);
            peso_input.Margin = new Padding(3, 4, 3, 4);
            peso_input.Name = "peso_input";
            peso_input.Size = new Size(90, 27);
            peso_input.TabIndex = 188;
            // 
            // data_input
            // 
            data_input.Location = new Point(747, 185);
            data_input.Margin = new Padding(3, 4, 3, 4);
            data_input.Name = "data_input";
            data_input.Size = new Size(339, 27);
            data_input.TabIndex = 189;
            // 
            // Origem_Historia
            // 
            Origem_Historia.Location = new Point(219, 301);
            Origem_Historia.Margin = new Padding(3, 4, 3, 4);
            Origem_Historia.Name = "Origem_Historia";
            Origem_Historia.Size = new Size(691, 27);
            Origem_Historia.TabIndex = 190;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(14, 16);
            voltar_atras.Margin = new Padding(3, 4, 3, 4);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(130, 32);
            voltar_atras.TabIndex = 191;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // Animal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1128, 692);
            Controls.Add(voltar_atras);
            Controls.Add(Origem_Historia);
            Controls.Add(data_input);
            Controls.Add(peso_input);
            Controls.Add(idade_input);
            Controls.Add(microchips_input);
            Controls.Add(altura_input);
            Controls.Add(label1);
            Controls.Add(origem);
            Controls.Add(data);
            Controls.Add(adicionar_animal);
            Controls.Add(nome_input);
            Controls.Add(nome);
            Controls.Add(microchips);
            Controls.Add(idade);
            Controls.Add(altura);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 5, 5, 5);
            Name = "Animal";
            Text = "Animal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.TextBox nome_input;
        internal System.Windows.Forms.Label nome;
        internal System.Windows.Forms.Label microchips;
        internal System.Windows.Forms.Label idade;
        internal System.Windows.Forms.Label altura;
        internal System.Windows.Forms.Label data;
        internal System.Windows.Forms.Label origem;
        private System.Windows.Forms.Button adicionar_animal;
        internal Label label1;
        internal TextBox altura_input;
        internal TextBox microchips_input;
        internal TextBox idade_input;
        internal TextBox peso_input;
        internal TextBox data_input;
        internal TextBox Origem_Historia;
        private Button voltar_atras;
    }
}