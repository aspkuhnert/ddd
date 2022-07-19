using Cto.Tutorial.CleanArchitecture.Application.Commands;
using Cto.Tutorial.CleanArchitecture.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Application.Services
{
   public class ApplicationService :
      IApplicationService
   {
      private readonly IMediator _mediator;

      public ApplicationService(IMediator mediator)
      {
         _mediator = mediator;
      }

      public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
      {
         return await _mediator.Send(command);
      }

      public async Task ExecuteCommandAsync(ICommand command)
      {
         await _mediator.Send(command);
      }

      public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
      {
         return await _mediator.Send(query);
      }
   }
}
