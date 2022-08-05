using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Persistence;
using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Queries;
using Dapper;

namespace Cto.Tutorial.CleanArchitecture.Application.Queries
{
   public class GetAllSalesOrdersQueryHandler :
      IQueryHandler<GetAllSalesOrdersQuery, List<SalesOrderDto>>
   {
      private readonly ISqlConnectionFactory _sqlConnectionFactory;

      public GetAllSalesOrdersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
      {
         _sqlConnectionFactory = sqlConnectionFactory;
      }

      public async Task<List<SalesOrderDto>> Handle(GetAllSalesOrdersQuery request, CancellationToken cancellationToken)
      {
         var connection = _sqlConnectionFactory.GetOpenConnection();

         return (await connection.QueryAsync<SalesOrderDto>(
                "SELECT " +
                $"Id AS {nameof(SalesOrderDto.SalesOrderId)} " +
                "FROM cto_tutorial.sales_orders;"))
                .AsList();
      }
   }
}