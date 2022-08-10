using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;

namespace Cto.Tutorial.CleanArchitecture.Application.RequestModel
{
   public class CreateSalesOrderRequest
   {
      public DateTime OrderDate { get; set; }

      public AddressDto Address { get; set; }

      public List<OrderItemDto> Items { get; set; }

      public CreateSalesOrderRequest()
      {
         Items = new List<OrderItemDto>();
      }
   }
}