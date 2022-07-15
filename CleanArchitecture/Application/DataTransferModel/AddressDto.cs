namespace Cto.Tutorial.CleanArchitecture.Application.DataTransferModel
{
   public record AddressDto
   {
      public string AddressLine1 { get; init; }

      public string AddressLine2 { get; init; }

      public string AddressLine3 { get; init; }

      public string City { get; init; }

      public string Country { get; init; }

      public string CountryIsoCode { get; init; }

      public string Name { get; init; }

      public string Street { get; init; }

      public string ZipCode { get; init; }
   }
}