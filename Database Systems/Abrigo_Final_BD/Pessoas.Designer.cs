namespace Abrigo_Final_BD
{
    partial class Pessoas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pessoas));
            voltar_atras = new Button();
            viewer = new DataGridView();
            consultar_funcionario = new Button();
            consultar_tratador = new Button();
            consultar_doador = new Button();
            consultar_adotante = new Button();
            texto_pessoa = new Label();
            num_pessoa = new TextBox();
            submit_button = new Button();
            ((System.ComponentModel.ISupportInitialize)viewer).BeginInit();
            SuspendLayout();
            // 
            // voltar_atras
            // 
            voltar_atras.Location = new Point(12, 12);
            voltar_atras.Name = "voltar_atras";
            voltar_atras.Size = new Size(114, 24);
            voltar_atras.TabIndex = 192;
            voltar_atras.Text = "<-";
            voltar_atras.UseVisualStyleBackColor = true;
            voltar_atras.Click += voltar_atras_Click;
            // 
            // viewer
            // 
            viewer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewer.Location = new Point(10, 45);
            viewer.Name = "viewer";
            viewer.RowHeadersWidth = 51;
            viewer.Size = new Size(776, 250);
            viewer.TabIndex = 193;
            // 
            // consultar_funcionario
            // 
            consultar_funcionario.Location = new Point(47, 54);
            consultar_funcionario.Name = "consultar_funcionario";
            consultar_funcionario.Size = new Size(147, 68);
            consultar_funcionario.TabIndex = 194;
            consultar_funcionario.Text = "Consultar Funcionários";
            consultar_funcionario.UseVisualStyleBackColor = true;
            consultar_funcionario.Click += consultar_funcionario_Click;
            // 
            // consultar_tratador
            // 
            consultar_tratador.Location = new Point(419, 54);
            consultar_tratador.Name = "consultar_tratador";
            consultar_tratador.Size = new Size(147, 68);
            consultar_tratador.TabIndex = 195;
            consultar_tratador.Text = "Consultar Tratadores";
            consultar_tratador.UseVisualStyleBackColor = true;
            consultar_tratador.Click += consultar_tratador_Click;
            // 
            // consultar_doador
            // 
            consultar_doador.Location = new Point(232, 54);
            consultar_doador.Name = "consultar_doador";
            consultar_doador.Size = new Size(147, 68);
            consultar_doador.TabIndex = 196;
            consultar_doador.Text = "Consultar Doadores";
            consultar_doador.UseVisualStyleBackColor = true;
            consultar_doador.Click += consultar_doador_Click;
            // 
            // consultar_adotante
            // 
            consultar_adotante.Location = new Point(592, 54);
            consultar_adotante.Name = "consultar_adotante";
            consultar_adotante.Size = new Size(147, 68);
            consultar_adotante.TabIndex = 197;
            consultar_adotante.Text = "Consultar Adotantes";
            consultar_adotante.UseVisualStyleBackColor = true;
            consultar_adotante.Click += consultar_adotante_Click;
            // 
            // texto_pessoa
            // 
            texto_pessoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            texto_pessoa.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            texto_pessoa.Location = new Point(13, 310);
            texto_pessoa.Margin = new Padding(4, 4, 4, 1);
            texto_pessoa.Name = "texto_pessoa";
            texto_pessoa.Size = new Size(386, 25);
            texto_pessoa.TabIndex = 198;
            // 
            // num_pessoa
            // 
            num_pessoa.Location = new Point(419, 312);
            num_pessoa.Name = "num_pessoa";
            num_pessoa.Size = new Size(71, 23);
            num_pessoa.TabIndex = 201;
            // 
            // submit_button
            // 
            submit_button.Location = new Point(515, 312);
            submit_button.Name = "submit_button";
            submit_button.Size = new Size(82, 24);
            submit_button.TabIndex = 202;
            submit_button.Text = "Ok";
            submit_button.UseVisualStyleBackColor = true;
            submit_button.Click += submit_button_Click;
            // 
            // Pessoas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(796, 338);
            Controls.Add(submit_button);
            Controls.Add(num_pessoa);
            Controls.Add(texto_pessoa);
            Controls.Add(consultar_adotante);
            Controls.Add(consultar_doador);
            Controls.Add(consultar_tratador);
            Controls.Add(consultar_funcionario);
            Controls.Add(viewer);
            Controls.Add(voltar_atras);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Pessoas";
            Text = "Pessoas do Abrigo";
            Load += Pessoas_Load;
            ((System.ComponentModel.ISupportInitialize)viewer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button voltar_atras;
        private DataGridView viewer;
        private Button consultar_funcionario;
        private Button consultar_tratador;
        private Button consultar_doador;
        private Button consultar_adotante;
        internal Label texto_pessoa;
        internal TextBox num_pessoa;
        private Button submit_button;
    }
}