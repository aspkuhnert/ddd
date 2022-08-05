using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Application.Queries
{
   public class GetAllSalesOrdersQuery :
       QueryBase<List<SalesOrderDto>>
   {
   }
}
