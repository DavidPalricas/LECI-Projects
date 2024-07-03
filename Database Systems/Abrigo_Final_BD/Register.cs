using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Abrigo_Final_BD
{
    public partial class Register : Form
    {
        public static string SQLConnectionString = "data Source = tcp:mednat.ieeta.pt\SQLSERVER,8101; Initial Catalog = p10g6; uid = p10g6; password = NaoSei.666#; TrustServerCertificate=true";
        private SqlConnection CN;
        public Register()
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

        private void adicionar_registo_Click(object sender, EventArgs e)


        {   

            CN.Open();
            if (existsUsername(username_input.Text))
            {
                MessageBox.Show("Username já existe");
            }
            else if (!limitationsPassword(password_input.Text))
            {
                MessageBox.Show("Password não cumpre os requisitos");
            }
            else
            {
         

                
  

                SqlCommand cmd = new SqlCommand("INSERT INTO Projeto_Login (Username, Password) VALUES (@username, dbo.HashPassword(@password))", CN);
                cmd.Parameters.AddWithValue("@username", username_input.Text);
                cmd.Parameters.AddWithValue("@password", password_input.Text);
                cmd.ExecuteNonQuery();

       
       

           
                MessageBox.Show("Registo efetuado com sucesso");
                Login login = new Login();
                login.Show();
                this.Hide();
                
            
            }

            CN.Close();
        }



        private bool existsUsername(string username)
        {
          
            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_Login WHERE username = @username", CN);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = cmd.ExecuteReader();
            bool exists = reader.HasRows;


            reader.Close();
          
            return exists;
        }

        private bool limitationsPassword(string password)
        {
            if (password.Length < 8)
            {
                MessageBox.Show("Password tem de ter pelo menos 8 caracteres");
                return false;
            }
            else if (!char.IsUpper(password[0]))
            {
                MessageBox.Show("Password tem de começar com uma letra maiúscula");
                return false;
            }
            else if (!password.Any(char.IsLower))
            {
                MessageBox.Show("Password tem de ter pelo menos uma letra minúscula");
                return false;
            }
            else if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Password tem de ter pelo menos um número");
                return false;
            }
            else if (password.Any(char.IsWhiteSpace))
            {
                MessageBox.Show("Password não pode ter espaços");
                return false;
            }
            return true;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
