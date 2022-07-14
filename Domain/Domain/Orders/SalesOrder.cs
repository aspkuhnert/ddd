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
         _orderItems = new List<SalesOrderItem>();
         _statusId = SalesOrderStatus.Started.Id;
         OrderDate = DateTime.Now;
      }

      private SalesOrder(Guid id)
         : this()
      {
         Id = id;
      }

      public static SalesOrder CreateDraft()
      {
         return new SalesOrder();
      }

      public static SalesOrder Create(Guid id)
      {
         return new SalesOrder(id);
      }

      public SalesOrder AddOrderItem(Guid productId)
      {
         var item = SalesOrderItem.Create(productId);
         _orderItems.Add(item);

         return this;
      }

      public SalesOrder AddAddress(Address address)
      {
         this.Address = address;

         return this;
      }
   }
}
