using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure.BuildingBlocks
{
   public interface IDomainNotificationsLibrary
   {
      void AddNotification(Type notificationType, Type implementationType);

      Type GetImplementationType(Type serviceType);
   }
}
