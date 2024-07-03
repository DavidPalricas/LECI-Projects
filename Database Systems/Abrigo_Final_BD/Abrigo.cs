using System.Data;
using static Abrigo_Final_BD.Animal;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Abrigo_Final_BD
{
    public partial class Abrigo : Form
    {

        private SqlConnection CN;

        public Abrigo()
        {
            InitializeComponent();
            CN = ConnectionManager.getSGBDConnection();
            CN.Open();

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Abrigo", CN);


            int count = (int)countQuery.ExecuteScalar(); //Obtém o valor de COUNT(*)


            // Preenche os dados do abrigo quando é inicializado a primeira vez
            if (count == 0)
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Abrigo (Nome, Endereco, Telefone,Email) VALUES (@nome, @endereco, @telefone, @email)", CN);

                cmd.Parameters.AddWithValue("@nome", "Abrigo de Carinho");
                cmd.Parameters.AddWithValue("@endereco", "Praia de Mira, Portugal");
                cmd.Parameters.AddWithValue("@telefone", "+351");
                cmd.Parameters.AddWithValue("@email", "abrigo_de_carinho@outlook.com");
                cmd.ExecuteNonQuery();

            }
        }
        public static class ConnectionManager
        {
            public static SqlConnection getSGBDConnection()
            {
                return new SqlConnection(SQLConnectionString);
            }
        }

        private void adicionar_funcionario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Funcionario funcionario = new Funcionario();
            funcionario.Show();
        }

        private void adicionar_animal_Click(object sender, EventArgs e)
        {
            //using (SqlCommand command = new SqlCommand())
            //{
            this.Hide();
            Animal animal = new Animal();
            animal.Show();
            //}
        }

        private void adicionar_tratador_Click(object sender, EventArgs e)
        {
            //using (SqlCommand command = new SqlCommand())
            //{
            this.Hide();
            Tratador tratador = new Tratador();
            tratador.Show();
            //}
        }

        private void add_servico_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();
        }
    }
}