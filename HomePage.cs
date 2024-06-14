using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BhoreAndSons
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rate r1 = new Rate();
            this.Hide();
            r1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
         ItemUpdate i1 = new ItemUpdate();
            i1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewItems n1 = new NewItems();
            n1.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockAlert s1 = new StockAlert();
            s1.Show();
        }
    }
}
