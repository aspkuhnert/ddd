using Cto.Tutorial.CleanArchitecture.Domain.Sales;

namespace Cto.Tutorial.CleanArchitecture.Application.DataTransferModel
{
   public record SalesOrderDraftDto
   {
      public static SalesOrderDraftDto FromSalesOrder(SalesOrder order)
      {
         return new SalesOrderDraftDto();
      }
   }
}