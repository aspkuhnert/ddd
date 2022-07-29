namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain
{
   public interface IUnitOfWork :
      IDisposable
   {
      int SaveChanges();

      Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

      Task<bool> SaveChangesAndDispachEventsAsync(CancellationToken cancellationToken = default(CancellationToken));
   }
}