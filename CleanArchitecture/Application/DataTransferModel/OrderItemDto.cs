namespace Cto.Tutorial.CleanArchitecture.Application.DataTransferModel
{
   public record OrderItemDto
   {
      public Guid ProductId { get; init; }

      public string ProductName { get; init; }

      public decimal UnitPrice { get; init; }

      public decimal QuantityOrdered { get; init; }

      public string Currency { get; init; }
   }
}