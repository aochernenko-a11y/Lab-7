using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Lab_7
{
    public class MusicTrack
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        public MusicTrack() { }

        public MusicTrack(string title, string artist, int duration, string genre)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title};{Artist};{Duration};{Genre}";
        }

        public static MusicTrack ParseCsv(string line)
        {
            var parts = line.Split(';');
            if (parts.Length != 4) return null;

            if (!int.TryParse(parts[2], out var duration)) return null;

            return new MusicTrack(parts[0], parts[1], duration, parts[3]);
        }
    }
}
