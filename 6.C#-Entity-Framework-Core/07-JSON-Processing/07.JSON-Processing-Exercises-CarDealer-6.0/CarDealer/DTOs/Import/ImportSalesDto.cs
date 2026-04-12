using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportSalesDto
{
    // "carId": 105,
    // "customerId": 30,
    // "discount": 30

    [JsonProperty("carId")]
    public int CarId { get; set; }

    [JsonProperty("customerId")]
    public int CustomerId { get; set; }

    [JsonProperty("discount")]
    public decimal Discount { get; set; } 
}