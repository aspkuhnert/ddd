namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public interface IRepository<TEntity>
      where TEntity : EntityBase
   {
      public IUnitOfWork UnitOfWork { get; }
   }
}