using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks.DomainNotifications
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
