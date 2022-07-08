using Cto.Tutorial.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
   [TestClass]
   public class CreateSalesOrderTests
   {
      [TestMethod]
      public void TestCreateSalesOrderDraft()
      {
         var order = SalesOrder.CreateDraft();

         Assert.IsNotNull(order.Id);
         Assert.IsNotNull(order.OrderDate);
         Assert.IsNull(order.Address);
         Assert.IsNull(order.OrderStatus);
      }
   }
}