using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.Domain.Seedwork
{
   public abstract class EntityBase
   {
      protected void CheckRule(IBusinessRule rule)
      {
         if (rule.IsBroken())
         {
            throw new BusinessRuleValidationException(rule);
         }
      }
   }
}
