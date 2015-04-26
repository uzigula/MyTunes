using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyTunes.Repository.ADO
{
    public class SQLDatabaseContext : IDatabaseContext
    {
        private SqlConnection connection;

        public SQLDatabaseContext(string connectioString)
        {
            connection = new SqlConnection(connectioString);
            connection.Open();
        }
        public void ExecuteCommand(string command, Parameter[] parameters)
        {
            using(var sqlCommand = new SqlCommand())
            {
                sqlCommand.CommandText = command;
                sqlCommand.Connection = connection;
                foreach(var param in parameters)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(param.Name, param.Value));
                }

                sqlCommand.ExecuteNonQuery();
            }
            throw new NotImplementedException();
        }

        public System.Data.IDataReader ExecuteQuery(string query, Parameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string query, Parameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (connection.State==ConnectionState.Open )  connection.Close();
            connection = null;
        }
    }
}
