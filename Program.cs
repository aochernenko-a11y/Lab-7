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
                Console.WriteLine("6 – Static-методи (демо)");
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
