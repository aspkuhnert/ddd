using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.Commands
{
   public interface ICommand<out TResult> :
      IRequest<TResult>
   {
      Guid Id { get; }
   }
}