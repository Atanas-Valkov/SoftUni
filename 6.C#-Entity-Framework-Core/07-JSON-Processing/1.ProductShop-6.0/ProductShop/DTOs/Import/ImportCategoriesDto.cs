using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

public class ImportCategoriesDto
{
    [Required]
    [JsonProperty("Name")]
    public string Name { get; set; } = null!;
}