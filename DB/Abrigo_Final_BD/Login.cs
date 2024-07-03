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
    public partial class Login : Form
    {
        public static string SQLConnectionString = "Data Source = (localdb)\\Abrigo_Final_DB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        private SqlConnection CN;

        bool isValid = false;

        public Login()
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
        private void button_login_Click(object sender, EventArgs e)
        {
            CN.Open();


            SqlCommand cmd = new SqlCommand("VerifyPassword", CN);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username_input.Text);
            cmd.Parameters.AddWithValue("@password", password_input.Text);




            SqlParameter isValidParam = new SqlParameter("@isValid", SqlDbType.Bit);
            isValidParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(isValidParam);

            cmd.ExecuteNonQuery();
            isValid = (bool)isValidParam.Value;


            CN.Close();


            if (isValid)
            {
                this.Hide();
                Abrigo abrigo = new Abrigo();
                abrigo.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }

        }

        private void register_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }
    }
}
