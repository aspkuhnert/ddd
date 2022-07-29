using System.Data;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Persistence
{
   public interface ISqlConnectionFactory :
      IDisposable
   {
      IDbConnection GetOpenConnection();

      IDbConnection CreateNewConnection();

      string GetConnectionString();
   }
}