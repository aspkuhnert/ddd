namespace Cto.Tutorial.CleanArchitecture.Application.Commands
{
   public abstract class CommandBase :
      ICommand
   {
      public Guid Id { get; }

      protected CommandBase()
      {
         Id = Guid.NewGuid();
      }

      protected CommandBase(Guid id)
      {
         Id = id;
      }
   }
}