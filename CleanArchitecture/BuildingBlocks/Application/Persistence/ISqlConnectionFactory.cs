using System.Data;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Persistence
{
   public interface ISqlConnectionFactory :
      IDisposable
   {
      IDbConnection GetOpenConnection();

      IDbConnection CreateNewConnection();

      string GetConnectionString();
   }
}