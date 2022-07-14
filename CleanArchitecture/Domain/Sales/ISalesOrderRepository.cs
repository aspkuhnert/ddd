using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales
{
   public interface ISalesOrderRepository :
      IRepository<SalesOrder>
   {
      SalesOrder Add(SalesOrder order);

      SalesOrderItem AddItem(SalesOrderItem item, Guid salesOrderId);

      SalesOrder Attach(SalesOrder order);

      void ClearChangeTracker();

      Task<SalesOrder> GetByIdAsync(Guid id);

      void Update(SalesOrder order);

      void UpdateItem(SalesOrderItem item);
   }
}
