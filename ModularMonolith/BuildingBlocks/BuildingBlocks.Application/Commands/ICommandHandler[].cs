using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Commands
{
   public interface ICommandHandler<in TCommand> :
      IRequestHandler<TCommand>
      where TCommand : ICommand
   {
   }
}