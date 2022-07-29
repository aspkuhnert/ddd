namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain
{
   public interface IBusinessRule
   {
      bool IsBroken();

      string Message { get; }
   }
}