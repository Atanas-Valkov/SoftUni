using System.Globalization;
using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            // string result = ExportAlbumsInfo(context, 9);

            string result = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,

                    AlbumSongs = a.Songs
                        .Select(s => new
                        {
                            s.Name,
                            s.Price,
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToList(),

                    TotalPrice = a.Songs.Sum(s => s.Price)
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToList();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;
                foreach (var song in album.AlbumSongs)
                {

                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {

            var songNames = context.Songs
                .Select(s => new
                {
                    s.Name,
                    WriterName = s.Writer.Name,
                    PerformerSong = s.SongPerformers
                        .Select(sp => new
                        {
                            sp.Performer.FirstName,
                            sp.Performer.LastName
                        })
                        .OrderBy(p => p.FirstName)
                        .ThenBy(p => p.LastName)
                        .ToList(),
                    AlbumProducer = s.Album != null ?
                        (s.Album.Producer != null ? s.Album.Producer.Name : null) : null,
                    s.Duration
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int counter = 1;
            foreach (var song in songNames)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}"); 

                foreach (var p in song.PerformerSong)
                {
                    sb.AppendLine($"---Performer: {p.FirstName} {p.LastName}");
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
