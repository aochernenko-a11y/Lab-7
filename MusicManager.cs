using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lab_7
{
    public class MusicManager
    {
        public List<MusicTrack> Tracks { get; set; } = new List<MusicTrack>();

        public void SaveCsv(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("Title;Artist;Duration;Genre");
                foreach (var t in Tracks)
                    writer.WriteLine(t.ToString());
            }
        }

        public int LoadCsv(string path)
        {
            if (!File.Exists(path)) return 0;

            var lines = File.ReadAllLines(path);
            int added = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                var track = MusicTrack.ParseCsv(lines[i]);
                if (track != null)
                {
                    Tracks.Add(track);
                    added++;
                }
            }
            return added;
        }

        public void SaveJson(string path)
        {
            var json = JsonSerializer.Serialize(Tracks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public int LoadJson(string path)
        {
            if (!File.Exists(path)) return 0;

            var text = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<MusicTrack>>(text);

            if (data == null) return 0;

            Tracks.AddRange(data);
            return data.Count;
        }

        public void AddTrack()
        {
            Console.Write("Назва треку: ");
            string title = Console.ReadLine();

            Console.Write("Виконавець: ");
            string artist = Console.ReadLine();

            Console.Write("Тривалість (сек): ");
            int duration = int.Parse(Console.ReadLine());

            Console.Write("Жанр: ");
            string genre = Console.ReadLine();

            Tracks.Add(new MusicTrack(title, artist, duration, genre));
        }

        public void ShowAll()
        {
            if (Tracks.Count == 0)
            {
                Console.WriteLine("Список порожній.");
                return;
            }

            foreach (var t in Tracks)
                Console.WriteLine($"{t.Title} | {t.Artist} | {t.Duration}s | {t.Genre}");
        }

        public void Find()
        {
            Console.Write("Введіть назву треку: ");
            string name = Console.ReadLine();

            foreach (var t in Tracks)
                if (t.Title.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Знайдено: " + t.ToString());
                    return;
                }

            Console.WriteLine("Не знайдено.");
        }

        public void Sort()
        {
            Tracks.Sort((a, b) => a.Title.CompareTo(b.Title));
            Console.WriteLine("Відсортовано.");
        }

        public void Remove()
        {
            Console.Write("Введіть назву треку для видалення: ");
            string name = Console.ReadLine();

            Tracks.RemoveAll(t => t.Title.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Clear()
        {
            Tracks.Clear();
            Console.WriteLine("Колекцію очищено.");
        }
    }
}
