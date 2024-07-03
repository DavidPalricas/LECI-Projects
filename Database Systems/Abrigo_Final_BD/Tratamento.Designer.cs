namespace Abrigo_Final_BD
{
    partial class Tratamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tratamento));
            tipo = new Label();
            data = new Label();
            data_tratamento = new TextBox();
            adicionar_tratamento = new Button();
            getanimal = new TextBox();
            texto_animal = new Label();
            texto_tratador = new Label();
            tipo_tratamento = new TextBox();
            voltar_atras = new Button();
            getTratador = new TextBox();
            SuspendLayout();
            // 
            // tipo
            // 
            tipo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tipo.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            tipo.Location = new Point(264, 100);
            tipo.Margin = new Padding(4, 1, 4, 4);
            tipo.Name = "tipo";
            tipo.Size = new Size(158, 19);
            tipo.TabIndex = 157;
            tipo.Text = "Tipo do Tratamento*";
            // 
            // data
            // 
            data.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            data.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            data.Location = new Point(264, 170);
            data.Margin = new Padding(4, 4, 4, 1);
            data.Name = "data";
            data.Size = new Size(403, 19);
            data.TabIndex = 145;
            data.Text = "Data do Tratamento (No formato AAAA-MM-DD)*";
            // 
            // data_tratamento
            // 
            data_tratamento.Location = new Point(264, 193);
            data_tratamento.Name = "data_tratamento";
            data_tratamento.Size = new Size(403, 23);
            data_tratamento.TabIndex = 178;
            // 
            // adicionar_tratamento
            // 
            adicionar_tratamento.Location = new Point(372, 301);
            adicionar_tratamento.Name = "adicionar_tratamento";
            adicionar_tratamento.Size = new Size(184, 94);
            adicionar_tratamento.TabIndex = 171;
            adicionar_tratamento.Text = "Adicionar Tratamento";
            adicionar_tratamento.UseVisualStyleBackColor = true;
            adicionar_tratamento.Click += adicionar_tratamento_Click;
            // 
            // getanimal
            // 
            getanimal.Location = new Point(426, 255);
            getanimal.Name = "getanimal";
            getanimal.Size = new Size(241, 23);
            getanimal.TabIndex = 177;
            getanimal.TextChanged += getanimal_TextChanged;
            // 
            // texto_animal
            // 
            texto_animal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            texto_animal.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            texto_animal.Location = new Point(426, 232);
            texto_animal.Margin = new Padding(4, 4, 4, 1);
            texto_animal.Name = "texto_animal";
            texto_animal.Size = new Size(241, 19);
            texto_animal.TabIndex = 175;
            texto_animal.Text = "Número de Chegada do Animal*";
            // 
            // texto_tratador
            // 
            texto_tratador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            texto_tratador.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            texto_tratador.Location = new Point(265, 232);
            texto_tratador.Margin = new Padding(4, 4, 4, 1);
            texto_tratador.Name = "texto_tratador";
            texto_tratador.Size = new Size(162, 19);
            texto_tratador.TabIndex = 174;
            texto_tratador.Text = "Número do Tratador*";
            // 
            // tipo_tratamento
            // 
            tipo_tratamento.Location = new Point(265, 126);
            tipo_tratamento.Name = "tipo_tratamento";
            tipo_tratamento.Size = new Size(402, 23);
            tipo_tratamento.TabIndex = 0;
            tipo_tratamento.TextChanged += tipo_tratamento_TextChanged;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 194;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // getTratador
            // 
            getTratador.Location = new Point(265, 255);
            getTratador.Name = "getTratador";
            getTratador.Size = new Size(145, 23);
            getTratador.TabIndex = 195;
            // 
            // Tratamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(934, 519);
            Controls.Add(getTratador);
            Controls.Add(voltar_atras);
            Controls.Add(tipo_tratamento);
            Controls.Add(texto_animal);
            Controls.Add(texto_tratador);
            Controls.Add(getanimal);
            Controls.Add(adicionar_tratamento);
            Controls.Add(tipo);
            Controls.Add(data);
            Controls.Add(data_tratamento);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Tratamento";
            Text = "Tratamento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.Label tipo;
        internal System.Windows.Forms.Label data;
        internal System.Windows.Forms.TextBox data_tratamento;
        private System.Windows.Forms.Button adicionar_tratamento;
        internal System.Windows.Forms.TextBox getanimal;
        internal System.Windows.Forms.Label texto_animal;
        internal System.Windows.Forms.Label texto_tratador;
        internal TextBox tipo_tratamento;
        private Button voltar_atras;
        internal TextBox getTratador;
    }
}