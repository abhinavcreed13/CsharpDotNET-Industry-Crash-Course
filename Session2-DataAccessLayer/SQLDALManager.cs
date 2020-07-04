using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2_DataAccessLayer
{
    public class SQLDALManager : IDAL
    {
        SqlConnection connection;

        public SQLDALManager(string connKey)
        {
            string dbConnString = ConfigurationManager.ConnectionStrings[connKey].ConnectionString;
            connection = new SqlConnection(dbConnString);
        }

        public DataTable ExecuteQuery(string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return dt;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ExecuteStoredProcedure(string procedureName)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable data = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(data);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return data;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ExecuteStoredProcedure(string procedureName, List<SqlParameter> parameters)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable data = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                adapter.SelectCommand = cmd;
                adapter.Fill(data);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return data;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
