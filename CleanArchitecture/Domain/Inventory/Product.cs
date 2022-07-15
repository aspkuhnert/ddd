using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Inventory
{
   internal class Product :
      EntityBase,
      IAggregateRoot
   {
      protected override void Apply(IDomainEvent @event)
      {
         throw new NotImplementedException();
      }
   }
}