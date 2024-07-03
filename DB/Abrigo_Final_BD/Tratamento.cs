using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static Abrigo_Final_BD.Abrigo;

namespace Abrigo_Final_BD
{
    public partial class Tratamento : Form
    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Tratamento()
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

        private void tipo_tratamento_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void getanimal_TextChanged(object sender, EventArgs e)
        {


        }
        private void getTratador_TextChanged(object sender, EventArgs e)
        {

        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();
        }

        private void adicionar_tratamento_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        // Verificar se o TextBox está vazio e se o nome não é "Origem_Historia"
                        if (textBox.Text.Length == 0)
                        {

                            MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }

                DateTime data;
                if (!DateTime.TryParse(data_tratamento.Text, out data) && data_tratamento.Text.Length > 0)
                {
                    MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida. (Ex: 2024-05-27)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int n_tratador = Convert.ToInt32(getTratador.Text);

                if (!find_tratador(n_tratador))
                {
                    MessageBox.Show("Tratador número " + n_tratador + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                int num_chegada_animal = Convert.ToInt32(getanimal.Text);

                if (!find_animal(num_chegada_animal))
                {
                    MessageBox.Show("Animal com número de chegada não econtrado  " + num_chegada_animal + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


              

                SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Tratamento (Data,Tipo_Tratamento) VALUES (@data,@tipo)", CN);

                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@tipo", tipo_tratamento.Text);
                cmd.ExecuteNonQuery();



                long nif = getTratadorNIF(n_tratador);

           
       
                SqlCommand cmdTratadorAnimal = new SqlCommand(
                    "INSERT INTO Projeto_Tem_Tratamento_Tratador_Animal (Tratador_NIF, Num_chegada, Tratamento_Data ) VALUES (@nif_tratador, @num_chegada, @tdata)",
                    CN
                );
                cmdTratadorAnimal.Parameters.AddWithValue("@nif_tratador", nif);
                cmdTratadorAnimal.Parameters.AddWithValue("@num_chegada", num_chegada_animal);
                cmdTratadorAnimal.Parameters.AddWithValue("@tdata", data);
                cmdTratadorAnimal.ExecuteNonQuery();




                MessageBox.Show("Tratamento adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ir para a página principal
                this.Hide();
                Abrigo abrigo = new Abrigo();
                abrigo.Show();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar o tratamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }
        }

        private bool find_animal(int animal)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Animal WHERE Num_chegada = @animal", CN);
            cmd.Parameters.AddWithValue("@animal", animal);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {   
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }


        private bool find_tratador(int tratador)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Tratador WHERE Num_tratador = @tratador", CN);
            cmd.Parameters.AddWithValue("@tratador", tratador);


            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {    reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }


        private long getTratadorNIF(int tratador)
        {
            SqlCommand cmd = new SqlCommand("SELECT NIF_Tratador FROM Projeto_Tratador WHERE Num_tratador = @tratador", CN);
            cmd.Parameters.AddWithValue("@tratador", tratador);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
           
            long nif = reader.GetInt64(0);
            reader.Close();
            return nif;
        }
    }
}
