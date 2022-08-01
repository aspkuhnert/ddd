using Cto.Tutorial.Domain.Orders;
using Cto.Tutorial.Domain.Seedwork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   [TestClass]
   public class PostSalesOrderTests
   {
      [TestMethod]
      public void TestAddOrderItemAfterPostTheSalesOrderThrowsException()
      {
         var order = SalesOrder.Create(Guid.NewGuid(), "EUR", false, DateTime.Now.AddDays(-1));
         order.AddOrderItem(Guid.NewGuid(), "Book", 10.0m, 2);
         order.AddOrderItem(Guid.NewGuid(), "Smartphone", 30.0m, 1);

         order.Post();
         Assert.IsTrue(order.IsPosted);

         Assert.ThrowsException<BusinessRuleValidationException>(() => order.AddOrderItem(Guid.NewGuid(), "Shirt", 20.0m, 1));
      }
   }
}
