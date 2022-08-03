using Cto.Tutorial.CqrsApi.Models;
using MediatR;

namespace Cto.Tutorial.CqrsApi.Commands
{
   public record CreateProductCommand(CreateProductRequest Product) :
      IRequest<Guid>
   {
   }
}
