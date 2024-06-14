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

namespace BhoreAndSons
{
   

    public partial class ItemUpdate : Form
    {

        Dictionary<string, int> uq = new Dictionary<string, int>();
        public static double totalBill=0;
        List<string> itemsList = new List<string>
        {
           
        };
        List<string> checkedItems = new List<string>();

        public ItemUpdate()
        {
            InitializeComponent();
           
        }


        private void PopulateChecklist()
        {
            checkedListBox1.Items.AddRange(itemsList.ToArray());
        }


        private void CheckAllItems()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }



       //method to fetch the value of each item per kg
        private double FetchValue_price(string item, SqlConnection conn)
        {
            double result = 0;
            string query = $"SELECT P_price FROM tipan WHERE P_name = '{item}';";

            try
            {
                conn.Open(); // Open the connection before executing the query

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader.GetDouble(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the execution of the query
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Close the connection after executing the query
            }

            return result;
        }


        //method to fetch the minimum quantity required per 1 kg of tikhat in grams

        private int FetchValue_quan(string item, SqlConnection conn)
        {
            int result1 = 0;
            string query = $"SELECT Itemforperkg FROM tipan WHERE P_name = '{item}';";

            try
            {
                conn.Open(); // Open the connection before executing the query

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result1 = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the execution of the query
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Close the connection after executing the query
            }

            return result1;
        }


        //method to fetch the value of available product quantity and update it

        private double FetchP_quantity(string item, SqlConnection conn)
        {
            double result2 = 0;
            string query = $"SELECT P_quantity FROM tipan WHERE P_name = '{item}';";

            try
            {
                conn.Open(); // Open the connection before executing the query

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result2 = reader.GetDouble(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the execution of the query
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Close the connection after executing the query
            }

            return result2;
        }


        public void FetchValuesContinuously(List<string> checkedItems)
        {
            
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");

            conn.Open();
            SqlCommand cmd2 = new SqlCommand("TRUNCATE TABLE billing", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();

            string connectionString = "Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string item in checkedItems)
                {
                    
                    double itempriceperkg = FetchValue_price(item, connection);
                    /*int DecimalPlace = 2;
                    float RoundedNumber = (float)Math.Round(price, DecimalPlace);
                    decimal itempriceperkg = Convert.ToDecimal(RoundedNumber);*/
                    int itemquanperkg = FetchValue_quan(item, connection);
                    double quantity = FetchP_quantity(item, connection);
                    /*int DecimalPlace1 = 3;
                    float RoundedNumber1 = (float)Math.Round(quan, DecimalPlace1);
                    decimal quantity = Convert.ToDecimal(RoundedNumber1);*/
                    int amount = int.Parse(textBox1.Text);
                    Billing(item, itempriceperkg, itemquanperkg, amount, quantity, connection);

                    // You can perform additional operations with the fetched value here
                }

                connection.Close();
                //MessageBox.Show("Quantity updated successfully");

                // MessageBox.Show("Data added into another table successfully");
                // Close the connection after executing all the queries
            }
        }

        public void Billing(string item, double p, int q, int amount, double quantity, SqlConnection conn)
        {
            if(uq.ContainsKey(item))
            {
                q = uq[item];
              

            }
            if(item=="Til")
            {
                p = 500;
            }
            double totalq = q;
            
            totalq =amount* (totalq / 1000);
            double totalp = p * totalq;
            totalp = Math.Round(totalp, 2);
            double qq=  Math.Round(totalq, 3);
            totalBill += totalp;

            

            conn.Open(); // Open the connection before executing the query

            SqlCommand cmd = new SqlCommand("INSERT INTO billing values(@item,@totalq,@totalp)", conn);
            cmd.Parameters.AddWithValue("@item", item);
            cmd.Parameters.AddWithValue("@totalq", qq);
            cmd.Parameters.AddWithValue("@totalp", totalp);
            cmd.ExecuteNonQuery();
           

            conn.Close(); // Close the connection

            SqlConnection conn1 = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("update tipan set P_quantity=@P_quantity where P_name=@item", conn1);
            cmd1.Parameters.AddWithValue("@item", item);
            double fq = quantity - (totalq);
            fq = Math.Round(fq, 3);
            cmd1.Parameters.AddWithValue("@P_quantity",fq);

            // Open the connection before executing the query
            cmd1.ExecuteNonQuery();
            conn1.Close(); // Close the connection

           
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Quantity ");
            }
            else
            {



                foreach (string item2 in checkedListBox1.CheckedItems)
                {
                    checkedItems.Add(item2);

                }

                FetchValuesContinuously(checkedItems);
                //label2.Text = totalBill.ToString();
                Billing b1 = new Billing();

               this.Hide();
                b1.Show();
            }
        }

        private void ItemUpdate_Load(object sender, EventArgs e)
        {
            totalBill = 0;
            string connectionString = "Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True";
            string query = "SELECT P_name FROM tipan;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string value1 = reader.GetString(0); // Assuming the column is of string type
                            itemsList.Add(value1);
                        }
                    }
                }
                connection.Close();
            }
            PopulateChecklist();
            CheckAllItems();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage h1 = new HomePage();
            this.Hide();
            h1.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection s = new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");
            s.Open();
            String sss = "select P_id,P_name,Itemforperkg from tipan";
            SqlDataAdapter ad = new SqlDataAdapter(sss, s);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = "";
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter the Product id && new Minimum Quantity");
            }
            else
            {
              
                string query = $"SELECT P_name FROM tipan WHERE P_id = '{int.Parse(textBox2.Text)}';";
                SqlConnection conn= new SqlConnection("Data Source=LAPTOP-AH77IC68;Initial Catalog=BhoreAndSons;Integrated Security=True");

                try
                {
                    conn.Open(); // Open the connection before executing the query

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader.GetString(0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during the execution of the query
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    conn.Close(); // Close the connection after executing the query
                }

               
            }
            uq.Add(result, int.Parse(textBox3.Text));
            MessageBox.Show("Your product Quantity updated successfully !!");


        }
    }
}
