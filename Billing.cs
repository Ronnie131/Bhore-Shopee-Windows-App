using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BhoreAndSons
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection s = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            s.Open();
            String sss = "select *from billing";
            SqlDataAdapter ad = new SqlDataAdapter(sss, s);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            label3.Visible = true;
            label3.Text = ItemUpdate.totalBill.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage h1 = new HomePage();
            this.Hide();
            h1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
