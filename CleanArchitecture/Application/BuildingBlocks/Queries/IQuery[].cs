using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.Queries
{
   public interface IQuery<out TResult> :
      IRequest<TResult>
   {
   }
}