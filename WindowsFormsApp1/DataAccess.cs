using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DataAccess
    {
        

        public SqlConnection connection;
        private SqlCommand command;

        public DataAccess()
        {
            this.connection = new SqlConnection(@"Data source=DESKTOP-4NCSN8D\SQLEXPRESS;initial catalog=digitalDiary;integrated security=true;");

            this.connection.Open();
        }

        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql, this.connection);
            return this.command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql, this.connection);
            return this.command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
