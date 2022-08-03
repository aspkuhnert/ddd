using Cto.Tutorial.CqrsApi.Models;
using MediatR;

namespace Cto.Tutorial.CqrsApi.Notifications
{
   public record ProductCreatedNotification(Guid productId) : 
      INotification;
}
