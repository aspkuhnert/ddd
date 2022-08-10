using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales.Rules
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