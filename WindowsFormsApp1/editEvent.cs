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
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class editEvent : Form
    {
        DataAccess dataAccess;
        String username;
        public editEvent()
        {
            InitializeComponent();
        }

        public editEvent(String uname)
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            this.username = uname;
            dataAccess = new DataAccess();
            loadEvent();
        }

        private void editEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }


        //load event form database
        public void loadEvent()
        {

            DataTable dataTable = new DataTable();
            string sql = "Select id,date,moddate,importance,story from event where username='" + username + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, dataAccess.connection);
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataAccess.Dispose();
            
        }

        //set event data for edit in table row click 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            textBox2.Text = row.Cells[0].Value.ToString();
            comboBox1.SelectedItem = row.Cells[3].Value.ToString();
            textBox1.Text = row.Cells[4].Value.ToString();

        }


        //add new event
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Empty Fields..");
            }
            else
            {
                try
                {
                    dataAccess = new DataAccess();
                    string sql = "UPDATE event SET importance='"+ comboBox1.SelectedItem.ToString() + "', moddate='"+ dateTimePicker1.Text + "',story='"+ textBox1.Text + "' Where id ='" + textBox2.Text + "'";
                    SqlCommand command = new SqlCommand(sql, dataAccess.connection);
                    
                    int result = command.ExecuteNonQuery();
                    dataAccess.Dispose();
                    if (result == 1)
                    {
                        clearText();
                        MessageBox.Show("Story update successfully.");
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

        public void clearText()
        {
            textBox2.Text = "";
            textBox1.Text = "";
        }

        //Refresh button click for load event
        private void button2_Click(object sender, EventArgs e)
        {
            loadEvent();
        }
    }
}
