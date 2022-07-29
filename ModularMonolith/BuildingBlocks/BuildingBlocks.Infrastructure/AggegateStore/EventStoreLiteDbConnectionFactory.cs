namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.AggegateStore
{
   public class EventStoreLiteDbConnectionFactory :
      ILiteDbConnectionFactory
   {
      private string _connectionString;

      public string ConnectionString => _connectionString;

      public EventStoreLiteDbConnectionFactory(string connectionString)
      {
         _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
      }
   }
}