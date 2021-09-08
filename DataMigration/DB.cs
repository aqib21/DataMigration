using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataMigration
{
    class DB
    {
        static SqlConnection conn;

        public static SqlConnection GetConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
                conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Dispose();
        }

        public static SqlCommand PrepareCommand(SqlConnection con, string commandName, CommandType commandType, int employeeID)
        {
            SqlCommand cmd = new SqlCommand(commandName, con)
            {
                CommandType = commandType,
                CommandTimeout = 0
            };

            if (employeeID >= 0)
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 4000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
            }

            return cmd;
        }

    }
}
