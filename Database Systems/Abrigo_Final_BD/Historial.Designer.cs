namespace Abrigo_Final_BD
{
    partial class Historial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Historial));
            adicionar_historial = new Button();
            tipo_medicacao = new TextBox();
            label2 = new Label();
            tipo_patologia = new TextBox();
            label1 = new Label();
            data_intervencao = new TextBox();
            nome = new Label();
            num_animal = new TextBox();
            label3 = new Label();
            voltar_atras = new Button();
            SuspendLayout();
            // 
            // adicionar_historial
            // 
            adicionar_historial.Location = new Point(315, 324);
            adicionar_historial.Name = "adicionar_historial";
            adicionar_historial.Size = new Size(172, 69);
            adicionar_historial.TabIndex = 197;
            adicionar_historial.Text = "Adicionar Historial";
            adicionar_historial.UseVisualStyleBackColor = true;
            adicionar_historial.Click += adicionar_historial_Click;
            // 
            // tipo_medicacao
            // 
            tipo_medicacao.Location = new Point(197, 247);
            tipo_medicacao.Name = "tipo_medicacao";
            tipo_medicacao.Size = new Size(399, 23);
            tipo_medicacao.TabIndex = 196;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label2.Location = new Point(197, 221);
            label2.Margin = new Padding(4, 1, 4, 4);
            label2.Name = "label2";
            label2.Size = new Size(368, 19);
            label2.TabIndex = 195;
            label2.Text = "Medicação*";
            // 
            // tipo_patologia
            // 
            tipo_patologia.Location = new Point(197, 166);
            tipo_patologia.Name = "tipo_patologia";
            tipo_patologia.Size = new Size(169, 23);
            tipo_patologia.TabIndex = 194;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label1.Location = new Point(197, 140);
            label1.Margin = new Padding(4, 1, 4, 4);
            label1.Name = "label1";
            label1.Size = new Size(152, 19);
            label1.TabIndex = 193;
            label1.Text = "Patologia*";
            // 
            // data_intervencao
            // 
            data_intervencao.Location = new Point(197, 85);
            data_intervencao.Name = "data_intervencao";
            data_intervencao.Size = new Size(399, 23);
            data_intervencao.TabIndex = 192;
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(197, 59);
            nome.Margin = new Padding(4, 1, 4, 4);
            nome.Name = "nome";
            nome.Size = new Size(371, 19);
            nome.TabIndex = 191;
            nome.Text = "Data da Intervenção (No formato AAAA-MM-DD)*";
            // 
            // num_animal
            // 
            num_animal.Location = new Point(395, 166);
            num_animal.Name = "num_animal";
            num_animal.Size = new Size(201, 23);
            num_animal.TabIndex = 199;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label3.Location = new Point(395, 140);
            label3.Margin = new Padding(4, 1, 4, 4);
            label3.Name = "label3";
            label3.Size = new Size(218, 19);
            label3.TabIndex = 198;
            label3.Text = "Número de chegada do Animal*";
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 200;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // Historial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(voltar_atras);
            Controls.Add(num_animal);
            Controls.Add(label3);
            Controls.Add(adicionar_historial);
            Controls.Add(tipo_medicacao);
            Controls.Add(label2);
            Controls.Add(tipo_patologia);
            Controls.Add(label1);
            Controls.Add(data_intervencao);
            Controls.Add(nome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Historial";
            Text = "Historial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button adicionar_historial;
        internal TextBox tipo_medicacao;
        internal Label label2;
        internal TextBox tipo_patologia;
        internal Label label1;
        internal TextBox data_intervencao;
        internal Label nome;
        internal TextBox num_animal;
        internal Label label3;
        private Button voltar_atras;
    }
}