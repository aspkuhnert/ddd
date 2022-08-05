using MediatR;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Commands
{
   public interface ICommandHandler<in TCommand, TResult> :
      IRequestHandler<TCommand, TResult>
      where TCommand : ICommand<TResult>
   {
   }
}