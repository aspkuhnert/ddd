using MediatR;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Application.Queries
{
   public interface IQuery<out TResult> :
      IRequest<TResult>
   {
   }
}