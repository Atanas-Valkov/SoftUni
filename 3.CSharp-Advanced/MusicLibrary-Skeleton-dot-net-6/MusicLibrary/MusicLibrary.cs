using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MusicLibrary
{
    public class MusicLibrary
    {
        public MusicLibrary(string name,int capacity )
        {
            Capacity = capacity;
            Name = name;
            Tracks = new List<Track>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Track> Tracks { get; set; }

        public void AddTrack(Track track)
        {
            bool isDuplicate = Tracks.Any(t => t.Title == track.Title && t.Artist == track.Artist);
            if (isDuplicate)
            {
                if (Tracks.Count < Capacity)
                {
                    Tracks.Add(track);
                }
            }
        }
        public bool RemoveTrack(string artist, string title )
        {
            Track track = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            if (track != null)
            {
                Tracks.Remove(track);
                return true;
            }
            return false;
        }
        public Track GetLongestTrack()
        {
            return Tracks.OrderByDescending(t => t.Duration).First();
        }
        public string GetTrackDetails(string title, string artist)
        {
            Track track = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            if (track != null)
            {
                return track.ToString();
            }
            return "Track not found.";
        }
        public int GetTracksCount()
        {
            return Tracks.Count;
        } public List<Track> GetTracksByGenre(string genre)
        {
            var list = Tracks.FindAll(t => t.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
            list.Sort((x, y) => x.Duration.CompareTo(y.Duration));
            return list;

        }

        public string LibraryReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Music Library: {Name}");
            sb.AppendLine($"Tracks capacity: {Capacity}");
            sb.AppendLine($"Number of tracks added: {Tracks.Count}");
            sb.AppendLine("Tracks:");

            foreach (var track in Tracks.OrderByDescending(t => t.Duration))
            {
                sb.AppendLine($"-{track}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
