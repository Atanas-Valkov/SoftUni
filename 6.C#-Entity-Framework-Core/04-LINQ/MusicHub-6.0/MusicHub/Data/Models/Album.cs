using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using static MusicHub.Common.EntityValidation.Album;


namespace MusicHub.Data.Models;

public class Album
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [NotMapped]
    public decimal Price => Songs.Sum(s => s.Price);

    public DateTime ReleaseDate { get; set; }

    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }
    public Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = 
        new HashSet<Song>();
}