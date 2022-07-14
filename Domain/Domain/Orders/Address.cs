using Cto.Tutorial.Domain.Seedwork;

namespace Cto.Tutorial.Domain.Orders
{
   public class Address :
      ValueObjectBase
   {
      private Address()
      {
      }

      public Address(string name, string line1, string line2, string line3, string street, string postalCode, string city, string country, string countryIsoCode)
         : this()
      {
         Name = name;
         AddressLine1 = line1;
         AddressLine2 = line2;
         AddressLine3 = line3;
         Street = street;
         ZipCode = postalCode;
         City = city;
         Country = country;
         CountryIsoCode = countryIsoCode;
      }

      public string AddressLine1 { get; private set; }

      public string AddressLine2 { get; private set; }

      public string AddressLine3 { get; private set; }

      public string City { get; private set; }

      public string Country { get; private set; }

      public string CountryIsoCode { get; private set; }

      public string Name { get; private set; }

      public string Street { get; private set; }

      public string ZipCode { get; private set; }
   }
}