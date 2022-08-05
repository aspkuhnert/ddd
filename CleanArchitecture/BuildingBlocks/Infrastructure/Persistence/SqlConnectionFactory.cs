using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Persistence;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Infrastructure.Persistence
{
   public class SqlConnectionFactory :
      ISqlConnectionFactory
   {
      private readonly string _connectionString;
      private IDbConnection _connection;

      public SqlConnectionFactory(string connectionString)
      {
         _connectionString = connectionString;
      }

      public IDbConnection GetOpenConnection()
      {
         if (_connection == null || _connection.State != ConnectionState.Open)
         {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
         }

         return _connection;
      }

      public IDbConnection CreateNewConnection()
      {
         var connection = new MySqlConnection(_connectionString);
         connection.Open();

         return connection;
      }

      public string GetConnectionString()
      {
         return _connectionString;
      }

      public void Dispose()
      {
         if (_connection != null && _connection.State == ConnectionState.Open)
         {
            _connection.Dispose();
         }
      }
   }
}
