using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportCustomersDto
{
    // "name": "Emmitt Benally",
    // "birthDate": "1993-11-20T00:00:00",
    // "isYoungDriver": true
    [Required]
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty("birthDate")]
    public string BirthDate { get; set; } = null!;

    [Required]
    [JsonProperty("isYoungDriver")]
    public string IsYoungDriver { get; set; } = null!;
}