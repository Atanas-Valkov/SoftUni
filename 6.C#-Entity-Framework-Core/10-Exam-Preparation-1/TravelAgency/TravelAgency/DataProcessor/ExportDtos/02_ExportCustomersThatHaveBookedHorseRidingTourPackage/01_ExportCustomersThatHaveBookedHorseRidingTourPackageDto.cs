using Newtonsoft.Json;

namespace TravelAgency.DataProcessor.ExportDtos.ExportCustomersThatHaveBookedHorseRidingTourPackage;

public class ExportCustomersThatHaveBookedHorseRidingTourPackageDto
{
    [JsonProperty("FullName")]
    public string FullName { get; set; } = null!;

    [JsonProperty("PhoneNumber")]
    public string PhoneNumber { get; set; } = null!;

    [JsonProperty("Bookings")] 
    public BookingsDto[] Bookings { get; set; } = null!;
}