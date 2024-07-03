using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Azure;
using Microsoft.Data.SqlClient;
using static Abrigo_Final_BD.Abrigo;

namespace Abrigo_Final_BD
{
    public partial class Funcionario : Form
    {

        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;
        private string operation = "";

        public Funcionario()
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



        private void Funcionario_Load(object sender, EventArgs e)
        {

            Enable_Disable_Stuff(false);

            num.Visible = false;
            num_input.Visible = false;
            num_input.Enabled = false;
           

        }
        private void nome_input_TextChanged(object sender, EventArgs e)
        {
            String nome = nome_input.Text;
        }


        private void horario_input_TextChanged(object sender, EventArgs e)
        {
            String horario = horario_input.Text;

            DateTime horarioDateTime;

            DateTime.TryParse(horario, out horarioDateTime);
        }

        private void endereco_input_TextChanged(object sender, EventArgs e)
        {
            String endereco = endereco_input.Text;
        }

        private void mail_input_TextChanged(object sender, EventArgs e)
        {
            String mail = mail_input.Text;
        }

        private void nif_input_TextChanged(object sender, EventArgs e)
        {
            int NIF = Convert.ToInt32(nif_input.Text);
        }

        private void telefone_input_TextChanged(object sender, EventArgs e)
        {
            String telefone = telefone_input.Text;
        }

        private void adicionar_funcionario_Click(object sender, EventArgs e)
        {
            operation = "adicionar_funcionario";

            adicionar_funcionario.Visible = false;
            adicionar_funcionario.Enabled = false;

            remover_funcionario.Visible = false;
            remover_funcionario.Enabled = false;

            Enable_Disable_Stuff(true);
           
            submit_button.Text = "Adicionar Funcionário";

        }

        private void remover_funcionario_Click(object sender, EventArgs e)
        {
            operation = "remover_funcionario";


            submit_button.Visible = true;
            submit_button.Enabled = true;

            adicionar_funcionario.Visible = false;
            adicionar_funcionario.Enabled = false;

            remover_funcionario.Visible = false;
            remover_funcionario.Enabled = false;


            submit_button.Text = "Remover Funcionário";

            num.Visible = true;
            num_input.Visible = true;
            num_input.Enabled = true;

        }


        private int getFuncNum()
        {
            int funcNum = 1;

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM Projeto_Funcionario", CN);


            int count = (int)countQuery.ExecuteScalar();

            if (count > 0)
            {
                SqlCommand highest_func_num = new SqlCommand("SELECT MAX(Num_Func) FROM Projeto_Funcionario", CN);

                funcNum = (int)highest_func_num.ExecuteScalar() + 1;

            }

            return funcNum;


        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            //Ir para a página principal
            this.Hide();
            Abrigo abrigo = new Abrigo();
            abrigo.Show();
        }

  

        private void submit_button_Click(object sender, EventArgs e)
        { 
            if(operation == "adicionar_funcionario")
            {
                add_Funcionario();
            }
            else if(operation == "remover_funcionario")
            {
                remove_funcionario();
            }

        }



        private void add_Funcionario()
        {
            try
            {
                CN.Open();

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        // Verificar se o TextBox está vazio e se o nome não é "Origem_Historia"
                        if (textBox.Text.Length == 0 &&  textBox.Name != "num_input")
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

                int func_num = getFuncNum();

                
                SqlCommand cmd = new SqlCommand("AddFuncionario", CN);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Num_Func", func_num);
                cmd.Parameters.AddWithValue("@NIF_Func", Convert.ToInt32(nif_input.Text));
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

                    MessageBox.Show("Funcionário adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Ir para a página principal
                    this.Hide();
                    Abrigo abrigo = new Abrigo();
                    abrigo.Show();
                }
                else
                {
                    MessageBox.Show("Funcionário com NIF " +  nif_input.Text + " já se econtra registado");
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


        private void remove_funcionario()
        {
            try
            {
                CN.Open();


                if (num_input.Text.Length == 0)
                {
                    MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }


               int num_func = Convert.ToInt32(num_input.Text);

                if (!find_funcionario(num_func))
                {
                    MessageBox.Show("Funcionário com número "  + num_func +  " não econtrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand("RemoveFuncionario", CN);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Num_Func", num_func);


                cmd.ExecuteNonQuery();

              

        
                MessageBox.Show("Funcionário removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Ir para a página principal
                this.Hide();
                Abrigo abrigo = new Abrigo();
                abrigo.Show();
              
                 
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

        }

        private Boolean find_funcionario(int func)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Funcionario WHERE Num_Func = @func", CN);

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




        private void Enable_Disable_Stuff(bool cond)
        {
            nome.Visible = cond;
            nome_input.Visible = cond;
            nome_input.Enabled = cond;

            nif.Visible = cond;
            nif_input.Visible = cond;
            nif_input.Enabled = cond;

            telefone.Visible = cond;
            telefone_input.Visible = cond;
            telefone_input.Enabled = cond;

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

      
    }
}