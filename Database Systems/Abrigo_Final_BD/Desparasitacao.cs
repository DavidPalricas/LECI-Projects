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
    public partial class Desparasitacao : Form
    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Desparasitacao()
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

        private void adicionar_desparasitacao_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        // Verificar se o TextBox está vazio 
                        if (textBox.Text.Length == 0)
                        {

                            MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }
                DateTime data;
                if (!DateTime.TryParse(data_desparasitacao.Text, out data) && data_desparasitacao.Text.Length > 0)
                {
                    MessageBox.Show("Por favor insira uma data válida.");
                    return;
                }


                int num_chegada_animal = Convert.ToInt32(animal_input.Text);

                if (!find_animal(num_chegada_animal))
                {
                    MessageBox.Show("Animal com número de chegada não econtrado  " + num_chegada_animal + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Desparasitacao (Desparasitacao_data,Tipo_Desparasitacao, Desparasitante) VALUES (@data, @tipo, @desparasitante)", CN);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@tipo", tipo_desparasitcao.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@desparasitante", tipo_desparasitante.Text);
                cmd.ExecuteNonQuery();


                SqlCommand cmd2 = new SqlCommand("INSERT INTO Projeto_TEM_Desparasitacao (Num_chegada, Ddata) VALUES (@num_chegada, @data)", CN);
                cmd2.Parameters.AddWithValue("@num_chegada", num_chegada_animal);
                cmd2.Parameters.AddWithValue("@data", data);
                cmd2.ExecuteNonQuery();

                MessageBox.Show($"Desparasitante adicionado com sucesso! Tipo: {tipo_desparasitcao.SelectedItem.ToString()}");
                this.Hide();
                Abrigo abrigo = new Abrigo();
                abrigo.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar a desparasitação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();

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
    }
}
