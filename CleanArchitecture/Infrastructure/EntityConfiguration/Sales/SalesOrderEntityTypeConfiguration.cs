using Cto.Tutorial.CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Infrastructure.EntityConfiguration.Sales
{
   public class SalesOrderEntityTypeConfiguration :
      IEntityTypeConfiguration<SalesOrder>
   {
      public void Configure(EntityTypeBuilder<SalesOrder> orderConfiguration)
      {
         orderConfiguration
            .ToTable("sales_orders");

         orderConfiguration
            .HasKey(entity => entity.Id);

         orderConfiguration
            .Ignore(entity => entity.DomainEvents);

         orderConfiguration
            .Property(entity => entity.Id)
            .IsRequired()
            .HasColumnName("Id");

         orderConfiguration
            .Property<DateTime>("DateCreated")
            .HasDefaultValue(DateTime.Now);

         orderConfiguration
            .Property<DateTime>("DateUpdated")
            .HasDefaultValue(DateTime.Now);

         orderConfiguration
           .Property(entity => entity.OrderDate)
           .IsRequired();

         orderConfiguration
            .Property<int>("_statusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("OrderStatusId")
            .IsRequired();

         orderConfiguration
            .HasOne(entity => entity.OrderStatus)
            .WithMany()
            .HasForeignKey("_statusId");

         var navigation = orderConfiguration.Metadata.FindNavigation(nameof(SalesOrder.OrderItems));
         navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

         orderConfiguration
            .OwnsOne(entity => entity.Address,
               address =>
               {
                  address
                     .ToTable("sales_orderaddresses");
                  address
                     .WithOwner();
                  address
                     .Property<int>("Id")
                     .ValueGeneratedOnAdd();
                  address
                     .HasKey("Id");
               })
            .OwnsOne(entity => entity.BillToAddress,
               address =>
               {
                  address
                     .ToTable("sales_orderbilltoaddresses");
                  address
                     .WithOwner();
                  address
                     .Property<int>("Id")
                     .ValueGeneratedOnAdd();
                  address
                     .HasKey("Id");
               })
            .OwnsOne(entity => entity.ShipToAddress,
               address =>
               {
                  address
                     .ToTable("sales_ordershiptoaddresses");
                  address
                     .WithOwner();
                  address
                     .Property<int>("Id")
                     .ValueGeneratedOnAdd();
                  address
                     .HasKey("Id");
               });

         orderConfiguration
            .OwnsOne(entity => entity.NetTotal, money =>
            {
               money.Property(prop => prop.Value)
                  .HasColumnName("NetTotalAmount")
                  .HasPrecision(6, 2);
               money.Property(prop => prop.Currency)
                  .HasColumnName("NetTotalCurrencyCode")
                  .HasColumnType("char")
                  .HasMaxLength(3);
            });
      }
   }
}
