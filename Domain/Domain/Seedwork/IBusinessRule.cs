namespace Cto.Tutorial.Domain.Seedwork
{
   public interface IBusinessRule
   {
      bool IsBroken();

      string Message { get; }
   }
}