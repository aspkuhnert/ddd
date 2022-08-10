using Cto.Tutorial.CleanArchitecture.BuildingBlocks.Domain;
using Cto.Tutorial.CleanArchitecture.Domain.Sales.Events;
using Cto.Tutorial.CleanArchitecture.Domain.Sales.Rules;

namespace Cto.Tutorial.CleanArchitecture.Domain.Sales
{
   public class SalesOrder :
      EntityBase,
      IAggregateRoot
   {
      public Guid Id { get; private set; }

      public SalesOrderStatus OrderStatus { get; private set; }

      private int _statusId;

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
         _orderItems = new List<SalesOrderItem>();
         NetTotal = Money.Of(0m, "EUR");
      }

      private SalesOrder(Guid id)
         : this()
      {
         Id = id;
      }

      public static SalesOrder CreateDraft()
      {
         var order = new SalesOrder();

         order._statusId = SalesOrderStatus.Started.Id;
         order.OrderDate = DateTime.Now;

         var domainEvent = new SalesOrderStartedDomainEvent(order.Id);
         order.Apply(domainEvent);
         order.AddDomainEvent(domainEvent);

         return order;
      }

      public static SalesOrder Create(Guid id, DateTime orderDate, Address placingCustomer)
      {
         var order = new SalesOrder(id);

         order._statusId = SalesOrderStatus.Copied.Id;

         var domainEvent = new SalesOrderCreatedDomainEvent(id, orderDate, placingCustomer);
         order.Apply(domainEvent);
         order.AddDomainEvent(domainEvent);

         return order;
      }

      public void AddOrderItem(Guid productId, string productName, decimal unitPrice, decimal quantityOrdered)
      {
         CheckRule(new SalesOrderMustNotBePostedRule(IsPosted));

         var item = SalesOrderItem.Create(productId, productName, unitPrice, quantityOrdered, Currency);
         _orderItems.Add(item);
      }

      public void AddAddress(Address address)
      {
         this.Address = address;
      }

      public void ChangeMainAttributes()
      {
      }

      public void Calculate()
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
      }

      public void Post()
      {
         Calculate();
         IsPosted = true;
      }

      public void AddItems(IEnumerable<SalesOrderItem> items)
      {
         _orderItems.AddRange(items);
      }

      protected override void Apply(IDomainEvent @event)
      {
         this.When((dynamic)@event);
      }

      private void When(SalesOrderStartedDomainEvent domainEvent)
      {
      }

      private void When(SalesOrderCreatedDomainEvent domainEvent)
      {
         OrderDate = domainEvent.OrderDate;
         Address = domainEvent.PlacingCustomer;
      }
   }
}