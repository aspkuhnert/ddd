using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.Queries
{
   public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
   {
   }
}