namespace MusicLibrary
{
    public class Track
    {
        public Track(string artist, string genre, int duration, string title )
        {
            Artist = artist;
            Duration = duration;
            Genre = genre;
            Title = title;
        }

        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"Track: '{Title}' by {Artist} - {Duration}s [{Genre}]";
        }
    }
}
