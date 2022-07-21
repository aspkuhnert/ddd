using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;
using Cto.Tutorial.CleanArchitecture.Application.Queries;
using Cto.Tutorial.CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cto.Tutorial.CleanArchitecture.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class SalesOrdersController : ControllerBase
   {
      private readonly IApplicationService _application;

      public SalesOrdersController(IApplicationService application)
      {
         _application = application;
      }

      [Route("All")]
      [HttpGet]
      [ProducesResponseType(typeof(List<SalesOrderDto>), StatusCodes.Status200OK)]
      public async Task<IActionResult> GetSalesOrdersByDate()
      {
         var result = await _application.ExecuteQueryAsync(new GetAllSalesOrdersQuery());

         return Ok(result);
      }
   }
}