using MediatR;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Queries
{
   public interface IQuery<out TResult> :
      IRequest<TResult>
   {
   }
}