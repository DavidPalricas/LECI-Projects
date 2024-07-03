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
    public partial class Adotante : Form
    {

        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Adotante()
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

        private void adicionar_adotante_Click(object sender, EventArgs e)
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

                if (!BigInteger.TryParse(nif_input.Text, out BigInteger nif) || nif <= 100000000 || nif >= 999999999)
                {
                    MessageBox.Show("NIF inválido. Deve ser um número inteiro maior que 100000000 e menor que 999999999.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(adocao_input.Text, out DateTime dataEntrada) && adocao_input.Text.Length > 0)
                {
                    MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida. (Ex: 2024-05-27)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int adotID = getAdotID();

                SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Adotante (Num_Adotante, NIF, Telefone, Nome, Endereco, Email, Data_Adocao) VALUES (@id, @nif, @telefone, @nome, @endereco, @email, @data)", CN);

                cmd.Parameters.AddWithValue("@id", adotID);
                cmd.Parameters.AddWithValue("@nif", nif);
                cmd.Parameters.AddWithValue("@telefone", telefone_input.Text);
                cmd.Parameters.AddWithValue("@nome", nome_input.Text);
                cmd.Parameters.AddWithValue("@endereco", endereco_input.Text);
                cmd.Parameters.AddWithValue("@email", mail_input.Text);
                cmd.Parameters.AddWithValue("@data", adocao_input.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Adotante adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ir para a página principal
                this.Hide();
                Abrigo abrigo = new Abrigo();
                abrigo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar o adotante: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }
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
    }



}