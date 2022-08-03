using Cto.Tutorial.CqrsApi.Commands;
using Cto.Tutorial.CqrsApi.Models;
using Cto.Tutorial.CqrsApi.Notifications;
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
         var productId = await _mediator.Send(new CreateProductCommand(request));

         await _mediator.Publish(new ProductCreatedNotification(productId));

         return CreatedAtRoute("GetById", new { id = productId }, productId);
      }

      [Route("Products")]
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

      [Route("Events")]
      [HttpGet]
      public async Task<ActionResult> GetDomainEvents()
      {
         var events = await _mediator.Send(new GetDomainEventsQuery());

         return Ok(events);
      }
   }
}
