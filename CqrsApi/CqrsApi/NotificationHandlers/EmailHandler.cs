using Cto.Tutorial.CqrsApi.Database;
using Cto.Tutorial.CqrsApi.Notifications;
using Cto.Tutorial.CqrsApi.Seedwork;
using MediatR;
using Newtonsoft.Json;

namespace Cto.Tutorial.CqrsApi.NotificationHandlers
{
   public class EmailHandler :
      INotificationHandler<ProductCreatedNotification>
   {
      private readonly FakeEventStore _eventStore;

      public EmailHandler(FakeEventStore eventStore) =>
         _eventStore = eventStore;

      public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
      {
         await _eventStore.AddEvent(new DomainEvent("Email", JsonConvert.SerializeObject(notification.product)));
      }
   }
}
