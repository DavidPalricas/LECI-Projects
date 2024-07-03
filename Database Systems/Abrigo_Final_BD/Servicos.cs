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
    public partial class Servicos : Form
    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        public Servicos()
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

        private void consultar_animal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Viewer viewer = new Viewer();
            viewer.Show();
        }

        private void adicionar_tratamento_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tratamento tratamento = new Tratamento();
            tratamento.Show();
        }

        private void adicionar_vacina_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vacina vacina = new Vacina();
            vacina.Show();
        }

        private void adicionar_desparatisacao_Click(object sender, EventArgs e)
        {
            this.Hide();
            Desparasitacao desparasitacao = new Desparasitacao();
            desparasitacao.Show();
        }

        private void adicionar_doacao_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doacao doacao = new Doacao();
            doacao.Show();
        }

        private void adicionar_adocao_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adocao adocao = new Adocao();
            adocao.Show();
        }

        private void voltar_atras_Click(object sender, EventArgs e)
        {
            //Ir para a página principal
            this.Hide();
            Abrigo abrigo = new Abrigo();
            abrigo.Show();
        }

        private void consultar_pessoas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pessoas pessoas = new Pessoas();
            pessoas.Show();
        }

        private void adicionar_doador_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doador doador = new Doador();
            doador.Show();
        }

        private void adicionar_adotante_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adotante adotante = new Adotante();
            adotante.Show();
        }

        private void adicionar_historial_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Historial historial = new Historial();
            historial.Show();
        }
    }
}
