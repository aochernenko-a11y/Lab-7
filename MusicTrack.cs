using System;
using System.Collections.Generic;

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

        // ============================================================
        //          CSV → OBJECT
        // ============================================================
        public static MusicTrack ParseCsv(string line)
        {
            var parts = line.Split(';');
            if (parts.Length != 4) return null;

            if (!int.TryParse(parts[2], out var duration))
                return null;

            return new MusicTrack(parts[0], parts[1], duration, parts[3]);
        }

        // ============================================================
        //          OBJECT → CSV
        // ============================================================
        public override string ToString()
        {
            return $"{Title};{Artist};{Duration};{Genre}";
        }

        // ============================================================
        //          STATIC METHODS (РЕАЛЬНІ РОБОЧІ)
        // ============================================================

        // 1. Форматування тривалості MM:SS
        public static string FormatDuration(int seconds)
        {
            if (seconds < 0) return "00:00";

            int m = seconds / 60;
            int s = seconds % 60;

            return $"{m:D2}:{s:D2}";
        }

        // 2. Допустимі жанри
        private static readonly string[] AllowedGenres =
        {
            "Pop", "Rock", "Rap", "Jazz", "Classical", "Electronic", "Metal"
        };

        public static bool IsValidGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return false;

            foreach (var g in AllowedGenres)
                if (g.Equals(genre, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }

        // 3. Середня тривалість треків у колекції
        public static double CalculateAverageDuration(List<MusicTrack> tracks)
        {
            if (tracks == null || tracks.Count == 0)
                return 0;

            double sum = 0;
            foreach (var t in tracks)
                sum += t.Duration;

            return sum / tracks.Count;
        }

        // 4. Нормалізація однієї назви (прибрати пробіли, виправити регістр)
        public static string NormalizeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return "";

            title = title.Trim();
            return char.ToUpper(title[0]) + title.Substring(1).ToLower();
        }

        // 5. Нормалізація ВСІХ назв у списку
        public static void NormalizeAllTitles(List<MusicTrack> tracks)
        {
            if (tracks == null) return;

            foreach (var t in tracks)
                t.Title = NormalizeTitle(t.Title);
        }

        // 6. Пошук по жанру
        public static List<MusicTrack> FindByGenre(List<MusicTrack> tracks, string genre)
        {
            List<MusicTrack> result = new List<MusicTrack>();

            if (!IsValidGenre(genre))
                return result;

            foreach (var t in tracks)
                if (t.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                    result.Add(t);

            return result;
        }
    }
}
