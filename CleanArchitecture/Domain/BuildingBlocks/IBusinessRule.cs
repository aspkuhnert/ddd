namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public interface IBusinessRule
   {
      bool IsBroken();

      string Message { get; }
   }
}