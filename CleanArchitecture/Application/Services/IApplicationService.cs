using Cto.Tutorial.CleanArchitecture.Application.Commands;
using Cto.Tutorial.CleanArchitecture.Application.Queries;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Commands;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Application.Services
{
   public interface IApplicationService
   {
      Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

      Task ExecuteCommandAsync(ICommand command);

      Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
   }
}
