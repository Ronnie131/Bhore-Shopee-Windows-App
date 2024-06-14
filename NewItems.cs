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
    public partial class NewItems : Form
    {
        public NewItems()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tipan VALUES(@pid,@pname,@quantity,@perkgprice,@itemperkg", conn);
            cmd.Parameters.AddWithValue("@pid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@pname", textBox3.Text);

            float quantity = Convert.ToSingle(textBox4.Text);
            int DecimalPlace = 3;
            float RoundedNumber = (float)Math.Round(quantity, DecimalPlace);
            decimal fresult = Convert.ToDecimal(RoundedNumber);
            cmd.Parameters.AddWithValue("@quantity", fresult);

            float price = Convert.ToSingle(textBox5.Text);
            int DecimalPlace1 = 2;
            float RoundedNumber1 = (float)Math.Round(price, DecimalPlace);
            decimal fresult1 = Convert.ToDecimal(RoundedNumber);
            cmd.Parameters.AddWithValue("@perkgprice", fresult1);
            cmd.Parameters.AddWithValue("@itemperkg", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Item Added Successfully in the list");
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            else
            {


                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tipan VALUES(@pid, @pname, @quantity, @perkgprice, @itemperkg)", conn);
                cmd.Parameters.AddWithValue("@pid", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@pname", textBox3.Text);

                float quantity = Convert.ToSingle(textBox4.Text);
                int DecimalPlace = 3;
                float RoundedNumber = (float)Math.Round(quantity, DecimalPlace);
                decimal fresult = Convert.ToDecimal(RoundedNumber);
                cmd.Parameters.AddWithValue("@quantity", fresult);

                float price = Convert.ToSingle(textBox5.Text);
                int DecimalPlace1 = 2;
                float RoundedNumber1 = (float)Math.Round(price, DecimalPlace);
                decimal fresult1 = Convert.ToDecimal(RoundedNumber);
                cmd.Parameters.AddWithValue("@perkgprice", fresult1);
                cmd.Parameters.AddWithValue("@itemperkg", int.Parse(textBox6.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Item Added Successfully in the list");
            }
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM tipan WHRERE P_id = @P_id", conn1);
            cmd1.Parameters.AddWithValue("@P_id", int.Parse(textBox2.Text));
            cmd1.ExecuteNonQuery();
            conn1.Close();
            MessageBox.Show("Item Deleted Successfully in the list");
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Product ID");
            }
            else
            {

           
            SqlConnection conn1 = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM tipan WHERE P_id = @P_id", conn1);
            cmd1.Parameters.AddWithValue("@P_id", int.Parse(textBox2.Text));
            cmd1.ExecuteNonQuery();
            conn1.Close();
            MessageBox.Show("Item Deleted Successfully from the list");
        }
       }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewItems_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }
    }
}
