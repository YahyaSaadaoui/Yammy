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
    public partial class Yammy : Form
    {
        public Yammy()
        {
            InitializeComponent();
        }
        SqlConnection macnx = new SqlConnection(@"Data Source=4LENOV6-PC\MSSQLSERVER1;Initial Catalog=DB_BESTRESTO;Integrated Security=True");
        SqlCommand macmd = new SqlCommand();
       

       

        private void Yammy_Load(object sender, EventArgs e)
        {
            if (macnx.State != ConnectionState.Open)
            {
                macnx.Open();

            }
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurant rest = new Restaurant();
            this.Hide();
            rest.Show();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            this.Hide();
            client.Show();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.Close();
           
        }

        private void boissonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boisson boison = new Boisson();
            this.Hide();
            boison.Show();
            
        }

        private void platToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plat plat = new Plat();
            this.Hide();
            plat.Show();
        }

        private void commandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commande commande = new Commande();
            this.Hide();
            commande.Show();
        }
    }
}
