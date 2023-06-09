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
    public partial class Restaurant : Form
    {
        public Restaurant()
        {
            InitializeComponent();
        }
        SqlConnection macnx = new SqlConnection(@"Data Source=4LENOV6-PC\MSSQLSERVER1;Initial Catalog=DB_BESTRESTO;Integrated Security=True");
        SqlCommand macmd = new SqlCommand();
       

        private void Restaurant_Load(object sender, EventArgs e)
        {
            if (macnx.State != ConnectionState.Open)
            {
                macnx.Open();

            }
        }
        public int nombre()
        {
            int cpt;
            macmd.Connection = macnx;
            macmd.CommandText = "select count(IdR) from Restaurant where IdR=@IdR";
            macmd.Parameters.AddWithValue("@IdR", SqlDbType.Int).Value = textBoxN.Text;
            cpt = (int)macmd.ExecuteScalar();
            return cpt;
        }
        void RempliDGV()
        {
            macmd.Connection = macnx;
            macmd.CommandText = "select IdR [Numero],Nom ,Tel,Addersse from Restaurant";
            SqlDataReader DR = macmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            dataGridViewRestaurant.DataSource = DT;
        }
        void initialisation(Control C)
        {

            foreach (Control item in C.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    ((TextBox)item).Clear();

                if (item.Controls.Count != 0)
                    initialisation(item);
            }

        }
        private void Ajouter_Click(object sender, EventArgs e)
        {
            if (textBoxN.Text == "" || textBoxnom.Text == "" || textBoxtel.Text == "" || textBoxaddersse.Text == "" )
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
            else
            {

                if (nombre() == 0)
                {
                    macmd.Parameters.Clear();
                    macmd.Connection = macnx;
                    macmd.CommandText = "insert into Restaurant values(@IdR,@nom,@tel,@addresse)";
                    macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
                    macmd.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = textBoxnom.Text;
                    macmd.Parameters.AddWithValue("@tel", SqlDbType.Int).Value = textBoxtel.Text;
                    macmd.Parameters.AddWithValue("@addresse", SqlDbType.VarChar).Value = textBoxaddersse.Text;
                    int L = macmd.ExecuteNonQuery();

                    if (L != 0)
                    {
                        MessageBox.Show("Il est ajouté avec succès");
                    }
                    else
                    {
                        MessageBox.Show("Il est echoueè");
                    }
                    initialisation(this);
                    RempliDGV();
                }
                else
                {
                    MessageBox.Show("Il est déja exist");
                    initialisation(this);
                }
            }
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (nombre() != 0)
            {
                macmd.Parameters.Clear();
                macmd.Connection = macnx;
                macmd.CommandText = "Delete from Restaurant where IdR=@IdR";
                macmd.Parameters.AddWithValue("@IdR", SqlDbType.Int).Value = textBoxN.Text;
                macmd.ExecuteNonQuery();
                MessageBox.Show("Il est supprimé avec succès");
                RempliDGV();
            }
            else
            {
                MessageBox.Show("N'exist pas!!!");
            }

        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            if (textBoxN.Text == "" || textBoxnom.Text == ""  || textBoxtel.Text == "" || textBoxaddersse.Text == "")
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
            else
            {
                macmd.Parameters.Clear();
                macmd.Connection = macnx;

                macmd.CommandText = "Update Restaurant set Nom=@nom ,Tel=@tel,Addresse=@addresse where IdR=@IdR";
                macmd.Parameters.AddWithValue("@IdR", SqlDbType.Int).Value = textBoxN.Text;
                macmd.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = textBoxnom.Text;
                macmd.Parameters.AddWithValue("@tel", SqlDbType.Int).Value = textBoxtel.Text;
                macmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = textBoxaddersse.Text;

                macmd.ExecuteNonQuery();
                initialisation(this);

                MessageBox.Show("Il est modifié avec succès");
                RempliDGV();
            }

        }

        private void Rechercher_Click(object sender, EventArgs e)
        {
            macmd.Parameters.Clear();
            macmd.Connection = macnx;
            macmd.CommandText = "select * from Restaurant where IdR=@IdR";
            macmd.Parameters.AddWithValue("@IdR", SqlDbType.Int).Value = textBoxN.Text;
            SqlDataReader dr = macmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows == true)
            {
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();

            }
            else
            {
                MessageBox.Show("N'exist pas");
                initialisation(this);
            }
            dr.Close();

        }

        private void Premier_Click(object sender, EventArgs e)
        {
            macmd.Connection = macnx;
            macmd = new SqlCommand("select * from Restaurant", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            dr.Read();

            textBoxN.Text = dr[0].ToString();
            textBoxnom.Text = dr[1].ToString();
            textBoxtel.Text = dr[3].ToString();
            textBoxaddersse.Text = dr[4].ToString();
            dr.Close();
        }

        private void Précedent_Click(object sender, EventArgs e)
        {
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Restaurant where IdR <" + textBoxN.Text + "order by IdR desc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }
            
                   
        }

        private void Suivant_Click(object sender, EventArgs e)
        {
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Restaurant where IdR >" + textBoxN.Text + "order by IdR asc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }

        }

        private void Dérniere_Click(object sender, EventArgs e)
        {
            macmd.Connection = macnx;
            macmd = new SqlCommand("select * from Restaurant", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            while (dr.Read())
            {
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();
            }
            dr.Close();

        }

        private void Retour_Click(object sender, EventArgs e)
        {
            Yammy yammy = new Yammy();
            yammy.Show();
            this.Hide();
        }
    }
}
