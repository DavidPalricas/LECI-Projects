using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Abrigo_Final_BD
{
    public partial class Tratador : Form

    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        private string operation = "";

        public Tratador()
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


        private void Tratador_Load(object sender, EventArgs e)
        {
            Enable_Disable_Stuff(false);

            num.Visible = false;
            num_input.Visible = false;
            num_input.Enabled = false;




        }

        private void adicionar_tratador_Click(object sender, EventArgs e)
        {


            operation = "adicionar";

            Enable_Disable_Stuff(true);

            adicionar_tratador.Visible = false;
            adicionar_tratador.Enabled = false;

            remover_tratador.Visible=false;
            remover_tratador.Enabled = false;

            submit_button.Text = "Adicionar Tratador";
           
        }

        private void remover_tratador_Click(object sender, EventArgs e)
        {
            operation = "remover";

            adicionar_tratador.Visible = false;
            adicionar_tratador.Enabled = false;

            remover_tratador.Visible = false;
            remover_tratador.Enabled = false;


            submit_button.Visible = true;
            submit_button.Enabled = true;

            num.Visible = true;
            num_input.Visible = true;
            num_input.Enabled = true;


            submit_button.Text = "Remover Tratador";

        }


        private int getTrataNum()
        {
            int trata_num = 1;

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Tratador", CN);


            int count = (int)countQuery.ExecuteScalar();

            if (count > 0)
            {
                SqlCommand highest_func_num = new SqlCommand("SELECT MAX(Num_tratador) FROM Projeto_Tratador", CN);

                trata_num = (int)highest_func_num.ExecuteScalar() + 1;

            }


            return trata_num;


        }



        private void submit_button_Click(object sender, EventArgs e)
        {
            if (operation == "adicionar")
            {
                AddTratador();

            }
            else if (operation == "remover")
            {
                RemoveTratador();
            }

        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            //Ir para a página principal
            this.Hide();
            Abrigo abrigo = new Abrigo();
            abrigo.Show();
        }

       



        private void Enable_Disable_Stuff(bool cond)
        {
            nif.Visible = cond;
            nif_input.Visible = cond;
            nif_input.Enabled = cond;

            telefone.Visible = cond;
            telefone_input.Visible = cond;
            telefone_input.Enabled = cond;

            nome.Visible = cond;
            nome_input.Visible = cond;
            nome_input.Enabled = cond;

            endereco.Visible = cond;
            endereco_input.Visible = cond;
            endereco_input.Enabled = cond;

            mail.Visible = cond;
            mail_input.Visible = cond;
            mail_input.Enabled = cond;

            horario.Visible = cond;
            horario_input.Visible = cond;
            horario_input.Enabled = cond;


            submit_button.Visible = cond;
            submit_button.Enabled = cond;
        }


   



        private void AddTratador()
        {
            try
            {
                CN.Open();

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        // Verificar se o TextBox está vazio e se o nome não é "Origem_Historia"
                        if (textBox.Text.Length == 0 && textBox.Name != "num_input")
                        {

                            MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        }
                    }
                }

                DateTime horarioDateTime;
                if (!DateTime.TryParse(horario_input.Text, out horarioDateTime) && horario_input.Text.Length > 0)
                {
                    MessageBox.Show("Formato de horário inválido. Por favor, insira uma data válida. (Ex: 12:30)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int trata_num = getTrataNum();



                


                SqlCommand cmd = new SqlCommand("AddTratador", CN);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Num_Tratador", trata_num);
                cmd.Parameters.AddWithValue("@NIF_Tratador", Convert.ToInt32(nif_input.Text));
                cmd.Parameters.AddWithValue("@Telefone", telefone_input.Text);
                cmd.Parameters.AddWithValue("@Nome", nome_input.Text);
                cmd.Parameters.AddWithValue("@Endereco", endereco_input.Text);
                cmd.Parameters.AddWithValue("@Email", mail_input.Text);
                cmd.Parameters.AddWithValue("@Horario ", horarioDateTime);
                cmd.Parameters.AddWithValue("@Abrigo_Email", "abrigo_de_carinho@outlook.com");




                SqlParameter success_param = new SqlParameter("@Success", SqlDbType.Bit);
                success_param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(success_param);

                cmd.ExecuteNonQuery();
                bool success = (bool)success_param.Value;



                if (success)
                {

                    MessageBox.Show("Tratador adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Ir para a página principal
                    this.Hide();
                    Abrigo abrigo = new Abrigo();
                    abrigo.Show();
                }
                else
                {
                    MessageBox.Show("Tratador com NIF " + nif_input.Text + " já se econtra registado");
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar o funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

        }



        private void RemoveTratador()
        {

            try
            {
                CN.Open();

             
               if (num_input.Text.Length == 0)
               {
                  MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
               }
                    
                

                int num_tratador = Convert.ToInt32(num_input.Text);

           

                if (!find_tratador(num_tratador))
                {
                    MessageBox.Show("Tratador com número " + num_tratador + " não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand("SELECT NIF_Tratador FROM Projeto_Tratador WHERE Num_Tratador = @num;",CN);
                cmd.Parameters.AddWithValue("@num", num_tratador);

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                long NIF_Tratador = reader.GetInt64(reader.GetOrdinal("NIF_Tratador"));
                reader.Close();





              
                
              SqlCommand cmd2 = new SqlCommand("RemoveTratador", CN);
              cmd2.CommandType = CommandType.StoredProcedure;
              cmd2.Parameters.AddWithValue("@NIF_Tratador", NIF_Tratador);

              cmd2.ExecuteNonQuery();

          





               MessageBox.Show("Tratador removido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
               this.Hide();
               Servicos servicos = new Servicos();
               servicos.Show();
                
              

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover tratador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

        }

        private Boolean find_tratador(int func)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Tratador WHERE Num_Tratador = @func", CN);

            cmd.Parameters.AddWithValue("@func", func);

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
