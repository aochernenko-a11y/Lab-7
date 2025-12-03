using System;
using System.Text;

namespace Lab_7
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            MusicManager m = new MusicManager();

            while (true)
            {
                Console.WriteLine("\n--- МЕНЮ ---");
                Console.WriteLine("1 – Додати трек");
                Console.WriteLine("2 – Переглянути всі треки");
                Console.WriteLine("3 – Знайти трек");
                Console.WriteLine("4 – Відсортувати треки");
                Console.WriteLine("5 – Видалити трек");
                Console.WriteLine("6 – Static-методи");
                Console.WriteLine("7 – Зберегти у файл");
                Console.WriteLine("8 – Зчитати з файлу");
                Console.WriteLine("9 – Очистити колекцію");
                Console.WriteLine("0 – Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": m.AddTrack(); break;
                    case "2": m.ShowAll(); break;
                    case "3": m.Find(); break;
                    case "4": m.Sort(); break;
                    case "5": m.Remove(); break;
                    case "6":
                        Console.WriteLine("\n=== Операції над колекцією ===");
                        Console.WriteLine("1 – Нормалізувати назви всіх треків");
                        Console.WriteLine("2 – Знайти треки за жанром");
                        Console.WriteLine("3 – Порахувати середню тривалість");
                        Console.Write("Ваш вибір: ");

                        string sub = Console.ReadLine();

                        if (sub == "1")
                        {
                            MusicTrack.NormalizeAllTitles(m.Tracks);
                            Console.WriteLine("Назви нормалізовано.");
                        }
                        else if (sub == "2")
                        {
                            Console.Write("Жанр: ");
                            string g = Console.ReadLine();

                            var found = MusicTrack.FindByGenre(m.Tracks, g);

                            if (found.Count == 0)
                                Console.WriteLine("Немає треків цього жанру.");
                            else
                            {
                                Console.WriteLine("Знайдені треки:");
                                foreach (var t in found)
                                    Console.WriteLine($"{t.Title} | {t.Artist} | {t.Duration}s | {t.Genre}");
                            }
                        }
                        else if (sub == "3")
                        {
                            double avg = MusicTrack.CalculateAverageDuration(m.Tracks);
                            Console.WriteLine($"Середня тривалість: {avg:F2} сек.");
                        }

                        break;

                    case "7":
                        Console.WriteLine("1 - у CSV");
                        Console.WriteLine("2 - у JSON");
                        Console.Write("Вибір: ");
                        var sv = Console.ReadLine();
                        if (sv == "1") m.SaveCsv("tracks.csv");
                        else if (sv == "2") m.SaveJson("tracks.json");
                        break;

                    case "8":
                        Console.WriteLine("1 - з CSV");
                        Console.WriteLine("2 - з JSON");
                        Console.Write("Вибір: ");
                        var ld = Console.ReadLine();
                        if (ld == "1") Console.WriteLine("Зчитано: " + m.LoadCsv("tracks.csv"));
                        else if (ld == "2") Console.WriteLine("Зчитано: " + m.LoadJson("tracks.json"));
                        break;

                    case "9": m.Clear(); break;
                    case "0": return;
                }
            }
        }
    }
}
