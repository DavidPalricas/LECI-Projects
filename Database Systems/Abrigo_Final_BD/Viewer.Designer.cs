namespace Abrigo_Final_BD
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            dataGridView1 = new DataGridView();
            voltar_atras = new Button();
            texto_animal = new Label();
            num_animal = new TextBox();
            submit_button = new Button();
            consultar_por_adotar = new Button();
            consultar_adotados = new Button();
            texto_animal_morto = new Label();
            num_animal_morto = new TextBox();
            submit_button_2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 75);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(887, 333);
            dataGridView1.TabIndex = 0;
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(14, 16);
            voltar_atras.Margin = new Padding(3, 4, 3, 4);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(130, 32);
            voltar_atras.TabIndex = 195;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // texto_animal
            // 
            texto_animal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            texto_animal.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            texto_animal.Location = new Point(14, 483);
            texto_animal.Margin = new Padding(5, 5, 5, 1);
            texto_animal.Name = "texto_animal";
            texto_animal.Size = new Size(441, 52);
            texto_animal.TabIndex = 197;
            texto_animal.Text = "Insira o número de chegada do animal para mais detalhes*\r\n \r\n\r\n\r\n";
            // 
            // num_animal
            // 
            num_animal.Location = new Point(463, 479);
            num_animal.Margin = new Padding(3, 4, 3, 4);
            num_animal.Name = "num_animal";
            num_animal.Size = new Size(81, 27);
            num_animal.TabIndex = 200;
            // 
            // submit_button
            // 
            submit_button.Location = new Point(566, 479);
            submit_button.Margin = new Padding(3, 4, 3, 4);
            submit_button.Name = "submit_button";
            submit_button.Size = new Size(94, 32);
            submit_button.TabIndex = 201;
            submit_button.Text = "Ok";
            submit_button.UseVisualStyleBackColor = true;
            submit_button.Click += submit_button_Click;
            // 
            // consultar_por_adotar
            // 
            consultar_por_adotar.Location = new Point(213, 95);
            consultar_por_adotar.Margin = new Padding(3, 4, 3, 4);
            consultar_por_adotar.Name = "consultar_por_adotar";
            consultar_por_adotar.Size = new Size(168, 91);
            consultar_por_adotar.TabIndex = 202;
            consultar_por_adotar.Text = "Consultar Animais por Adotar";
            consultar_por_adotar.UseVisualStyleBackColor = true;
            consultar_por_adotar.Click += consultar_por_adotar_Click;
            // 
            // consultar_adotados
            // 
            consultar_adotados.Location = new Point(527, 95);
            consultar_adotados.Margin = new Padding(3, 4, 3, 4);
            consultar_adotados.Name = "consultar_adotados";
            consultar_adotados.Size = new Size(168, 91);
            consultar_adotados.TabIndex = 203;
            consultar_adotados.Text = "Consultar Animais Adotados";
            consultar_adotados.UseVisualStyleBackColor = true;
            consultar_adotados.Click += consultar_adotados_Click;
            // 
            // texto_animal_morto
            // 
            texto_animal_morto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            texto_animal_morto.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            texto_animal_morto.Location = new Point(7, 555);
            texto_animal_morto.Margin = new Padding(5, 5, 5, 1);
            texto_animal_morto.Name = "texto_animal_morto";
            texto_animal_morto.Size = new Size(530, 56);
            texto_animal_morto.TabIndex = 204;
            texto_animal_morto.Text = "Insira o número de chegada do animal para remover animal que faleceu\r\n\r\n \r\n\r\n\r\n";
            // 
            // num_animal_morto
            // 
            num_animal_morto.Location = new Point(545, 553);
            num_animal_morto.Margin = new Padding(3, 4, 3, 4);
            num_animal_morto.Name = "num_animal_morto";
            num_animal_morto.Size = new Size(81, 27);
            num_animal_morto.TabIndex = 205;
            // 
            // submit_button_2
            // 
            submit_button_2.Location = new Point(649, 553);
            submit_button_2.Margin = new Padding(3, 4, 3, 4);
            submit_button_2.Name = "submit_button_2";
            submit_button_2.Size = new Size(94, 32);
            submit_button_2.TabIndex = 206;
            submit_button_2.Text = "Ok";
            submit_button_2.UseVisualStyleBackColor = true;
            submit_button_2.Click += submit_button_2_Click;
            // 
            // Viewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(914, 600);
            Controls.Add(submit_button_2);
            Controls.Add(num_animal_morto);
            Controls.Add(texto_animal_morto);
            Controls.Add(consultar_adotados);
            Controls.Add(consultar_por_adotar);
            Controls.Add(submit_button);
            Controls.Add(num_animal);
            Controls.Add(texto_animal);
            Controls.Add(voltar_atras);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Viewer";
            Text = "Animais";
            Load += Viewer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button voltar_atras;
        internal Label texto_animal;
        internal TextBox num_animal;
        private Button submit_button;
        private Button consultar_por_adotar;
        private Button consultar_adotados;
        internal Label texto_animal_morto;
        internal TextBox num_animal_morto;
        private Button submit_button_2;
    }
}