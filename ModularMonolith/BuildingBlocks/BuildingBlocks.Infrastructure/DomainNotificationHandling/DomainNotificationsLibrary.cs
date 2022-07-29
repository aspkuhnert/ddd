namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.DomainNotificationHandling
{
   public class DomainNotificationsLibrary :
      IDomainNotificationsLibrary
   {
      private readonly Dictionary<Type, Type> _notificationTypes;

      public DomainNotificationsLibrary()
      {
         _notificationTypes = new Dictionary<Type, Type>();
      }

      public void AddNotification(Type notificationType, Type implementationType)
      {
         _notificationTypes.Add(notificationType, implementationType);
      }

      public Type GetImplementationType(Type serviceType)
      {
         Type result;
         _notificationTypes.TryGetValue(serviceType, out result);

         return result;
      }
   }
}