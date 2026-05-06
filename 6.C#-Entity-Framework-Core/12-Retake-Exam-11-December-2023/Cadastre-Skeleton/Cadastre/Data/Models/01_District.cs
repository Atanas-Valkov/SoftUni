using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Cadastre.Data.Enumerations;
using static Cadastre.Common.EntityValidation.District;
namespace Cadastre.Data.Models;

public class District
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(PostalCodeMaxLength)]
    public string PostalCode { get; set; } = null !;

    [Required]
    public Region Region { get; set; } 

    public virtual ICollection<Property> Properties { get; set; }
        = new List<Property>();

}