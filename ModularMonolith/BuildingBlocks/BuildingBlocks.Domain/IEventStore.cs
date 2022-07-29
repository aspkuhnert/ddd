namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain
{
   public interface IEventStore
   {
      /// <summary>
      ///   Gets all events for the specified identifier.
      /// </summary>
      /// <param name="id">The identifier.</param>
      /// <returns>A list of domain events.</returns>
      IEnumerable<IDomainEvent> GetAllForId(string id);

      /// <summary>
      ///   Saves the specified domain event.
      /// </summary>
      /// <typeparam name="TEvent">The type of the event.</typeparam>
      /// <param name="domainEvent">The domain event.</param>
      void Save<TEvent>(TEvent domainEvent)
         where TEvent : IDomainEvent;

      /// <summary>
      ///   Saves many events.
      /// </summary>
      /// <typeparam name="TEvent">The type of the event.</typeparam>
      /// <param name="events">The events.</param>
      void SaveMany<TEvent>(IEnumerable<TEvent> events)
         where TEvent : IDomainEvent;
   }
}