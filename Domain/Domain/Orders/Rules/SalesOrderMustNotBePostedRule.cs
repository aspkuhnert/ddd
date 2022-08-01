using Cto.Tutorial.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.Domain.Orders.Rules
{
   public class SalesOrderMustNotBePostedRule :
      IBusinessRule
   {
      private readonly bool _isPosted;

      public string Message => "Sales order must not be posted.";

      public SalesOrderMustNotBePostedRule(bool isPosted)
      {
         _isPosted = isPosted;
      }

      public bool IsBroken() => _isPosted;
   }
}
