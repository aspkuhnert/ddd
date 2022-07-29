namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.DomainNotificationHandling
{
   public interface IDomainNotificationsLibrary
   {
      void AddNotification(Type notificationType, Type implementationType);

      Type GetImplementationType(Type serviceType);
   }
}