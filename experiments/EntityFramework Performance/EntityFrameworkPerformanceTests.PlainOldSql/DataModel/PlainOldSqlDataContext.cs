using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPerformanceTests.PlainOldSql.DataModel
{
    public class PlainOldSqlDataContext : IDisposable
    {
        public SqlConnection _connection { get; set; }

        public PlainOldSqlDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PlainOldSqlDataContext"].ToString();
            _connection = new SqlConnection(connectionString);
        }

        public PlainOldSqlDataContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public DataTable Query(string predicate)
        {
            


            // todo: sql injection fix
            var command = new SqlCommand(predicate);

            // Add the parameters for the SelectCommand.
            //command.Parameters.Add("@Country", SqlDbType.NVarChar, 15);
            //command.Parameters.Add("@City", SqlDbType.NVarChar, 15);
            var adapter = new SqlDataAdapter(predicate, _connection);
            //adapter.SelectCommand = command;
            var table = new DataTable();

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            adapter.Fill(table);

            _connection.Close();

            return table;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
