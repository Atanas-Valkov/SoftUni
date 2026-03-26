using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using static MusicHub.Common.EntityValidation.Song;
using Microsoft.EntityFrameworkCore;

namespace MusicHub.Data.Models;

public class Song
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public TimeSpan Duration { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public Genre Genre { get; set; }


    [ForeignKey(nameof(Album))]
    public int? AlbumId { get; set; }
    public virtual Album Album { get; set; } = null!;


    [ForeignKey(nameof(Writer))]
    public int WriterId { get; set; }
    public virtual Writer Writer { get; set; } = null!;


    [Required]
    [Precision(12, 4)]
    public decimal Price { get; set; }

    public virtual ICollection<SongPerformer> SongPerformers { get; set; } =
        new HashSet<SongPerformer>();



   
}

