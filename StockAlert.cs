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
    public partial class StockAlert : Form
    {
        public StockAlert()
        {
            InitializeComponent();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(textBox1.Text);
            SqlConnection conn1 = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            conn1.Open();
            //SqlCommand cmd = new SqlCommand("SELECT P_name,P_quantity FROM tipan WHERE P_quantity< @Quantity",conn1);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT P_name,P_quantity FROM tipan WHERE P_quantity< @amount", conn1);
            //ad.Parameters.AddWithValue("@Quantity", amount);*/

        //String sss = "SELECT P_name,P_quantity FROM tipan WHERE P_quantity< @Quantity";
        // SqlDataAdapter ad = new SqlDataAdapter(sss, s);

        /* DataTable dt = new DataTable();
         ad.Fill(dt);
         dataGridView1.DataSource = dt;
     }*/

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Product ID");
            }
            else
            {
                int amount = Convert.ToInt32(textBox1.Text);
                SqlConnection conn1 = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
                conn1.Open();
                SqlCommand cmd = new SqlCommand("SELECT P_name, P_quantity FROM tipan WHERE P_quantity < @amount", conn1);
                cmd.Parameters.AddWithValue("@amount", amount);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;

                conn1.Close();
            }
           
        }



        private void StockAlert_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
