using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class signUpForm : Form
    {
        DataAccess dataAccess;
        public signUpForm()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if(nametxt.Text.Equals("") || usernameTxt.Text.Equals("") || passwordTxt.Text.Equals(""))
            {
                MessageBox.Show("Empty Fields");
            }
            else
            {
                dataAccess = new DataAccess();
                string sql = "INSERT INTO login(name,username,password) VALUES('" + nametxt.Text + "','" + usernameTxt.Text + "', '" + passwordTxt.Text + "')";
                int result = dataAccess.ExecuteQuery(sql);
                dataAccess.Dispose();
                if (result==1)
                {
                    clearText();
                    MessageBox.Show("Account Created Successful");
                }
                else
                {
                    MessageBox.Show("Something going wrong!");
                }
               
            }
        }

        private void signUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void clearText()
        {
            nametxt.Text = "";
            usernameTxt.Text = "";
            passwordTxt.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}
