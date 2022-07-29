using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Commands
{
   public interface ICommand :
      IRequest
   {
      Guid Id { get; }
   }
}