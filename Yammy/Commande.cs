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
    public partial class Commande : Form
    {
        public Commande()
        {
            InitializeComponent();
        }
        SqlConnection macnx = new SqlConnection(@"Data Source=4LENOV6-PC\MSSQLSERVER1;Initial Catalog=DB_BESTRESTO;Integrated Security=True");
        SqlCommand macmd = new SqlCommand();
       

        private void Commande_Load(object sender, EventArgs e)
        {
            if (macnx.State != ConnectionState.Open)
            {
                macnx.Open();

            }
        


            macmd.Connection = macnx;
            macmd.CommandText = "select IdR ,Nom  from Restaurant";
            SqlDataReader DR = macmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            comboBoxR.DataSource = DT;
            comboBoxR.ValueMember = "IdR";  //element a récupuré
            comboBoxR.DisplayMember = "Nom";  //element a afficher


            macmd.Connection = macnx;
            macmd.CommandText = "select IdP,Nom from Plat";
            SqlDataReader DR1 = macmd.ExecuteReader();
            DataTable DT1 = new DataTable();
            DT.Load(DR1);
            comboBoxP.DataSource = DT1;
            comboBoxP.ValueMember = "IdP";  //element a récupuré
            comboBoxP.DisplayMember = "Nom";  //element a afficher


            macmd.Connection = macnx;
            macmd.CommandText = "select IdB,Nom from Plat";
            SqlDataReader DR2 = macmd.ExecuteReader();
            DataTable DT2 = new DataTable();
            DT.Load(DR2);
            comboBoxB.DataSource = DT2;
            comboBoxB.ValueMember = "IdB";  //element a récupuré
            comboBoxB.DisplayMember = "Nom";  //element a afficher


            
        }
        void initialisation(Control C)
        {

            foreach (Control item in C.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    ((TextBox)item).Clear();
                
                if (item.GetType() == typeof(ComboBox))
                    ((ComboBox)item).SelectedIndex =-1;
                if (item.GetType() == typeof(DateTimePicker))
                    ((DateTimePicker)item).Value = DateTime.Today;

                if (item.Controls.Count != 0)
                    initialisation(item);
            }

        }
        public int nombre()
        {
            int cpt;
            macmd.Connection = macnx;
            macmd.CommandText = "select count(IdCmd) from Commande where IdCmd=@IdCmd";
            macmd.Parameters.AddWithValue("@IdCmd", SqlDbType.Int).Value = textBoxnum.Text;
            cpt = (int)macmd.ExecuteScalar();
            return cpt;
        }
        void RempliDGV()
        {
            macmd.Connection = macnx;
            macmd.CommandText = "select IdCmd [Numero],Restaurant.Nom [Non Restaurant] ,Client.Nom [Nom Client],Plat.Nom [Nom Plat],Boisson.Nom [Nom Boisson],Commande.Date_Cmd [Date Commande],Commande.Description ,Commande.Qantité_P [Quantité Plat],Commande.Qantité_B [Quantité Boisson] from Commande inner join Client on Client.IdC=Commande.IdC inner join Restaurant on Commande.IdR=Restaurant.IdR inner join Plat on Commande.IdP=Plat.IdP inner join Boisson on Commande.IdB=Boisson.IdB";
            SqlDataReader DR = macmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            dataGridViewCommande.DataSource = DT;
        }


        private void Ajouter_Click(object sender, EventArgs e)
        {
            if (textBoxnum.Text == "" || comboBoxclient.Text == "" || dataGridViewCommande.Text == "" || comboBoxR.Text == "" || comboBoxP.Text == "" || comboBoxB.Text == "" || textBoxQ_B.Text == "" || textBoxQ_P.Text == "" || textBoxdes.Text == "")
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
            else
            {

                if (nombre() == 0)
                {
                    macmd.Parameters.Clear();
                    macmd.Connection = macnx;
                    macmd.CommandText = "insert into Client values(@IdCmd,@IdC,@date,@IdR,@IdP,@IdB,@QB,@QP,@des)";
                    macmd.Parameters.AddWithValue("@IdCmd", SqlDbType.Int).Value = textBoxnum.Text;
                    macmd.Parameters.AddWithValue("@IdC", SqlDbType.VarChar).Value = comboBoxclient.SelectedValue;
                    macmd.Parameters.AddWithValue("@date", SqlDbType.Date).Value = dataGridViewCommande.Text;
                    macmd.Parameters.AddWithValue("@IdR", SqlDbType.Int).Value = comboBoxR.SelectedValue;
                    macmd.Parameters.AddWithValue("@IdP", SqlDbType.VarChar).Value = comboBoxP.SelectedValue;
                    macmd.Parameters.AddWithValue("@IdB", SqlDbType.VarChar).Value = comboBoxB.SelectedValue;
                    macmd.Parameters.AddWithValue("@QB", SqlDbType.Int).Value = textBoxQ_B.Text;
                    macmd.Parameters.AddWithValue("@QP", SqlDbType.Int).Value = textBoxQ_P.Text;
                    macmd.Parameters.AddWithValue("@des", SqlDbType.Int).Value = textBoxdes.Text;
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
                macmd.CommandText = "Delete from Commande where IdC=@IdC";
                macmd.Parameters.AddWithValue("@IdCmd", SqlDbType.Int).Value = textBoxnum.Text;
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
            if (textBoxnum.Text == "" || comboBoxclient.Text == "" || dataGridViewCommande.Text == "" || comboBoxR.Text == "" || comboBoxP.Text == "" || comboBoxB.Text == "" || textBoxQ_B.Text == "" || textBoxQ_P.Text == "" || textBoxdes.Text == "")
            {
                MessageBox.Show("S'il te plait remplir tout les champs");
            }
           
            else
            {
                macmd.Parameters.Clear();
                macmd.Connection = macnx;

                macmd.CommandText = "Update Client set =@ , =@ , =@ ,=@,=@,=@,=@ ,=@ where IdCmd=@IdCdm";
                macmd.Parameters.AddWithValue("@IdCmd", SqlDbType.Int).Value = textBoxnum.Text;
                macmd.Parameters.AddWithValue("@IdC", SqlDbType.VarChar).Value = comboBoxclient.SelectedValue;
                macmd.Parameters.AddWithValue("@date", SqlDbType.Date).Value = dataGridViewCommande.Text;
                macmd.Parameters.AddWithValue("@IdR", SqlDbType.Int).Value = comboBoxR.SelectedValue;
                macmd.Parameters.AddWithValue("@IdP", SqlDbType.VarChar).Value = comboBoxP.SelectedValue;
                macmd.Parameters.AddWithValue("@IdB", SqlDbType.VarChar).Value = comboBoxB.SelectedValue;
                macmd.Parameters.AddWithValue("@QB", SqlDbType.Int).Value = textBoxQ_B.Text;
                macmd.Parameters.AddWithValue("@QP", SqlDbType.Int).Value = textBoxQ_P.Text;
                macmd.Parameters.AddWithValue("@des", SqlDbType.Int).Value = textBoxdes.Text;

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
            macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxnum.Text;
            SqlDataReader dr = macmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows == true)
            {
                textBoxnum.Text = dr[0].ToString();
                comboBoxclient.Text = dr[1].ToString();
                dataGridViewCommande.Text = dr[2].ToString();
                comboBoxR.Text = dr[3].ToString();
                comboBoxP.Text = dr[4].ToString();
                comboBoxB.Text = dr[5].ToString();
                textBoxQ_B.Text = dr[6].ToString();
                textBoxQ_P.Text = dr[7].ToString();
                textBoxdes.Text = dr[8].ToString();

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
            macmd = new SqlCommand("select * from Commande", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            dr.Read();

            textBoxnum.Text = dr[0].ToString();
            comboBoxclient.Text = dr[1].ToString();
            comboBoxR.Text = dr[5].ToString();
            comboBoxP.Text = dr[2].ToString();
            comboBoxB.Text = dr[3].ToString();
            
            dateTimePicker1.Text = dr[4].ToString();
            textBoxdes.Text = dr[8].ToString();
            textBoxQ_P.Text = dr[6].ToString();
            textBoxQ_B.Text = dr[7].ToString();
            
            dr.Close();
        }

        private void Précedent_Click(object sender, EventArgs e)
        {
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Commande where IdCmd <" + textBoxnum.Text + "order by IdCmd desc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxnum.Text = dr[0].ToString();
                comboBoxclient.Text = dr[1].ToString();
                comboBoxR.Text = dr[5].ToString();
                comboBoxP.Text = dr[2].ToString();
                comboBoxB.Text = dr[3].ToString();

                dateTimePicker1.Text = dr[4].ToString();
                textBoxdes.Text = dr[8].ToString();
                textBoxQ_P.Text = dr[6].ToString();
                textBoxQ_B.Text = dr[7].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }
            

        }

        private void Suivant_Click(object sender, EventArgs e)
        {
            try
            {
                macmd.Connection = macnx;
                macmd = new SqlCommand("select * from Commande where IdCmd >" + textBoxnum.Text + "order by IdCmd asc", macnx);

                SqlDataReader dr = macmd.ExecuteReader();

                dr.Read();
                textBoxnum.Text = dr[0].ToString();
                comboBoxclient.Text = dr[1].ToString();
                comboBoxR.Text = dr[5].ToString();
                comboBoxP.Text = dr[2].ToString();
                comboBoxB.Text = dr[3].ToString();

                dateTimePicker1.Text = dr[4].ToString();
                textBoxdes.Text = dr[8].ToString();
                textBoxQ_P.Text = dr[6].ToString();
                textBoxQ_B.Text = dr[7].ToString();
                dr.Close();
            }
            catch { MessageBox.Show("C'est le derniére"); }

        }

        private void Dérniere_Click(object sender, EventArgs e)
        {
            macmd.Connection = macnx;
            macmd = new SqlCommand("select * from Commande", macnx);
            SqlDataReader dr = macmd.ExecuteReader();

            while (dr.Read())
            {
                textBoxnum.Text = dr[0].ToString();
                comboBoxclient.Text = dr[1].ToString();
                comboBoxR.Text = dr[5].ToString();
                comboBoxP.Text = dr[2].ToString();
                comboBoxB.Text = dr[3].ToString();

                dateTimePicker1.Text = dr[4].ToString();
                textBoxdes.Text = dr[8].ToString();
                textBoxQ_P.Text = dr[6].ToString();
                textBoxQ_B.Text = dr[7].ToString();
            }
            dr.Close();

        }

        private void Calculer_Click(object sender, EventArgs e)
        {

            macmd.Parameters.Clear();
            macmd.Connection = macnx;
            macmd.CommandText = "select Totale=((Plat.Prix*Qantité_P)+(Boisson.Prix*Qantité_B)) from Commande inner join Plat on Plat.IdP=Commande.IdP inner join Boisson on Boisson.IdB=Commande.IdB where IdC=@IdC";
            macmd.Parameters.AddWithValue("@IdC", SqlDbType.Int).Value = textBoxnum.Text;
            SqlDataReader dr = macmd.ExecuteReader();
            dr.Read();

            textBoxTotale.Text = dr[8].ToString();

        }

        private void Retour_Click(object sender, EventArgs e)
        {
            Yammy yammy = new Yammy();
            yammy.Show();
            this.Hide();
        }
    }
}
