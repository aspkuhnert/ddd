using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.Commands
{
   public interface ICommandHandler<in TCommand, TResult> :
      IRequestHandler<TCommand, TResult>
      where TCommand : ICommand<TResult>
   {
   }
}