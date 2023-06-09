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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        SqlConnection macnx = new SqlConnection(@"Data Source=4LENOV6-PC\MSSQLSERVER1;Initial Catalog=DB_BESTRESTO;Integrated Security=True");
        SqlCommand macmd = new SqlCommand();

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
            if (textBoxN.Text == "" || textBoxnom.Text == "" || textBoxprénom.Text == "" || textBoxtel.Text == "" || textBoxaddersse.Text == "" || textBoxemail.Text == "" )
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
            else
            {

                if (nombre() == 0)
                {
                    macmd.Parameters.Clear();
                    macmd.Connection = macnx;
                    macmd.CommandText = "insert into Client values(@IdC,@nom,@prénom,@tel,@email,@addresse)";
                    macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
                    macmd.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = textBoxnom.Text;
                    macmd.Parameters.AddWithValue("@prénom", SqlDbType.VarChar).Value = textBoxprénom.Text;
                    macmd.Parameters.AddWithValue("@tel", SqlDbType.Int).Value = textBoxtel.Text;
                    macmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = textBoxaddersse.Text;
                    macmd.Parameters.AddWithValue("@addresse", SqlDbType.VarChar).Value = textBoxemail.Text;
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
        public int nombre()
        {
            int cpt;
            macmd.Connection = macnx;
            macmd.CommandText = "select count(IdC) from Client where IdC=@IdC";
            macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
            cpt = (int)macmd.ExecuteScalar();
            return cpt;
        }

        private void Client_Load(object sender, EventArgs e)
        {

            if (macnx.State != ConnectionState.Open)
            {
                macnx.Open();

            }
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (nombre() != 0)
            {
                macmd.Parameters.Clear();
                macmd.Connection = macnx;
                macmd.CommandText = "Delete from Client where IdC=@IdC";
                macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
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
            if (textBoxN.Text == "" || textBoxnom.Text == "" || textBoxprénom.Text == "" || textBoxtel.Text == "" || textBoxaddersse.Text == "" || textBoxemail.Text == "" )
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
            else
            {
                macmd.Parameters.Clear();
                macmd.Connection = macnx;

                macmd.CommandText = "Update Client set Nom=@nom ,Prénom=@prénom,Tel=@tel,Email=@email,Addresse=@addresse where IdC=@IdC";
                macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
                macmd.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = textBoxnom.Text;
                macmd.Parameters.AddWithValue("@prénom", SqlDbType.VarChar).Value = textBoxprénom.Text;
                macmd.Parameters.AddWithValue("@tel", SqlDbType.Int).Value = textBoxtel.Text;
                macmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = textBoxaddersse.Text;
                macmd.Parameters.AddWithValue("@addresse", SqlDbType.VarChar).Value = textBoxemail.Text;

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
            macmd.CommandText = "select * from Client where IdC=@IdC";
            macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
            SqlDataReader dr = macmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows == true)
            {
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprénom.Text = dr[2].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();
                textBoxemail.Text = dr[5].ToString();

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
            macmd = new SqlCommand("select * from Client", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            dr.Read();

            textBoxN.Text = dr[0].ToString();
            textBoxnom.Text = dr[1].ToString();
            textBoxprénom.Text = dr[2].ToString();
            textBoxtel.Text = dr[3].ToString();
            textBoxaddersse.Text = dr[4].ToString();
            textBoxemail.Text = dr[5].ToString();
            dr.Close();

        }

        private void Précedent_Click(object sender, EventArgs e)
        {
            
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Client where IdC <" + textBoxN.Text + "order by IdC desc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprénom.Text = dr[2].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();
                textBoxemail.Text = dr[5].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }
            

        }

        private void Suivant_Click(object sender, EventArgs e)
        {
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Client where IdC >" + textBoxN.Text + "order by IdC asc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprénom.Text = dr[2].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();
                textBoxemail.Text = dr[5].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }

        }
        void RempliDGV()
        {
            macmd.Connection = macnx;
            macmd.CommandText = "select IdC [Numero],Nom ,Prénom ,Tel ,Email ,Addresse from Client";
            SqlDataReader DR = macmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            dataGridViewClient.DataSource = DT;
        }


        private void Dérniere_Click(object sender, EventArgs e)
        {
            macmd.Connection = macnx;
            macmd = new SqlCommand("select * from Client", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            while (dr.Read())
            {
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprénom.Text = dr[2].ToString();
                textBoxtel.Text = dr[3].ToString();
                textBoxaddersse.Text = dr[4].ToString();
                textBoxemail.Text = dr[5].ToString();
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
