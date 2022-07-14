namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
   public class IgnoreMemberAttribute :
      Attribute
   {
   }
}