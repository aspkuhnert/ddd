namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain
{
   public interface IBusinessRule
   {
      bool IsBroken();

      string Message { get; }
   }
}