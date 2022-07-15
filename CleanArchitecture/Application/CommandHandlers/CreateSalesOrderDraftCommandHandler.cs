using Cto.Tutorial.CleanArchitecture.Application.Commands;
using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;
using Cto.Tutorial.CleanArchitecture.Domain.Sales;

namespace Cto.Tutorial.CleanArchitecture.Application.CommandHandlers
{
   public class CreateSalesOrderDraftCommandHandler :
      ICommandHandler<CreateSalesOrderDraftCommand, SalesOrderDraftDto>
   {
      private readonly ISalesOrderRepository _orders;

      public CreateSalesOrderDraftCommandHandler(ISalesOrderRepository orders)
      {
         _orders = orders;
      }

      public async Task<SalesOrderDraftDto> Handle(CreateSalesOrderDraftCommand request, CancellationToken cancellationToken)
      {
         var order = SalesOrder.CreateDraft();

         var result = SalesOrderDraftDto.FromSalesOrder(order);
         _orders.Add(order);

         await _orders.UnitOfWork.SaveChangesAndDispachEventsAsync(cancellationToken);

         return result;
      }
   }
}