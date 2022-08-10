using Cto.Tutorial.CleanArchitecture.Application.Commands;
using Cto.Tutorial.CleanArchitecture.Application.DataTransferModel;
using Cto.Tutorial.CleanArchitecture.Application.Queries;
using Cto.Tutorial.CleanArchitecture.Application.Services;
using Cto.Tutorial.CleanArchitecture.Tests.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Tests.Application
{
   [TestClass]
   public class SalesOrderCreationTests
   {
      [TestMethod]
      public void TestCreateSalesOrder()
      {
         var bootstrapper = new Bootstrapper();

         using (var scope = bootstrapper.Services.CreateScope())
         {
            // arrange
            var application = scope.ServiceProvider.GetRequiredService<IApplicationService>();

            // act
            var address = new AddressDto()
            {
               Name = "Test",
               AddressLine1 = "Testzeile 1",
               AddressLine2 = "Testzeile 2",
               AddressLine3 = "Testzeile 3",
               Street = "Street",
               ZipCode = "4711",
               City = "City",
               Country = "Country",
               CountryIsoCode = "DE"
            };
            var item = new OrderItemDto()
            {
               ProductId = Guid.NewGuid(),
               ProductName = "Test",
               UnitPrice = 10.0m,
               Currency = "EUR",
               QuantityOrdered = 1
            };
            var items = new List<OrderItemDto>();
            items.Add(item);  

            var orderGuid = application.ExecuteCommandAsync(new CreateSalesOrderCommand(DateTime.Now, address, items));

            // assert
            Assert.IsNotNull(orderGuid.Result);

            var result = application.ExecuteQueryAsync(new GetAllSalesOrdersQuery());

            Assert.IsNotNull(result);
            var orders = result.Result;
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Any());
            Assert.IsTrue(orders.Count() >= 1);
         }
      }
   }
}
