using Cto.Tutorial.Domain.Orders.Rules;
using Cto.Tutorial.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.Domain.Orders
{
   public class SalesOrder :
      EntityBase,
      IAggregateRoot
   {
      public Guid Id { get; private set; }

      public SalesOrderStatus OrderStatus { get; private set; }

      private int _statusId;

      public string OrderNumber { get; private set; }

      public string Currency { get; private set; }

      public bool IsPosted { get; private set; }

      public DateTime OrderDate { get; private set; }

      private readonly List<SalesOrderItem> _orderItems;

      public IReadOnlyCollection<SalesOrderItem> OrderItems => _orderItems;

      public Address Address { get; private set; }

      public Address ShipToAddress { get; private set; }

      public Address BillToAddress { get; private set; }

      public Money NetTotal { get; private set; }

      private SalesOrder()
      {
         Id = Guid.NewGuid();
         IsPosted = false;
         _orderItems = new List<SalesOrderItem>();
         _statusId = SalesOrderStatus.Started.Id;
         OrderDate = DateTime.Now;
         Currency = "EUR";
      }

      private SalesOrder(Guid id, string currency, bool isPosted, DateTime orderDate)
         : this()
      {
         Id = id;
      }

      public static SalesOrder CreateDraft()
      {
         return new SalesOrder();
      }

      public static SalesOrder Create(Guid id, string currency, bool isPosted, DateTime orderDate)
      {
         return new SalesOrder(id, currency, isPosted, orderDate);
      }

      public SalesOrder AddOrderItem(Guid productId, string productName, decimal unitPrice, decimal quantityOrdered)
      {
         CheckRule(new SalesOrderMustNotBePostedRule(IsPosted));

         var item = SalesOrderItem.Create(productId, productName, unitPrice, quantityOrdered, Currency);
         _orderItems.Add(item);

         return this;
      }

      public SalesOrder AddAddress(Address address)
      {
         this.Address = address;

         return this;
      }

      public SalesOrder Calculate()
      {
         if (_orderItems.Any())
         {
            decimal netTotal = 0;

            foreach (var item in _orderItems)
            {
               item.Calculate();
               netTotal += (decimal)item.NetPrice.Value;
            }

            NetTotal = Money.Of(netTotal, Currency);
         }
         else
         {
            NetTotal = Money.Of(0, Currency);
         }

         return this;
      }

      public SalesOrder Post()
      {
         Calculate();
         IsPosted = true;

         return this;
      }
   }
}
