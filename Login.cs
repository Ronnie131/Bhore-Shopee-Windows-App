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

    public partial class LoginForm : Form
    {
        public static string username;
        public static string password;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            bool uservalidation = ValidateUsername(username);
            password = textBox2.Text;
            bool passwordvalidation = ValidatePassword(password);
            if(uservalidation && passwordvalidation)
            {
                this.Hide();
                ItemUpdate i1 = new ItemUpdate();
                HomePage h1 = new HomePage();
                h1.Show();
            }
            else
            {
                MessageBox.Show("Please Enter valid username or password");

            }
            
        }
        private bool ValidateUsername(string username)
        {
            // Add your validation logic here
            // For example, check if the username meets certain criteria (e.g., alphanumeric and at least 4 characters)
            bool isValid = !string.IsNullOrEmpty(username) && username.Length >= 4 && username.All(c => char.IsLetterOrDigit(c));
            return isValid;
        }

        private bool ValidatePassword(string password)
        {
            // Add your validation logic here
            // For example, check if the password meets certain criteria (e.g., at least 8 characters, containing both letters and digits)
            bool hasLetter = false;
            bool hasDigit = false;

            if (password.Length >= 8)
            {
                foreach (char c in password)
                {
                    if (char.IsLetter(c))
                    {
                        hasLetter = true;
                    }
                    else if (char.IsDigit(c))
                    {
                        hasDigit = true;
                    }

                    if (hasLetter && hasDigit)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
