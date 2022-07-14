using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public interface IUnitOfWork :
      IDisposable
   {
      int SaveChanges();

      Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

      Task<bool> SaveChangesAndDispachEventsAsync(CancellationToken cancellationToken = default(CancellationToken));
   }
}
