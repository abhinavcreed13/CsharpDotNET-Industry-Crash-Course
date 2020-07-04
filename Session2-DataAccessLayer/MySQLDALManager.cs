using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2_DataAccessLayer
{
    class MySQLDALManager : IDAL
    {
        public DataTable ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteStoredProcedure(string procedureName)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteStoredProcedure(string procedureName, List<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
