using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static TravelAgency.Common.EntityValidation.TourPackage;
using static TravelAgency.Common.EntityValidation.Customer;


namespace TravelAgency.DataProcessor.ImportDtos;

public class ImportBookingsDto
{
    //[
    // {
    //   "BookingDate": "2024-09-21",
    //   "CustomerName": "Donald Sanders",
    //   "TourPackageName": "Horse Riding Tour"
    // },

    [Required]
    [JsonProperty("BookingDate")]
    public string BookingDate { get; set; } = null!;

    [Required]
    [JsonProperty("CustomerName")]
    [MinLength(FullNameMinLength)]
    [MaxLength(FullNameMaxLength)]
    public string CustomerName { get; set; } = null!;

    [Required]
    [JsonProperty("TourPackageName")]
    [MinLength(PackageNameMinLength)]
    [MaxLength(PackageNameMaxLength)]
    public string TourPackageName { get; set; } = null!;
}