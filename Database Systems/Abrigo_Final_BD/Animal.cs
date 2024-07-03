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
    public partial class Animal : Form
    {

        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Animal()
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

        private void nome_input_TextChanged(object sender, EventArgs e)
        {
            String nome = nome_input.Text;
        }

        private void altura_input_TextChanged(object sender, EventArgs e)
        {
            decimal altura = Convert.ToDecimal(altura_input.Text);
        }

        private void microchips_input_TextChanged(object sender, EventArgs e)
        {
            int microchips = Convert.ToInt32(microchips_input.Text);
        }

        private void idade_input_TextChanged(object sender, EventArgs e)
        {
            int idade = Convert.ToInt32(idade_input.Text);
        }

        private void peso_input_TextChanged(object sender, EventArgs e)
        {
            decimal peso = Convert.ToDecimal(peso_input.Text);
        }

        private void data_input_TextChanged(object sender, EventArgs e)
        {
            DateTime data;
            DateTime.TryParse(data_input.Text, out data);
        }
        private void Origem_Historia_TextChanged(object sender, EventArgs e)
        {
            String historia = Origem_Historia.Text;
        }

        private void adicionar_animal_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        // Verificar se o TextBox está vazio e se o nome não é "Origem_Historia"
                        if (textBox.Text.Length == 0 && textBox.Name != "Origem_Historia")
                        {

                            MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }
                DateTime dataEntrada;
                if (!DateTime.TryParse(data_input.Text, out dataEntrada) && data_input.Text.Length > 0)
                {
                    MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida. (Ex: 2024-05-27)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                long num_chegada = getNum_Chegada();

                SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Animal (Num_chegada,Nome_Animal, Altura, Numero_Microchip, Idade, Peso, Data_Entrada, Origem_Historia,AEMAIL) VALUES (@num,@nome, @altura, @microchips, @idade, @peso, @data, @historia,@mail)", CN);
                cmd.Parameters.AddWithValue("@num", num_chegada);
                cmd.Parameters.AddWithValue("@nome", nome_input.Text);
                cmd.Parameters.AddWithValue("@altura", Convert.ToDecimal(altura_input.Text));
                cmd.Parameters.AddWithValue("@microchips", Convert.ToInt64(microchips_input.Text));
                cmd.Parameters.AddWithValue("@idade", Convert.ToInt32(idade_input.Text));
                cmd.Parameters.AddWithValue("@peso", Convert.ToDecimal(peso_input.Text));
                cmd.Parameters.AddWithValue("@data", dataEntrada);
                cmd.Parameters.AddWithValue("@historia", Origem_Historia.Text);
                cmd.Parameters.AddWithValue("@mail", "abrigo_de_carinho@outlook.com");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Animal adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ir para a página principal
                this.Hide();
                Abrigo abrigo = new Abrigo();
                abrigo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar o animal: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }
        }

        private void adicionar_adotante_Click(object sender, EventArgs e)
        {
            //using (SqlCommand command = new SqlCommand())
            //{
            this.Hide();
            Adotante Adotante = new Adotante();
            Adotante.Show();
            //}
        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            //Ir para a página principal
            this.Hide();
            Abrigo abrigo = new Abrigo();
            abrigo.Show();
        }

        private long getNum_Chegada()
        {
            long num_chegada = 1;

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Animal", CN);


            int count = (int)countQuery.ExecuteScalar();

            if (count > 0)
            {
                SqlCommand highest_func_num = new SqlCommand("SELECT MAX(Num_Chegada) FROM Projeto_Animal", CN);

                num_chegada = (long)highest_func_num.ExecuteScalar() + 1;

            }

            return num_chegada;


        }
    }
}