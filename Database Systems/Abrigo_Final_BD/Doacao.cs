using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static Abrigo_Final_BD.Abrigo;

namespace Abrigo_Final_BD
{
    public partial class Doacao : Form
    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Doacao()
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

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();
        }

        private void adicionar_doacao_Click(object sender, EventArgs e)
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

                DateTime data;
                if (!DateTime.TryParse(data_doacao.Text, out data) && data_doacao.Text.Length > 0)
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

                int doacaoID = getDoacaoID();

                SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Doacao (ID, Doador_NIF, Quantidade, Tipo_Doacao, Data) VALUES (@id, @nif, @quantidade, @tipo, @data)", CN);
                cmd.Parameters.AddWithValue("@id", doacaoID);
                cmd.Parameters.AddWithValue("@nif", Convert.ToInt64(nif_doador.Text));
                cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(quantidade_input.Text));
                cmd.Parameters.AddWithValue("@tipo", tipo_doacao.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@data", data);

                int doadorID = getDoadorID();

                SqlCommand cmd2 = new SqlCommand("INSERT INTO Projeto_Doador (Num_Doador, NIF_Doador, Telefone, Nome, Endereco, Email) VALUES (@id, @nif, @telefone, @nome, @endereco, @email)", CN);

                cmd2.Parameters.AddWithValue("@id", doadorID);
                cmd2.Parameters.AddWithValue("@nif", Convert.ToInt64(nif_doador.Text));
                cmd2.Parameters.AddWithValue("@telefone", telefone);
                cmd2.Parameters.AddWithValue("@nome", nome_input.Text);
                cmd2.Parameters.AddWithValue("@endereco", endereco_input.Text);
                cmd2.Parameters.AddWithValue("@email", email);

            
                MessageBox.Show("Doação efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
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

        private int getDoadorID()
        {
            int doadorID = 1;

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Doador", CN);


            int count = (int)countQuery.ExecuteScalar();

            if (count > 0)
            {
                SqlCommand highest_func_num = new SqlCommand("SELECT MAX(Num_Doador) FROM Projeto_Doador", CN);

                doadorID = (int)highest_func_num.ExecuteScalar() + 1;

            }

            return doadorID;
        }

        private int getDoacaoID()
        {
            int doacaoID = 1;

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Doacao", CN);


            int count = (int)countQuery.ExecuteScalar();

            if (count > 0)
            {
                SqlCommand highest_func_num = new SqlCommand("SELECT MAX(ID) FROM Projeto_Doacao", CN);

                doacaoID = (int)highest_func_num.ExecuteScalar() + 1;

            }

            return doacaoID;
        }
    }
}
