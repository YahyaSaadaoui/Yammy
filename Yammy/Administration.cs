using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yammy
{
    public partial class Administration : Form
    {
        public Administration()
        {
            InitializeComponent();
        }
        SqlConnection macnx = new SqlConnection(@"Data Source=4LENOV6-PC\MSSQLSERVER1;Initial Catalog=DB_BESTRESTO;Integrated Security=True");
        SqlCommand macmd = new SqlCommand();
       

        private void button1_Click(object sender, EventArgs e)
        {
            macmd.Connection = macnx;
            macmd.CommandText = "select Login,Mot_de_passe from Authentification where Login =@Login and Mot_de_passe=@Mot_de_Passe ";
            macmd.Parameters.Clear();
            macmd.Parameters.AddWithValue("@nomConducteur", SqlDbType.VarChar).Value = textBoxLog.Text;
            macmd.Parameters.AddWithValue("@mdpConducteur", SqlDbType.Int).Value = textBoxmdp.Text;
            SqlDataReader DR = macmd.ExecuteReader();
            if (DR.HasRows)//Bonne Authentification
            {
               
                MSJ.Visible = false;
                Yammy yammy = new Yammy();
                yammy.Show();
                this.Hide();
            }
            else//Mauvaise Authentification
            {
                MSJ.Visible = true;
            }
            DR.Close();
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            if (macnx.State != ConnectionState.Open)
            {
                macnx.Open();

            }
            if (A.Checked)
            {
                textBoxmdp.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxmdp.UseSystemPasswordChar = true;
            }
        }

        
    }
}
