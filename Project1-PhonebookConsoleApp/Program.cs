using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_PhonebookConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Phonebook App");

            //1. Connect SQL server
            //String dbConnString = @"Data Source=ABHINAVCREED-PC\SQLEXPRESS;Initial Catalog=creed;Integrated Security=True";
            //String dbConnString = ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString;

            //SqlConnection conn = new SqlConnection(dbConnString);

            //try
            //{
            //    conn.Open();
            //    Console.WriteLine("Connection Opened");
            //    conn.Close();
            //    //conn.Dispose();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    Console.ReadLine();
            //    Environment.Exit(0);
            //}

            //2. Fetch records using query
            // ONLINE connection process
            // String sqlQuery = "Select * from user_data";
            //conn.Open();
            //SqlCommand command = new SqlCommand(sqlQuery,conn);
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    //Console.WriteLine(reader.GetValue(0) + " , " + reader.GetValue(1));
            //    Console.WriteLine(
            //        string.Format("UserID: {0}, UserName: {1}",
            //        reader.GetValue(0), reader.GetValue(1)));
            //}
            //reader.Close();
            //command.Dispose();
            //conn.Close();

            //3. Fetch records into Datatable
            // Offline process
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, dbConnString);
            //DataTable data = new DataTable();
            //try
            //{
            //    conn.Open();
            //    dataAdapter.Fill(data);
            //    foreach(DataRow dr in data.Rows)
            //    {
            //        Console.WriteLine(
            //        string.Format("UserID: {0}, UserName: {1}",
            //        dr["user_id"], dr["user_name"]));
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}

            //4. Fetch records using storedprocedure
            // Offline process
            //SqlDataAdapter adapter2 = new SqlDataAdapter();
            //DataTable data2 = new DataTable();
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("getAllUsers", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    adapter2.SelectCommand = cmd;
            //    adapter2.Fill(data2);
            //    foreach (DataRow dr in data2.Rows)
            //    {
            //        Console.WriteLine(
            //        string.Format("UserID: {0}, UserName: {1}",
            //        dr["user_id"], dr["user_name"]));
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}

            //5. Fetch record for particular user
            //SqlDataAdapter adapter3 = new SqlDataAdapter();
            //DataTable data3 = new DataTable();
            //try
            //{
            //    Console.WriteLine("Enter User ID:");
            //    int userId = Convert.ToInt32(Console.ReadLine());
            //    SqlCommand cmd = new SqlCommand("getUser", conn);
            //    cmd.Parameters.Add(new SqlParameter("@userId", userId));
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    adapter3.SelectCommand = cmd;
            //    adapter3.Fill(data3);
            //    foreach (DataRow dr in data3.Rows)
            //    {
            //        Console.WriteLine(
            //        string.Format("UserID: {0}, UserName: {1}",
            //        dr["user_id"], dr["user_name"]));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}

            // Run previous results using DBManager
            String sqlQuery = "Select * from user_data";
            DbManager manager = new DbManager("dbConnString");

            DataTable data = manager.ExecuteQuery(sqlQuery);

            //DataTable data = manager.ExecuteStoredProcedure("getAllUsers");

            //Console.WriteLine("Enter User ID:");
            //int userId = Convert.ToInt32(Console.ReadLine());
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(new SqlParameter("@userId", userId));
            //DataTable data = manager.ExecuteStoredProcedure("getUser", parameters);

            foreach (DataRow dr in data.Rows)
            {
                Console.WriteLine(
                string.Format("UserID: {0}, UserName: {1}",
                dr["user_id"], dr["user_name"]));
            }

            Console.ReadLine();
        }
    }
}
