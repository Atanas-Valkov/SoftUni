using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cadastre.Common.EntityValidation;

namespace Cadastre.Data.Models;

public class PropertyCitizen
{
    [ForeignKey(nameof(Property))]
    public int PropertyId { get; set; }
    public virtual Property Property { get; set; } = null!;


    [ForeignKey(nameof(Citizen))]
    public int CitizenId { get; set; }
    public virtual Citizen Citizen { get; set; } = null!;
}