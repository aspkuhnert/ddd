using MediatR;

namespace Cto.Tutorial.CleanArchitecture.Application.Commands
{
   public interface ICommand :
      IRequest
   {
      Guid Id { get; }
   }
}