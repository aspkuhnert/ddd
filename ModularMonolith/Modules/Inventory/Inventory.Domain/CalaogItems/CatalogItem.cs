using Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain;

namespace Cto.Tutorial.ModularMonolith.Inventory.Domain.CalaogItems
{
   public class CatalogItem :
      EntityBase,
      IAggregateRoot
   {
      protected override void Apply(IDomainEvent @event)
      {
         throw new NotImplementedException();
      }
   }
}