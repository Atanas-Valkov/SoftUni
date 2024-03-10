using System.ComponentModel;

namespace P07L3.Songs
{
    public class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    internal class Program
    {
        static void Main(string[]args)
        {
            int numberOFSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();
            for (int i = 0; i < numberOFSongs; i++)
            {
                string[] token = Console.ReadLine()
                    .Split("_")
                    .ToArray();

                string typeList = token[0];
                string name  = token[1];
                string time = token[2];

                Song song = new Song(typeList,name,time);
                songs.Add(song);
            }

            string printOptions = Console.ReadLine();   

            if (printOptions == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == printOptions)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }


}