using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Commands
{
   public interface ICommand<out TResult> :
      IRequest<TResult>
   {
      Guid Id { get; }
   }
}