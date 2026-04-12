using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportCarsDto
{
    //  "make": "Opel",
    // "model": "Omega",
    // "traveledDistance": 176664996,
    // "partsId": [
    //   38,
    //   102,
    //   23,
    //   116,
    //   46,
    //   68,
    //   88,
    //   104,
    //   71,
    //   32,
    //   114
    // ]

    [Required]
    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [Required]
    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [Required]
    [JsonProperty("traveledDistance")]
    public long TraveledDistance { get; set; }

    [JsonProperty("partsId")]
    public int[] PartsIds { get; set; } = null!;
}