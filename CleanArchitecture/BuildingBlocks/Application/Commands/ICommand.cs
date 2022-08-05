using MediatR;

namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Commands
{
   public interface ICommand :
      IRequest
   {
      Guid Id { get; }
   }
}