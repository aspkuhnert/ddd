using Cto.Tutorial.CqrsApi.Commands;
using Cto.Tutorial.CqrsApi.Models;
using Cto.Tutorial.CqrsApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cto.Tutorial.CqrsApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ProductsController : ControllerBase
   {
      private readonly IMediator _mediator;

      public ProductsController(IMediator mediator) => _mediator = mediator;

      [HttpPost]
      public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
      {
         var productToReturn = await _mediator.Send(new CreateProductCommand(request));

         //await _mediator.Publish(new ProductAddedNotification(productToReturn));

         return CreatedAtRoute("GetById", new { id = productToReturn.Id }, productToReturn);
      }

      [HttpGet]
      public async Task<ActionResult> GetProducts()
      {
         var products = await _mediator.Send(new GetProductsQuery());

         return Ok(products);
      }

      [HttpGet("{id:Guid}", Name = "GetById")]
      public async Task<ActionResult> GetProductById(Guid id)
      {
         var product = await _mediator.Send(new GetProductByIdQuery(id));

         return Ok(product);
      }
   }
}
