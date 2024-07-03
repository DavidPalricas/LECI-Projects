using System.Data;


namespace Abrigo_Final_BD
{
    partial class Abrigo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abrigo));
            nome = new Label();
            Label2 = new Label();
            Label1 = new Label();
            pictureBox1 = new PictureBox();
            adicionar_animal = new Button();
            adicionar_tratador = new Button();
            adicionar_funcionario = new Button();
            label3 = new Label();
            add_servico = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // nome
            // 
            nome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nome.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            nome.Location = new Point(202, 161);
            nome.Margin = new Padding(4, 1, 4, 4);
            nome.Name = "nome";
            nome.Size = new Size(158, 19);
            nome.TabIndex = 157;
            nome.Text = "Abrigo de Carinho";
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
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(950, 558);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 164;
            pictureBox1.TabStop = false;
            // 
            // adicionar_animal
            // 
            adicionar_animal.Location = new Point(96, 49);
            adicionar_animal.Name = "adicionar_animal";
            adicionar_animal.Size = new Size(147, 68);
            adicionar_animal.TabIndex = 165;
            adicionar_animal.Text = "Adicionar Animal";
            adicionar_animal.UseVisualStyleBackColor = true;
            adicionar_animal.Click += adicionar_animal_Click;
            // 
            // adicionar_tratador
            // 
            adicionar_tratador.Location = new Point(710, 49);
            adicionar_tratador.Name = "adicionar_tratador";
            adicionar_tratador.Size = new Size(148, 68);
            adicionar_tratador.TabIndex = 166;
            adicionar_tratador.Text = "Gerir Tratadores";
            adicionar_tratador.UseVisualStyleBackColor = true;
            adicionar_tratador.Click += adicionar_tratador_Click;
            // 
            // adicionar_funcionario
            // 
            adicionar_funcionario.Location = new Point(403, 49);
            adicionar_funcionario.Name = "adicionar_funcionario";
            adicionar_funcionario.Size = new Size(147, 68);
            adicionar_funcionario.TabIndex = 167;
            adicionar_funcionario.Text = "Gerir Funcionários";
            adicionar_funcionario.UseVisualStyleBackColor = true;
            adicionar_funcionario.Click += adicionar_funcionario_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            label3.Location = new Point(96, 23);
            label3.Margin = new Padding(4, 1, 4, 4);
            label3.Name = "label3";
            label3.Size = new Size(762, 19);
            label3.TabIndex = 171;
            label3.Text = "ABRIGO DE CARINHO";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // add_servico
            // 
            add_servico.Location = new Point(402, 490);
            add_servico.Name = "add_servico";
            add_servico.Size = new Size(148, 68);
            add_servico.TabIndex = 172;
            add_servico.Text = "Serviços";
            add_servico.Click += add_servico_Click;
            // 
            // Abrigo
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 557);
            Controls.Add(add_servico);
            Controls.Add(label3);
            Controls.Add(adicionar_funcionario);
            Controls.Add(adicionar_tratador);
            Controls.Add(adicionar_animal);
            Controls.Add(pictureBox1);
            Controls.Add(nome);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Abrigo";
            Text = "Abrigo de Carinho";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        internal System.Windows.Forms.Label nome;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button adicionar_animal;
        private System.Windows.Forms.Button adicionar_tratador;
        private System.Windows.Forms.Button adicionar_funcionario;
        internal Label label3;
        private Button add_servico;
    }
}

