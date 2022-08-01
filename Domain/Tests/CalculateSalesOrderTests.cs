using Cto.Tutorial.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.Domain.Tests
{
   [TestClass]
   public class CalculateSalesOrderTests
   {
      [TestMethod]
      public void TestCalculateSalesOrderOk()
      {
         var order = SalesOrder.Create(Guid.NewGuid(), "EUR", false, DateTime.Now.AddDays(-1));
         order.AddOrderItem(Guid.NewGuid(), "Book", 10.0m, 2);
         order.AddOrderItem(Guid.NewGuid(), "Smartphone", 30.0m, 1);

         order.Calculate();
         Assert.IsNotNull(order.NetTotal);
         Assert.AreEqual("EUR", order.NetTotal.Currency);
         Assert.AreEqual(order.NetTotal.Value, 50.0m);
      }
   }
}
