using Cto.Tutorial.CleanArchitecture.Application.Commands;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Commands;
using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Application.CommandHandlers
{
   public class CreateSalesOrderCommandHandler :
      ICommandHandler<CreateSalesOrderCommand, Guid>
   {
      private readonly ISalesOrderRepository _orders;

      public CreateSalesOrderCommandHandler(ISalesOrderRepository orders)
      {
         _orders = orders;
      }

      public async Task<Guid> Handle(CreateSalesOrderCommand request, CancellationToken cancellationToken)
      {
         var result = default(Guid);

         var address = request.Address;
         var order = SalesOrder.Create(
            id: Guid.NewGuid(),
            orderDate: request.OrderDate,
            placingCustomer: new Address(
               address.Name,
               address.AddressLine1,
               address.AddressLine2,
               address.AddressLine3,
               address.Street,
               address.ZipCode,
               address.City,
               address.Country,
               address.CountryIsoCode));

         if (request.Items.Any())
         {
            var orderItems = new List<SalesOrderItem>();

            foreach (var item in request.Items)
            {
               var domainItem = SalesOrderItem.Create(item.ProductId);
               orderItems.Add(domainItem);
            }

            if (orderItems.Any())
            {
               order.AddItems(orderItems);
            }
         }

         result = order.Id;
         _orders.Add(order);

         await _orders.UnitOfWork.SaveChangesAndDispachEventsAsync(cancellationToken);

         return result;
      }
   }
}
