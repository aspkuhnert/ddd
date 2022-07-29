namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Persistence
{
   public interface ILiteDbConnectionFactory
   {
      public string ConnectionString { get; }
   }
}