using System.ComponentModel.DataAnnotations;

namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;
    public class ImportSupplierDto
    {
        //"name": "3M Company",
        // "isImporter": true
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("isImporter" )]
        public string IsImporter { get; set; } = null!;

    }
}

