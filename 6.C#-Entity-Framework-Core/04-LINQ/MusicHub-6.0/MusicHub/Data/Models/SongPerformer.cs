using System.ComponentModel.DataAnnotations.Schema;
using static MusicHub.Common.EntityValidation;

namespace MusicHub.Data.Models;

public class SongPerformer
{
    [ForeignKey(nameof(Song))]
    public int SongId { get; set; }
    public Song Song { get; set; } = null!;

    [ForeignKey(nameof(Performer))]
    public int PerformerId { get; set; }
    public Performer Performer { get; set; } = null!;

}