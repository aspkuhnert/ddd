using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Queries
{
   public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
   {
   }
}