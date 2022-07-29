using Cto.Tutorial.ModularMonolith.BuildingBlocks.Domain;
using Newtonsoft.Json;
using System.Reflection;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.AggegateStore
{
   public class LiteDbEventStore :
      IEventStore
   {
      private readonly string _connectionString;

      private IDictionary<string, Type> eventTypeCache;

      public LiteDbEventStore(EventStoreLiteDbConnectionFactory connectionFactory)
      {
         _connectionString = connectionFactory?.ConnectionString ?? throw new ArgumentNullException(nameof(connectionFactory));
         eventTypeCache = new Dictionary<string, Type>();
      }

      public IEnumerable<IDomainEvent> GetAllForId(string id)
      {
         using (var database = new LiteDatabase(_connectionString))
         {
            var collection = database.GetCollection("Events");

            var result = collection.Find(Query.EQ("ModelId", id));
            var events = new List<IDomainEvent>();

            foreach (var item in result)
            {
               Type type;
               TryGetEventType(item["EventTypeName"].AsString, out type);

               object domainEvent;
               if (type != null)
               {
                  domainEvent = Deserialize(item["Content"].AsString, type);
                  events.Add(domainEvent as IDomainEvent);
               }
            }

            return events;
         }
      }

      public void Save<TEvent>(TEvent domainEvent)
         where TEvent : IDomainEvent
      {
         using (var database = new LiteDatabase(_connectionString))
         {
            var collection = database.GetCollection("Events");

            var document = new BsonDocument();
            document["_id"] = ObjectId.NewObjectId();
            document["ModelId"] = domainEvent.ModelId;
            document["EventTypeName"] = domainEvent.GetType().FullName;
            document["Content"] = Serialize(domainEvent);

            collection.Insert(document);
         }
      }

      public void SaveMany<TEvent>(IEnumerable<TEvent> events)
         where TEvent : IDomainEvent
      {
         foreach (var domainEvent in events)
         {
            Save(domainEvent);
         }
      }

      private string Serialize(object input)
      {
         return JsonConvert.SerializeObject(input, Formatting.Indented);
      }

      private bool TryGetEventType(string typeName, out Type type)
      {
         type = default;

         lock (eventTypeCache)
         {
            if (!eventTypeCache.TryGetValue(typeName, out type))
            {
               foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
               {
                  type = assembly.GetType(typeName);

                  if (type != null)
                     break;
               }

               eventTypeCache[typeName] = type;
            }
         }

         return type != null;
      }

      private object Deserialize(string input, Type targetType)
      {
         return JsonConvert.DeserializeObject(input, targetType);
      }
   }
}