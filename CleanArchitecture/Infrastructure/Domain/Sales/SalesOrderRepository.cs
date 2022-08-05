using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;
using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure.Domain.Sales
{
   public class SalesOrderRepository :
      ISalesOrderRepository
   {
      private readonly TutorialContext _context;

      private readonly ILoggerFactory _logger;

      public SalesOrderRepository(TutorialContext context, ILoggerFactory logger)
      {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      }

      public IUnitOfWork UnitOfWork => _context;

      public SalesOrder Add(SalesOrder order)
      {
         if (order == null)
         {
            throw new ArgumentNullException(nameof(order));
         }

         var result = _context.SalesOrders.Add(order).Entity;

         //if (order.DeliverSalesOrderItems != null)
         //{
         foreach (var item in order.OrderItems)
         {
            _context.Entry(item).State = EntityState.Added;
         }
         //}

         return result;
      }

      public SalesOrderItem AddItem(SalesOrderItem item, Guid salesOrderId)
      {
         // setting the shadow navigation property value
         _context.Entry(item).Property("SalesOrderId").CurrentValue = salesOrderId;
         return _context.SalesOrderItems.Add(item).Entity;
      }

      public SalesOrder Attach(SalesOrder order)
      {
         return _context.Attach(order).Entity;
      }

      public void ClearChangeTracker()
      {
         _context.ChangeTracker.Clear();
      }

      public async Task<SalesOrder> GetByIdAsync(Guid id)
      {
         SalesOrder order = null;

         try
         {
            order = await _context
               .SalesOrders
               .Where(order => order.Id == id)
               .Include(order => order.Address)
               .FirstOrDefaultAsync();
         }
         catch (Exception ex)
         {
            _logger
               .CreateLogger<SalesOrderRepository>()
               .LogError(ex.Message);
         }

         if (order == null)
         {
            order = _context
               .SalesOrders
               .Local
               .FirstOrDefault(o => o.Id == id);
         }

         if (order != null)
         {
            await _context
               .Entry(order)
               .Collection(entity => entity.OrderItems)
               .LoadAsync();

            await _context
               .Entry(order)
               .Reference(entity => entity.OrderStatus)
               .LoadAsync();
         }

         return order;
      }

      public void Update(SalesOrder order)
      {
         _context.Entry(order).Property("DateUpdated").CurrentValue = DateTime.Now;
         _context.Entry(order).State = EntityState.Modified;

         //foreach (var item in order.OrderItems)
         //{
         //   var state = _context.Entry(item).State;
         //}
      }

      public void UpdateItem(SalesOrderItem item)
      {
         _context.Entry(item).Property("DateUpdated").CurrentValue = DateTime.Now;
         _context.Entry(item).State = EntityState.Modified;

         //foreach(var info in item.DeliverabilityInfos)
         //{
         //   var x = info;
         //}
      }
   }
}