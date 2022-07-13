using Cto.Tutorial.CqrsApi.Database;
using Cto.Tutorial.CqrsApi.Notifications;
using Cto.Tutorial.CqrsApi.Seedwork;
using MediatR;
using Newtonsoft.Json;

namespace Cto.Tutorial.CqrsApi.NotificationHandlers
{
   public class ProductCreatedNotificationHandler :
      INotificationHandler<ProductCreatedNotification>
   {
      private readonly FakeEventStore _eventStore;

      public ProductCreatedNotificationHandler(FakeEventStore eventStore) => 
         _eventStore = eventStore;

      public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
      {
         await _eventStore.AddEvent(new DomainEvent("ProductCreatedNotification", JsonConvert.SerializeObject(notification.product)));
      }
   }
}
