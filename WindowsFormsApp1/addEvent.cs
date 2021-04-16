using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class addEvent : Form
    {
        String username;
        DataAccess dataAccess;
        public addEvent()
        {
            InitializeComponent();
        }

        public addEvent(String uname)
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            this.username = uname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Empty Fields");
            }
            else
            {
                
                try
                {
                    dataAccess = new DataAccess();
                    string sql = "INSERT INTO event(username,date,moddate,importance,story) " +
                        "VALUES('"+username+"','"+dateTimePicker1.Text+"','" + dateTimePicker1.Text + "','"+ comboBox1.SelectedItem.ToString() + "','"+ textBox1.Text + "')";
                    SqlCommand command = new SqlCommand(sql, dataAccess.connection);
                    int result = command.ExecuteNonQuery();
                    dataAccess.Dispose();
                    if (result == 1)
                    {
                        MessageBox.Show("New Story create successfully.");
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error occured..");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured.." + ex);
                }
            }
        }

        private void addEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
