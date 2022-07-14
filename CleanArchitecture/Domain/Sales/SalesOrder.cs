using Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks;
using Cto.Tutorial.CleanArchitecture.Domain.Sales.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales
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

         var domainEvent = new SalesOrderStartedDomainEvent(Id);
         Apply(domainEvent);
         AddDomainEvent(domainEvent);
      }

      private SalesOrder(Guid id)
         : this()
      {
         Id = id;
      }

      private SalesOrder(Guid id, string orderNumber, Address placingCustomer)
         : this(id)
      {
         _orderItems = new List<SalesOrderItem>();
         _statusId = SalesOrderStatus.Started.Id;
         OrderDate = DateTime.Now;

         var domainEvent = new SalesOrderCreatedDomainEvent(Id, orderNumber, placingCustomer);
         Apply(domainEvent);
         AddDomainEvent(domainEvent);
      }

      public static SalesOrder CreateDraft()
      {
         return new SalesOrder();
      }

      public static SalesOrder Create(Guid id, string orderNumber, Address customer)
      {
         return new SalesOrder(id, orderNumber, customer);
      }

      public void SetSalesOrderNumber()
      {
      }

      public void AddItem(Guid productId)
      {
         // (string productId, string productName, decimal unitPrice, decimal discount, decimal units = 1m)
         var item = SalesOrderItem.Create(productId);
         _orderItems.Add(item);
      }

      protected override void Apply(IDomainEvent @event)
      {
         throw new NotImplementedException();
      }
   }
}
