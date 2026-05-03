using Newtonsoft.Json;

namespace TravelAgency.DataProcessor.ExportDtos.ExportCustomersThatHaveBookedHorseRidingTourPackage;

public class BookingsDto
{
    [JsonProperty("TourPackageName")]
    public string TourPackageName { get; set; } = null!;

    [JsonProperty("Date")]
    public string Date { get; set; } = null!;

}