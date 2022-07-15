namespace Cto.Tutorial.CleanArchitecture.Application.DataTransferModel
{
   public record OrderItemDto
   {
      public Guid ProductId { get; init; }
   }
}