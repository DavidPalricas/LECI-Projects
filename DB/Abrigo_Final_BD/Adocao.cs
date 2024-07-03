using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static Abrigo_Final_BD.Abrigo;

namespace Abrigo_Final_BD
{
    public partial class Adocao : Form
    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Adocao()
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

        private void adicionar_adocao_Click(object sender, EventArgs e)
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
                            return; // Use return instead of break to stop further processing
                        }
                    }
                }

                int num_chegada_animal = Convert.ToInt32(numero_animal.Text);

                if (!find_animal(num_chegada_animal))
                {
                    MessageBox.Show("Animal com número de chegada não econtrado  " + num_chegada_animal + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime data;
                if (!DateTime.TryParse(adocao_input.Text, out data) && adocao_input.Text.Length > 0)
                {
                    MessageBox.Show("Formato de horário inválido. Por favor, insira uma data válida. (Ex: 2024-05-27)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = mail_input.Text;
                if (!email.Contains("@") && !email.Contains("."))
                {
                    MessageBox.Show("Email inválido. Por favor insira um email válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string telefone = telefone_input.Text;
                if (!telefone.StartsWith("91") && !telefone.StartsWith("92") && !telefone.StartsWith("93") && !telefone.StartsWith("96") && telefone.Length != 9)
                {
                    MessageBox.Show("Número de telefone inválido. Por favor insira um número de telefone válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                long nif = Convert.ToInt64(nif_adotante.Text);


               

             



                if (!Adotante_Existe(nif))
                {
                    int adotID = getAdotID();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Adotante (Num_Adotante, NIF_Adotante, Telefone, Nome, Endereco, Email, Data_Adocao) VALUES (@id, @nif, @telefone, @nome, @endereco, @email, @data)", CN);

                    cmd.Parameters.AddWithValue("@id", adotID);
                    cmd.Parameters.AddWithValue("@nif",nif);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@nome", nome_input.Text);
                    cmd.Parameters.AddWithValue("@endereco", endereco_input.Text);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@data", data);


                    cmd.ExecuteNonQuery();
                }


                SqlCommand cmd2 = new SqlCommand("AtualizarAdotanteNIF ", CN);

                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@NIF_Adotante", nif);
                cmd2.Parameters.AddWithValue("@Num_chegada", numero_animal.Text);


                cmd2.ExecuteNonQuery();

                MessageBox.Show("Animal adotado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
             
                this.Hide();
                Servicos servicos = new Servicos();
                servicos.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar adoção: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private int getAdotID()
        {
            int adotID = 1;

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Adotante", CN);


            int count = (int)countQuery.ExecuteScalar();

            if (count > 0)
            {
                SqlCommand highest_func_num = new SqlCommand("SELECT MAX(Num_Adotante) FROM Projeto_Adotante", CN);

                adotID = (int)highest_func_num.ExecuteScalar() + 1;

            }

            return adotID;
        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();

        }


        private bool Adotante_Existe(long nif)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) From Projeto_Adotante WHERE NIF_Adotante = @nif",CN);
            cmd.Parameters.AddWithValue("@nif", nif);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();

                return true;
            }
            reader.Close ();


            return false;


            
        }
    }
}
