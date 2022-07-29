using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Commands
{
   public interface ICommandHandler<in TCommand, TResult> :
      IRequestHandler<TCommand, TResult>
      where TCommand : ICommand<TResult>
   {
   }
}