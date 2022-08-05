using MediatR;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Commands
{
   public interface ICommandHandler<in TCommand> :
      IRequestHandler<TCommand>
      where TCommand : ICommand
   {
   }
}