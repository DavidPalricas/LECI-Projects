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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Abrigo_Final_BD.Abrigo;

namespace Abrigo_Final_BD
{
    public partial class Viewer : Form
    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Viewer()
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

        private void Viewer_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;

            texto_animal.Visible = false;

            num_animal.Visible = false;
            num_animal.Enabled = false;

            submit_button.Visible = false;
            submit_button.Enabled = false;

            texto_animal_morto.Visible = false;

            num_animal_morto.Visible = false;
            num_animal_morto.Enabled = false;

            submit_button_2.Visible = false;
            submit_button_2.Enabled = false;

        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicos servicos = new Servicos();
            servicos.Show();
        }



        private void submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();

                if (num_animal.Text.Length == 0)
                {
                    MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                long num_chegada_animal = Convert.ToInt32(num_animal.Text);
                show_animal_dados(num_chegada_animal);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta dos animal: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }


        }

        private bool find_animal(long animal)
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


        private void show_animal_dados(long num_chegada_animal)
        {

            if (!find_animal(num_chegada_animal))
            {
                MessageBox.Show("Animal com número de chegada não econtrado  " + num_chegada_animal + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return;
            }

            dataGridView1.DataSource = null; //Limpa o conteúdo da grid


            SqlCommand cmd = new SqlCommand("SELECT Tipo_Tratamento,Tratamento_Data ,Num_Tratador, Vacina_Data, Dose, Tipo_Vacina, Patologia, Medicacao, Historial_Clinico_data,Tipo_Desparasitacao,Desparasitante, Desparasitacao_Data FROM SHOW_ANIMAL WHERE Num_Chegada = @NumChegadaAnimal;", CN); //Filtrar a view pelo número de chegada do animal pretendido
            cmd.Parameters.AddWithValue("@NumChegadaAnimal", num_chegada_animal);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());


            dataGridView1.DataSource = dt; // Mostrar a view no grid



        }

        private void consultar_por_adotar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultar_Animais();

                texto_animal_morto.Visible = true;
                num_animal_morto.Visible = true;
                num_animal_morto.Enabled = true;
                submit_button_2.Visible = true;
                submit_button_2.Enabled = true;
                CN.Open();

                SqlCommand cmd = new SqlCommand("SELECT  Num_chegada, Nome_Animal, Altura, Idade, Peso, Origem_Historia, Data_Entrada, Numero_Microchip FROM SHOW_ANIMALS WHERE Adotante_NIF IS NULL;", CN);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());


                dataGridView1.DataSource = dt; // Mostrar a view no grid

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta dos animais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

        }




        private void consultar_adotados_Click(object sender, EventArgs e)
        {
            try
            {
                Consultar_Animais();

                CN.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM SHOW_ANIMALS WHERE Adotante_NIF IS NOT NULL;", CN);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());


                dataGridView1.DataSource = dt; // Mostrar a view no grid

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta dos animais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

        }



        private void Consultar_Animais()
        {
            dataGridView1.Visible = true;

            texto_animal.Visible = true;

            num_animal.Visible = true;
            num_animal.Enabled = true;

            submit_button.Visible = true;
            submit_button.Enabled = true;


            consultar_adotados.Enabled = false;
            consultar_adotados.Visible = false;

            consultar_por_adotar.Enabled = false;
            consultar_por_adotar.Visible = false;


        }

        private void submit_button_2_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();

                if (num_animal_morto.Text.Length == 0)
                {
                    MessageBox.Show($"Campos obrigatório(*) não preenchidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                long num_chegada_animal = Convert.ToInt32(num_animal_morto.Text);

                if (!find_animal(num_chegada_animal))
                {
                    MessageBox.Show("Animal com número de chegada não econtrado  " + num_chegada_animal + " não está registado na nossa base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    return;
                }

                SqlCommand cmd = new SqlCommand("RemoveAnimal", CN);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Num_chegada", num_chegada_animal);

                cmd.ExecuteNonQuery();


                                //Para dar Update a tabela quando o Animal é removido
                SqlCommand cmd2 = new SqlCommand("SELECT  Num_chegada, Nome_Animal, Altura, Idade, Peso, Origem_Historia, Data_Entrada, Numero_Microchip FROM SHOW_ANIMALS WHERE Adotante_NIF IS NULL;", CN);
                DataTable dt = new DataTable();
                dt.Load(cmd2.ExecuteReader());


                dataGridView1.DataSource = dt; // Mostrar a view no grid

                MessageBox.Show("Animal removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na consulta dos animal: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }
        }
    }




}
