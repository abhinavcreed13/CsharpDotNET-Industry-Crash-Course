using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2_DataAccessLayer
{
    interface IDAL
    {
        DataTable ExecuteQuery(string query);
        DataTable ExecuteStoredProcedure(string procedureName);
        DataTable ExecuteStoredProcedure<T>(string procedureName, List<T> parameters) where T: DbParameter;
    }
}
