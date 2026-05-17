using Cadastre.Data.Models;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor.ExportDtos;

public class ExportPropertiesWithTheirOwnersDto
{
    [JsonProperty("PropertyIdentifier")]
    public string PropertyIdentifier { get; set; } = null!;

    [JsonProperty("Area")]
    public int Area { get; set; }

    [JsonProperty("Address")]
    public string Address { get; set; } = null!;

    [JsonProperty("DateOfAcquisition")]
    public string DateOfAcquisition { get; set; } = null!;

    [JsonProperty("Owners")]
    public CitizenDto[] Owners { get; set; } = null!;
}