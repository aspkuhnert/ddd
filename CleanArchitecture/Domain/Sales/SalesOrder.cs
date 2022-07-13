using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales
{
   public class SalesOrder :
      EntityBase,
      IAggregateRoot
   {
      protected override void Apply(IDomainEvent @event)
      {
         throw new NotImplementedException();
      }
   }
}
