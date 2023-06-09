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
    public partial class Plat : Form
    {
        public Plat()
        {
            InitializeComponent();
        }
        SqlConnection macnx = new SqlConnection(@"Data Source=4LENOV6-PC\MSSQLSERVER1;Initial Catalog=DB_BESTRESTO;Integrated Security=True");
        SqlCommand macmd = new SqlCommand();
       
        private void Plat_Load(object sender, EventArgs e)
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
            macmd.CommandText = "select count(IdP) from Plat where IdP=@IdP";
            macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
            cpt = (int)macmd.ExecuteScalar();
            return cpt;
        }
        void RempliDGV()
        {
            macmd.Connection = macnx;
            macmd.CommandText = "select IdP [Numero],Nom ,Prix from Plat";
            SqlDataReader DR = macmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            dataGridViewPlat.DataSource = DT;
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
            if (textBoxN.Text == "" || textBoxnom.Text == "" || textBoxprix.Text == "" )
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
            else
            {

                if (nombre() == 0)
                {
                    macmd.Parameters.Clear();
                    macmd.Connection = macnx;
                    macmd.CommandText = "insert into Plat values(@IdP,@nom,@prix)";
                    macmd.Parameters.AddWithValue("@IdPC", SqlDbType.Int).Value = textBoxN.Text;
                    macmd.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = textBoxnom.Text;
                    macmd.Parameters.AddWithValue("@prix", SqlDbType.VarChar).Value = textBoxprix.Text;
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
                macmd.CommandText = "Delete from Plat where IdP=@IdP";
                macmd.Parameters.AddWithValue("@IdP", SqlDbType.Int).Value = textBoxN.Text;
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
            if (textBoxN.Text == "" || textBoxnom.Text == "" || textBoxprix.Text == "" )
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
            else
            {
                macmd.Parameters.Clear();
                macmd.Connection = macnx;

                macmd.CommandText = "Update Plat set Nom=@nom ,Prix=@prix  where IdP=@IdP";
                macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxN.Text;
                macmd.Parameters.AddWithValue("@nom", SqlDbType.VarChar).Value = textBoxnom.Text;
                macmd.Parameters.AddWithValue("@prix", SqlDbType.VarChar).Value = textBoxprix.Text;
                initialisation(this);

                MessageBox.Show("Il est modifié avec succès");
                RempliDGV();
            }
        }

        private void Rechercher_Click(object sender, EventArgs e)
        {
            macmd.Parameters.Clear();
            macmd.Connection = macnx;
            macmd.CommandText = "select * from Plat where IdP=@IdP";
            macmd.Parameters.AddWithValue("@IdP", SqlDbType.Int).Value = textBoxN.Text;
            SqlDataReader dr = macmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows == true)
            {
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprix.Text = dr[2].ToString();

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
            macmd = new SqlCommand("select * from Plat", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            dr.Read();

            textBoxN.Text = dr[0].ToString();
            textBoxnom.Text = dr[1].ToString();
            textBoxprix.Text = dr[2].ToString();
            dr.Close();
        }

        private void Précedent_Click(object sender, EventArgs e)
        {
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Plat where IdP <" + textBoxN.Text + "order by IdP desc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprix.Text = dr[2].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }
            

        }

        private void Suivant_Click(object sender, EventArgs e)
        {
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Plat where IdP >" + textBoxN.Text + "order by IdP asc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprix.Text = dr[2].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }

        }

        private void Dérniere_Click(object sender, EventArgs e)
        {
            macmd.Connection = macnx;
            macmd = new SqlCommand("select * from Plat", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            while (dr.Read())
            {
                textBoxN.Text = dr[0].ToString();
                textBoxnom.Text = dr[1].ToString();
                textBoxprix.Text = dr[2].ToString();
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
