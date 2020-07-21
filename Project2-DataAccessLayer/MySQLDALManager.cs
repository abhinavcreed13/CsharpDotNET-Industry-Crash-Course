using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2_DataAccessLayer
{
    public class MySQLDALManager : IDAL
    {
        MySqlConnection connection;

        public MySQLDALManager(string connKey)
        {
            string dbConnString = ConfigurationManager.ConnectionStrings[connKey].ConnectionString;
            connection = new MySqlConnection(dbConnString);
        }

        //Online Mode
        public DataTable ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        // Offline Mode
        public DataTable ExecuteStoredProcedure(string procedureName)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = command;
                connection.Open();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                //throw ex;
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ExecuteStoredProcedure<T>(string procedureName, List<T> parameters) where T : DbParameter
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach(DbParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }
                adapter.SelectCommand = command;
                connection.Open();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
                //throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
