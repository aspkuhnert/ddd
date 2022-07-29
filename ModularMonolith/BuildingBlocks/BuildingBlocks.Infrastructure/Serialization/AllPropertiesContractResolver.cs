using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.Serialization
{
   public class AllPropertiesContractResolver :
      DefaultContractResolver
   {
      protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
      {
         var properties = type
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Select(p => this.CreateProperty(p, memberSerialization))
            .ToList();

         properties.ForEach(property =>
         {
            property.Writable = true;
            property.Readable = true;
         });

         return properties;
      }
   }
}