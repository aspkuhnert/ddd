using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Application.DataTransferModel
{
   public class SalesOrderDto
   {
      public Guid SalesOrderId { get; set; }

      public string CustomerName { get; set; }
   }
}
