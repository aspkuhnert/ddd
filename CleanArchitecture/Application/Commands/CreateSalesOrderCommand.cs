using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Commands;

namespace Cto.Tutorial.CleanArchitecture.Application.Commands
{
   public class CreateSalesOrderCommand :
      CommandBase<Guid>
   {
      public DateTime OrderDate { get; }

      public AddressDto Address { get; }

      public List<OrderItemDto> Items { get; }

      public CreateSalesOrderCommand(DateTime orderDate, AddressDto address, List<OrderItemDto> orderItems)
      {
         OrderDate = orderDate;
         Address = address;
         Items = orderItems ?? new List<OrderItemDto>();
      }
   }
}