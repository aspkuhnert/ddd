using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public interface IRepository<TEntity>
      where TEntity : EntityBase
   {
      public IUnitOfWork UnitOfWork { get; }
   }
}
