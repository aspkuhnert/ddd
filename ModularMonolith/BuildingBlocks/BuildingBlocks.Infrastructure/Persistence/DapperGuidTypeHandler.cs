using System.Data;

namespace Cto.Tutorial.ModularMonolith.BuildingBlocks.Infrastructure.Persistence
{
   public class DapperGuidTypeHandler :
      SqlMapper.TypeHandler<Guid>
   {
      public override Guid Parse(object value)
      {
         return Guid.Parse((string)value);
      }

      public override void SetValue(IDbDataParameter parameter, Guid value)
      {
         parameter.Value = value.ToString();
      }
   }
}