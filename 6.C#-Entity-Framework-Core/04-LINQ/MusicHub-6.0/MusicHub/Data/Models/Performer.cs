using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static MusicHub.Common.EntityValidation.Performer;

namespace MusicHub.Data.Models;

public class Performer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(FirstNameMaxLength)]
    public string FirstName { get; set; } = null!;


    [Required]
    [MaxLength(LastNameMaxLength)]
    public string LastName { get; set; } = null!;


    public int Age { get; set; }

    [Precision(14, 4)]
    public decimal NetWorth { get; set; }

    public virtual ICollection<SongPerformer> PerformerSongs  { get; set; } = 
                new HashSet<SongPerformer>();


}