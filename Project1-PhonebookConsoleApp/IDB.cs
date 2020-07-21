using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_PhonebookConsoleApp
{
    interface IDB
    {
        DataTable ExecuteQuery(string query);
        DataTable ExecuteStoredProcedure(string procedureName);
        DataTable ExecuteStoredProcedure(string procedureName, List<SqlParameter> parameters);
    }
}
