namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain
{
   public interface IUnitOfWork :
      IDisposable
   {
      int SaveChanges();

      Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

      Task<bool> SaveChangesAndDispachEventsAsync(CancellationToken cancellationToken = default);
   }
}