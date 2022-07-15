using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Cto.Tutorial.CleanArchitecture.Domain.Sales.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cto.Tutorial.CleanArchitecture.Tests
{
   [TestClass]
   public class SalesOrderTests
   {
      [TestMethod]
      public void TestCreateSalesOrderDraft()
      {
         var order = SalesOrder.CreateDraft();

         Assert.IsNotNull(order);
         Assert.IsNotNull(order.DomainEvents);
         Assert.IsTrue(order.DomainEvents.Any());
         Assert.IsTrue(order.DomainEvents.Count == 1);

         var startedEvent = order.DomainEvents.FirstOrDefault();
         Assert.IsNotNull(startedEvent);
         Assert.IsInstanceOfType(startedEvent, typeof(SalesOrderStartedDomainEvent));

         Assert.IsNotNull(order.Id);
         Assert.IsNotNull(order.OrderDate);
         Assert.IsNull(order.Address);
         Assert.IsNull(order.OrderStatus);
      }
   }
}