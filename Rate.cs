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
    public partial class Rate : Form
    {
       // List<string> itemsList = new List<string>();

        public Rate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage h1 = new HomePage();
            h1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection s = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            s.Open();
            String sss = "select *from tipan";           
            SqlDataAdapter ad = new SqlDataAdapter(sss, s);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            //s.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            
            if (textBox3.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Enter the Product id && newly Added Quantity");
            }
            else {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
                float column1Value = 0;
                using (con)
                {
                    // Open the connection
                    con.Open();

                    // Replace with the actual primary key value

                    // Create a SQL query with a parameter for the primary key
                    string sqlQuery = "SELECT P_quantity FROM tipan WHERE P_id = @id";
                    using (SqlCommand command = new SqlCommand(sqlQuery, con))
                    {
                        // Add the parameter for the primary key
                        command.Parameters.AddWithValue("@id", int.Parse(textBox3.Text));

                        // Execute the query and retrieve the single value
                        object result = command.ExecuteScalar();

                        // Check if the result is not null and convert it to the appropriate data type
                        if (result != null)
                        {
                            column1Value = Convert.ToSingle(result);

                            // Store the value in a variable
                            // ...
                        }
                    }
                    SqlCommand cmd1 = new SqlCommand("update tipan set P_quantity=@P_quantity where P_id=@P_id", con);

                    float f_quantity = column1Value + float.Parse(textBox1.Text);
                    int decimalPlaces = 3;
                    float roundedNumber = (float)Math.Round(f_quantity, decimalPlaces);
                    decimal fresult = Convert.ToDecimal(roundedNumber);

                    cmd1.Parameters.AddWithValue("@P_id", int.Parse(textBox3.Text));
                    cmd1.Parameters.AddWithValue("@P_quantity", fresult);



                    cmd1.ExecuteNonQuery();

                    // Close the connection

                    con.Close();
                    MessageBox.Show("Quantity added Successfully");
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
            if (textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Enter the Product id && new Product Price");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
                con.Open();
            
                SqlCommand cmd = new SqlCommand("update tipan set P_price=@P_price1 where P_id=@P_id", con);

                float price = Convert.ToSingle(textBox4.Text);
                int DecimalPlace = 2;
                float RoundedNumber = (float)Math.Round(price, DecimalPlace);
                decimal fresult = Convert.ToDecimal(RoundedNumber);


                cmd.Parameters.AddWithValue("@P_id", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@P_price1", fresult);



                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data added Successfully");
            }
          
            

        }
        private void button5_Click(object sender, EventArgs e)

        {

            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter the Product id && new Minimum Quantity");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
                con.Open();
                //string id = textBox2.Text;
                //int id1 = int.Parse(id);
                SqlCommand cmd = new SqlCommand("update tipan set Itemforperkg=@ifpk where P_id=@P_id", con);



                int new_min_q = int.Parse(textBox6.Text);


                cmd.Parameters.AddWithValue("@P_id", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@ifpk", new_min_q);



                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data added Successfully");
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Rate_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
