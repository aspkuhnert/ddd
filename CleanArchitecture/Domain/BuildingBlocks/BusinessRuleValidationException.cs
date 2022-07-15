using System.Runtime.Serialization;

namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   [Serializable]
   internal class BusinessRuleValidationException :
      Exception
   {
      private readonly IBusinessRule _rule;

      public BusinessRuleValidationException()
      {
      }

      public BusinessRuleValidationException(IBusinessRule rule)
      {
         _rule = rule;
      }

      public BusinessRuleValidationException(string message)
         : base(message)
      {
      }

      public BusinessRuleValidationException(string message, Exception innerException)
         : base(message, innerException)
      {
      }

      protected BusinessRuleValidationException(SerializationInfo info, StreamingContext context)
         : base(info, context)
      {
      }
   }
}