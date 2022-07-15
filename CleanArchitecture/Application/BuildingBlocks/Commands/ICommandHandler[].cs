using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.Commands
{
   public interface ICommandHandler<in TCommand> :
      IRequestHandler<TCommand>
      where TCommand : ICommand
   {
   }
}