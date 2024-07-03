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
    public partial class Doador : Form
    {

        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Doador()
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

        }

        private void adicionar_doador_Click(object sender, EventArgs e)
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


                int doador_id = getDoadorID();


                SqlCommand cmd = new SqlCommand("INSERT INTO PROJETO_Doador (ID,NIF,Telefone,Nome,Endereco,Email) VALUES (@id,@nif,@telefone,@nome,@endereco,@email)", CN);

                cmd.Parameters.AddWithValue("@id", doador_id);
                cmd.Parameters.AddWithValue("@nif", Convert.ToInt32(nif_input.Text));
                cmd.Parameters.AddWithValue("@telefone", telefone_input.Text);
                cmd.Parameters.AddWithValue("@nome", nome_input.Text);
                cmd.Parameters.AddWithValue("@endereco", endereco_input.Text);
                cmd.Parameters.AddWithValue("@email", mail_input.Text);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Doador adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ir para a página principal
                this.Hide();
                Abrigo abrigo = new Abrigo();
                abrigo.Show();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar o doador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }


        }



        private int getDoadorID()
        {
            int DoadorID = 1;

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Doador", CN);


            int count = (int)countQuery.ExecuteScalar();

            if (count > 0)
            {
                SqlCommand highest_doadorID = new SqlCommand("SELECT MAX(ID) From Projeto_Doador", CN);

                DoadorID = (int)highest_doadorID.ExecuteScalar() + 1;

            }

            return DoadorID;


        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            //Ir para a página principal
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();
        }
    }
}