using System.Data;

namespace Cto.Tutorial.CleanArchitecture.Application.BuildingBlocks.Persistence
{
   public interface ISqlConnectionFactory :
      IDisposable
   {
      IDbConnection GetOpenConnection();

      IDbConnection CreateNewConnection();

      string GetConnectionString();
   }
}