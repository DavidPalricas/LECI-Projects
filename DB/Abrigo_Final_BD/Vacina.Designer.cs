namespace Abrigo_Final_BD
{
    partial class Vacina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vacina));
            data_vacina = new TextBox();
            nome = new Label();
            tipo_vacina = new TextBox();
            label1 = new Label();
            numero_dose = new TextBox();
            label2 = new Label();
            adicionar_vacina = new Button();
            voltar_atras = new Button();
            animal = new Label();
            animal_input = new TextBox();
            SuspendLayout();
            // 
            // data_vacina
            // 
            data_vacina.Location = new Point(215, 81);
            data_vacina.Name = "data_vacina";
            data_vacina.Size = new Size(372, 23);
            data_vacina.TabIndex = 185;
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(215, 55);
            nome.Margin = new Padding(4, 1, 4, 4);
            nome.Name = "nome";
            nome.Size = new Size(372, 19);
            nome.TabIndex = 184;
            nome.Text = "Data da Vacina (No formato AAAA-MM-DD)*";
            // 
            // tipo_vacina
            // 
            tipo_vacina.Location = new Point(215, 144);
            tipo_vacina.Name = "tipo_vacina";
            tipo_vacina.Size = new Size(372, 23);
            tipo_vacina.TabIndex = 187;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label1.Location = new Point(215, 118);
            label1.Margin = new Padding(4, 1, 4, 4);
            label1.Name = "label1";
            label1.Size = new Size(372, 19);
            label1.TabIndex = 186;
            label1.Text = "Tipo de Vacina*";
            // 
            // numero_dose
            // 
            numero_dose.Location = new Point(215, 207);
            numero_dose.Name = "numero_dose";
            numero_dose.Size = new Size(372, 23);
            numero_dose.TabIndex = 189;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label2.Location = new Point(216, 181);
            label2.Margin = new Padding(4, 1, 4, 4);
            label2.Name = "label2";
            label2.Size = new Size(371, 19);
            label2.TabIndex = 188;
            label2.Text = "Número da Dose*";
            // 
            // adicionar_vacina
            // 
            adicionar_vacina.Location = new Point(313, 334);
            adicionar_vacina.Name = "adicionar_vacina";
            adicionar_vacina.Size = new Size(172, 69);
            adicionar_vacina.TabIndex = 190;
            adicionar_vacina.Text = "Adicionar Vacina";
            adicionar_vacina.UseVisualStyleBackColor = true;
            adicionar_vacina.Click += adicionar_vacina_Click;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 195;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // animal
            // 
            animal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            animal.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            animal.Location = new Point(215, 248);
            animal.Margin = new Padding(4, 1, 4, 4);
            animal.Name = "animal";
            animal.Size = new Size(368, 19);
            animal.TabIndex = 196;
            animal.Text = "Número de chegada do Animal*";
            // 
            // animal_input
            // 
            animal_input.Location = new Point(215, 274);
            animal_input.Name = "animal_input";
            animal_input.Size = new Size(372, 23);
            animal_input.TabIndex = 197;
            // 
            // Vacina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(animal_input);
            Controls.Add(animal);
            Controls.Add(voltar_atras);
            Controls.Add(adicionar_vacina);
            Controls.Add(numero_dose);
            Controls.Add(label2);
            Controls.Add(tipo_vacina);
            Controls.Add(label1);
            Controls.Add(data_vacina);
            Controls.Add(nome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Vacina";
            Text = "Vacina";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal TextBox data_vacina;
        internal Label nome;
        internal TextBox tipo_vacina;
        internal Label label1;
        internal TextBox numero_dose;
        internal Label label2;
        private Button adicionar_vacina;
        private Button voltar_atras;
        internal Label animal;
        internal TextBox animal_input;
    }
}