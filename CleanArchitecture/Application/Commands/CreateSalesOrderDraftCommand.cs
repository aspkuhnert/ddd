using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Commands;

namespace Cto.Tutorial.CleanArchitecture.Application.Commands
{
   public class CreateSalesOrderDraftCommand :
      CommandBase<SalesOrderDraftDto>
   {
   }
}