using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abrigo_Final_BD
{
    public partial class Pessoas : Form

    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;
        private string tipo_pessoa = "";
        public Pessoas()
        {
            InitializeComponent();
            CN = ConnectionManager.getSGBDConnection();
        }

        public static class ConnectionManager
        {
            public static SqlConnection getSGBDConnection()
            {
                return new SqlConnection(SQLConnectionString);
            }
        }



        private void Pessoas_Load(object sender, EventArgs e)
        {
            viewer.Visible = false;


            submit_button.Visible = false;
            submit_button.Enabled = false;

            texto_pessoa.Visible = false;

            num_pessoa.Visible = false;
            num_pessoa.Enabled = false;

        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();
        }

        private void consultar_funcionario_Click(object sender, EventArgs e)
        {
            mostrar_view();

            CN.Open();

            // Consulta para exibir os dados
            SqlCommand cmd = new SqlCommand("SELECT * FROM SHOW_Funcionario;", CN);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            // Definir a fonte de dados do DataGridView
            viewer.DataSource = dt;

            CN.Close();
        }




        private void mostrar_view()
        {
            // Desátiva todos os botões
            consultar_adotante.Enabled = false;
            consultar_funcionario.Enabled = false;
            consultar_doador.Enabled = false;
            consultar_tratador.Enabled = false;

            //Remover a visibilidade dos botões
            consultar_adotante.Visible = false;
            consultar_funcionario.Visible = false;
            consultar_doador.Visible = false;
            consultar_tratador.Visible = false;

            viewer.Visible = true; //Mostrar a view do respetivo serviço
        }

        private void consultar_doador_Click(object sender, EventArgs e)
        {
            tipo_pessoa = "doador";
            mostrar_view();

            CN.Open();

            // Criação da view (uma única vez)


            // Consulta para exibir os dados
            SqlCommand cmd = new SqlCommand("SELECT * FROM SHOW_DOADORES;", CN);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            // Definir a fonte de dados do DataGridView
            viewer.DataSource = dt;

            CN.Close();


            texto_pessoa.Visible = true;
            texto_pessoa.Text = "Insire o número do doador para ver as doações*";
            num_pessoa.Visible = true;
            num_pessoa.Enabled = true;
            submit_button.Visible = true;
            submit_button.Enabled = true;

        }

        private void consultar_tratador_Click(object sender, EventArgs e)
        {

            tipo_pessoa = "tratador";

            mostrar_view();

            CN.Open();


            // Consulta para exibir os dados
            SqlCommand cmd = new SqlCommand("SELECT * FROM SHOW_TRATADOR;", CN);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            // Definir a fonte de dados do DataGridView
            viewer.DataSource = dt;

            CN.Close();


            texto_pessoa.Visible = true;
            texto_pessoa.Text = "Insire o número do tratador para ver os tratamentos*";
            num_pessoa.Visible = true;
            num_pessoa.Enabled = true;
            submit_button.Visible = true;
            submit_button.Enabled = true;

        }

        private void consultar_adotante_Click(object sender, EventArgs e)
        {
            mostrar_view();

            tipo_pessoa = "adotante";

            CN.Open();


            // Consulta para exibir os dados
            SqlCommand cmd = new SqlCommand("SELECT * FROM SHOW_ADOTANTE;", CN);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            // Definir a fonte de dados do DataGridView
            viewer.DataSource = dt;

            CN.Close();


            texto_pessoa.Visible = true;
            texto_pessoa.Text = "Insire o número do adotante para ver as suas adoções*";
            num_pessoa.Visible = true;
            num_pessoa.Enabled = true;
            submit_button.Visible = true;
            submit_button.Enabled = true;
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();
                if (num_pessoa.Text.Length == 0)
                {
                    MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (tipo_pessoa == "tratador")
                {
                    Show_Tratamentos();

                }


                else if (tipo_pessoa == "doador")
                {
                    Show_Doacoes();
                }
                else if (tipo_pessoa == "adotante")
                {
                    Show_Adocoes();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta das pessoas" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }
        }
        private bool find_tratador(int tratador)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Tratador WHERE Num_tratador = @tratador", CN);
            cmd.Parameters.AddWithValue("@tratador", tratador);


            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }


        private bool find_doador(int doador)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Doador WHERE Num_Doador = @doador", CN);
            cmd.Parameters.AddWithValue("@doador", doador);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }


        private bool find_adotante(int adotante)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Adotante WHERE Num_Adotante = @adotante", CN);
            cmd.Parameters.AddWithValue("@adotante", adotante);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }


        private void Show_Tratamentos()
        {
            int n_tratador = Convert.ToInt32(num_pessoa.Text);

            if (!find_tratador(n_tratador))
            {
                MessageBox.Show("Tratador número " + n_tratador + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            viewer.DataSource = null;

    
            SqlCommand cmd = new SqlCommand("SELECT Tipo_Tratamento,Tratamento_Data,Nome_Animal, Num_chegada FROM SHOW_TRATAMENTOS_TRATADOR WHERE Num_tratador = @NumTratador;", CN); //Filtrar a view pelo número de chegada do animal pretendido
            cmd.Parameters.AddWithValue("@NumTratador", n_tratador);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());


            viewer.DataSource = dt; // Mostrar a view no grid


            string n_tratamentos = @"
                      DECLARE @n_tratamentos INT;

                      DECLARE countCursor CURSOR FOR
                          SELECT COUNT(*) AS N_TRATAMENTOS
                          FROM SHOW_TRATAMENTOS_TRATADOR WHERE Num_tratador = @Num_Tratador;

              
                      OPEN countCursor;


                      FETCH NEXT FROM countCursor INTO @n_tratamentos;

            
                      CLOSE countCursor;
                      DEALLOCATE countCursor;
                      SELECT @n_tratamentos AS TRATAMENTOS";


            SqlCommand show_tratamentos = new SqlCommand(n_tratamentos, CN);

            show_tratamentos.Parameters.AddWithValue("@Num_Tratador", n_tratador);





            SqlDataReader reader = show_tratamentos.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show("Número de tratamentos efetuados: " + reader["TRATAMENTOS"].ToString(), "Número de tratamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            reader.Close();

            show_tratamentos.ExecuteNonQuery();


        }

        private void Show_Doacoes()
        {
            int n_doador = Convert.ToInt32(num_pessoa.Text);

            if (!find_doador(n_doador))
            {
                MessageBox.Show("Doador número " + n_doador + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            viewer.DataSource = null;

            SqlCommand cmd = new SqlCommand("SELECT Tipo_Doacao, Quantidade, Data FROM SHOW_DOACOES_DOADOR WHERE  Num_Doador  = @NumDoador;", CN); //Filtrar a view pelo número de chegada do animal pretendido
            cmd.Parameters.AddWithValue("@NumDoador", n_doador);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            


            viewer.DataSource = dt; // Mostrar a view no grid


            string n_doacoes = @"
                      DECLARE @n_doacoes INT;

                    DECLARE countCursor CURSOR FOR
                        SELECT COUNT(*) AS N_DOACOES
                        FROM SHOW_DOACOES_DOADOR WHERE Num_doador = @NumDoador;

              
                    OPEN countCursor;

                  
                    FETCH NEXT FROM countCursor INTO @n_doacoes;

            
                    CLOSE countCursor;
                    DEALLOCATE countCursor;
                    SELECT @n_doacoes AS DOACOES";


            SqlCommand show_doacoes = new SqlCommand(n_doacoes, CN);

            show_doacoes.Parameters.AddWithValue("@NumDoador", n_doador);





            SqlDataReader reader = show_doacoes.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show("Número de doações efetuadas: " + reader["DOACOES"].ToString(), "Número de doações", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            reader.Close();

            show_doacoes.ExecuteNonQuery();

        }


        private void Show_Adocoes()
        {

            int n_adotante = Convert.ToInt32(num_pessoa.Text);

            if (!find_adotante(n_adotante))
            {
                MessageBox.Show("Adotante número " + n_adotante + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            viewer.DataSource = null;

  



            SqlCommand cmd = new SqlCommand("SELECT Nome_Animal, Data_Adocao FROM SHOW_ADOCOES_ADOTANTE WHERE Num_Adotante = @NumAdotante;", CN); //Filtrar a view pelo número de chegada do animal pretendido
            cmd.Parameters.AddWithValue("@NumAdotante", n_adotante);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            viewer.DataSource = dt;


            string n_adocoes = @"
                     DECLARE @n_adocoes INT;

                      DECLARE countCursor CURSOR FOR
                          SELECT COUNT(*) AS N_Adocoes
                          FROM SHOW_ADOCOES_ADOTANTE WHERE Num_adotante = @Num_Adotante;

              
                      OPEN countCursor;


                      FETCH NEXT FROM countCursor INTO @n_adocoes;

            
                      CLOSE countCursor;
                      DEALLOCATE countCursor;
                      SELECT @n_adocoes AS ADOCOES";


            SqlCommand show_adocoes = new SqlCommand(n_adocoes, CN);

            show_adocoes.Parameters.AddWithValue("@Num_Adotante", n_adotante);





            SqlDataReader reader = show_adocoes.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show("Número de adoções efetuadas: " + reader["ADOCOES"].ToString(), "Número de adoções", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            reader.Close();

            show_adocoes.ExecuteNonQuery();


        }


    }


}



