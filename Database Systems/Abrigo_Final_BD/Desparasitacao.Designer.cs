namespace Abrigo_Final_BD
{
    partial class Desparasitacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desparasitacao));
            adicionar_desparasitacao = new Button();
            label1 = new Label();
            data_desparasitacao = new TextBox();
            nome = new Label();
            label2 = new Label();
            tipo_desparasitante = new TextBox();
            tipo_desparasitcao = new ComboBox();
            voltar_atras = new Button();
            animal = new Label();
            animal_input = new TextBox();
            SuspendLayout();
            // 
            // adicionar_desparasitacao
            // 
            adicionar_desparasitacao.Location = new Point(311, 341);
            adicionar_desparasitacao.Name = "adicionar_desparasitacao";
            adicionar_desparasitacao.Size = new Size(172, 69);
            adicionar_desparasitacao.TabIndex = 197;
            adicionar_desparasitacao.Text = "Adicionar Desparasitação";
            adicionar_desparasitacao.UseVisualStyleBackColor = true;
            adicionar_desparasitacao.Click += adicionar_desparasitacao_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label1.Location = new Point(218, 123);
            label1.Margin = new Padding(4, 1, 4, 4);
            label1.Name = "label1";
            label1.Size = new Size(368, 19);
            label1.TabIndex = 193;
            label1.Text = "Tipo de Desparasitação*";
            // 
            // data_desparasitacao
            // 
            data_desparasitacao.Location = new Point(218, 84);
            data_desparasitacao.Name = "data_desparasitacao";
            data_desparasitacao.Size = new Size(368, 23);
            data_desparasitacao.TabIndex = 192;
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(218, 58);
            nome.Margin = new Padding(4, 1, 4, 4);
            nome.Name = "nome";
            nome.Size = new Size(368, 19);
            nome.TabIndex = 191;
            nome.Text = "Data da Desparasitação (No formato AAAA-MM-DD)*";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label2.Location = new Point(218, 190);
            label2.Margin = new Padding(4, 1, 4, 4);
            label2.Name = "label2";
            label2.Size = new Size(368, 19);
            label2.TabIndex = 195;
            label2.Text = "Desparasitante*";
            // 
            // tipo_desparasitante
            // 
            tipo_desparasitante.Location = new Point(218, 216);
            tipo_desparasitante.Name = "tipo_desparasitante";
            tipo_desparasitante.Size = new Size(368, 23);
            tipo_desparasitante.TabIndex = 196;
            // 
            // tipo_desparasitcao
            // 
            tipo_desparasitcao.FormattingEnabled = true;
            tipo_desparasitcao.Items.AddRange(new object[] { "Externa", "Interna" });
            tipo_desparasitcao.Location = new Point(218, 149);
            tipo_desparasitcao.Name = "tipo_desparasitcao";
            tipo_desparasitcao.Size = new Size(365, 23);
            tipo_desparasitcao.TabIndex = 198;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 199;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // animal
            // 
            animal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            animal.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            animal.Location = new Point(218, 258);
            animal.Margin = new Padding(4, 1, 4, 4);
            animal.Name = "animal";
            animal.Size = new Size(368, 19);
            animal.TabIndex = 200;
            animal.Text = "Número de chegada do Animal*";
            // 
            // animal_input
            // 
            animal_input.Location = new Point(218, 284);
            animal_input.Name = "animal_input";
            animal_input.Size = new Size(368, 23);
            animal_input.TabIndex = 201;
            // 
            // Desparasitacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(animal_input);
            Controls.Add(animal);
            Controls.Add(voltar_atras);
            Controls.Add(tipo_desparasitcao);
            Controls.Add(adicionar_desparasitacao);
            Controls.Add(tipo_desparasitante);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(data_desparasitacao);
            Controls.Add(nome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Desparasitacao";
            Text = "Desparasitação";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button adicionar_desparasitacao;
        internal Label label1;
        internal TextBox data_desparasitacao;
        internal Label nome;
        internal Label label2;
        internal TextBox tipo_desparasitante;
        private ComboBox tipo_desparasitcao;
        private Button voltar_atras;
        internal Label animal;
        internal TextBox animal_input;
    }
}