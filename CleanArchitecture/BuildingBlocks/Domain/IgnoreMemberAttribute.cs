namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
   public class IgnoreMemberAttribute :
      Attribute
   {
   }
}