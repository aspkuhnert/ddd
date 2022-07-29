namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain
{
   public interface IRepository<TEntity>
      where TEntity : EntityBase
   {
      public IUnitOfWork UnitOfWork { get; }
   }
}