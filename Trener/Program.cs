using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Trener
{
    class Program
    {
        // Az Exercise osztály reprezentálja egy edzés adatait
        public class Exercise
        {
            public string Date { get; set; }
            public string TypeOfExercise { get; set; }
            public int Length { get; set; }

            // Az Exercise osztály konstruktora
            public Exercise(string date, string typeOfExercise, int length)
            {
                Date = date;
                TypeOfExercise = typeOfExercise;
                Length = length;
            }
        }

        // Az edzéseket tároló lista
        static List<Exercise> exercise = new List<Exercise>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // A menüpontokat tartalmazó tömb
            string[] menuOptions = { "Új edzés", "Edzés történet", "Szűrő", "Statisztika", "Kilépés" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                DisplayMenu(menuOptions, selectedIndex);

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? menuOptions.Length - 1 : selectedIndex - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == menuOptions.Length - 1) ? 0 : selectedIndex + 1;
                        break;

                    case ConsoleKey.Enter:
                        if (selectedIndex == menuOptions.Length - 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Kilépés a programból...");
                            return;
                        }
                        else
                        {
                            HandleMenuSelection(menuOptions[selectedIndex]);
                        }
                        break;
                }
            }
        }

        // A menü kijelzéséért felelős függvény
        static void DisplayMenu(string[] menuOptions, int selectedIndex)
        {
            Console.SetCursorPosition((Console.WindowWidth - "+----------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+----------------+");
            Console.SetCursorPosition((Console.WindowWidth - "| Tréner Program |".Length) / 2, Console.CursorTop);
            Console.WriteLine("| Tréner Program |");
            Console.SetCursorPosition((Console.WindowWidth - "+----------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+----------------+");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine("");
                Console.SetCursorPosition((Console.WindowWidth - $"| {menuOptions[i]} |".Length) / 2, Console.CursorTop);
                Console.WriteLine($"| {menuOptions[i]} |");

                Console.ResetColor();
            }
        }

        // A menüpont kiválasztását kezelő függvény
        static void HandleMenuSelection(string selectedOption)
        {
            switch (selectedOption)
            {
                case "Új edzés":
                    Console.Clear();
                    HandleNewExercise();
                    break;

                case "Edzés történet":
                    Console.Clear();
                    FillUp();
                    DisplayExerciseHistory();
                    break;

                case "Szűrő":
                    Console.Clear();
                    HandleFilter();
                    break;

                case "Statisztika":
                    Console.Clear();
                    FillUp();
                    DisplayStatistics();
                    break;
            }
        }

        // Az új edzés hozzáadását kezelő függvény
        static void HandleNewExercise()
        {
            Console.Clear();

            Console.SetCursorPosition((Console.WindowWidth - "+---------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+---------------------------+");
            Console.SetCursorPosition((Console.WindowWidth - "| Tréner Program - Új edzés |".Length) / 2, Console.CursorTop);
            Console.WriteLine("| Tréner Program - Új edzés |");
            Console.SetCursorPosition((Console.WindowWidth - "+---------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+---------------------------+");

            Console.SetCursorPosition((Console.WindowWidth - "+----------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+----------------------------------+");

            Console.SetCursorPosition((Console.WindowWidth - "+----------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine($"| Dátum: ____.__.__. {"|",15}");

            string? date;

            while (true)
            {
                Console.SetCursorPosition(76, 4);
                date = Console.ReadLine();

                if (date == null || date == "")
                {
                    Console.SetCursorPosition(105, 4);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ne hagyja üresen ezt a mezőt!");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            Console.SetCursorPosition(90, 5);
            Console.SetCursorPosition((Console.WindowWidth - "+----------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("| Edzés formája: _________________ |");

            string? exerciseType;

            while (true)
            {
                Console.SetCursorPosition(84, 5);
                exerciseType = Console.ReadLine();

                if (exerciseType == null || exerciseType == "")
                {
                    Console.SetCursorPosition(105, 5);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ne hagyja üresen ezt a mezőt!");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            Console.SetCursorPosition(90, 6);
            Console.SetCursorPosition((Console.WindowWidth - "+----------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine($"| Edzés időtartama (percben): ___ {"|",2}");

            Console.SetCursorPosition((Console.WindowWidth - "+----------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+----------------------------------+");

            string exerciseLengthString;
            int exerciseLength;

            try
            {
                while (true)
                {
                    Console.SetCursorPosition(97, 6);
                    exerciseLength = Convert.ToInt32(Console.ReadLine());

                    if (exerciseLength <= 0)
                    {
                        Console.SetCursorPosition(105, 6);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Ne hagyja üresen ezt a mezőt!");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.SetCursorPosition(105, 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Probléma lépett fel az edzés időtartamának megadása során!");
                Console.ResetColor();
                return;
            }

            string path = @"mozgas.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{date};{exerciseType};{exerciseLength}");
            }

            Console.WriteLine("\nNyomjon egy billentyűt a folytatáshoz...");
            Console.ReadKey();
        }

        // Az edzéseket beolvasó és listába mentő függvény
        static void FillUp()
        {
            exercise.Clear();
            StreamReader sr = new StreamReader("mozgas.txt");

            while (!sr.EndOfStream)
            {
                string row = sr.ReadLine();
                string[] parts = row.Split(";");

                string date = parts[0];
                string exerciseType = parts[1];
                int exerciseLength = Convert.ToInt32(parts[2]);

                Exercise exercises = new Exercise(date, exerciseType, exerciseLength);
                exercise.Add(exercises);
            }

            sr.Close();
        }

        // Az edzéstörténet megjelenítését végző függvény
        static void DisplayExerciseHistory()
        {
            Console.Clear();

            Console.SetCursorPosition((Console.WindowWidth - "+---------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+---------------------------------+");
            Console.SetCursorPosition((Console.WindowWidth - "| Tréner Program - Edzés történet |".Length) / 2, Console.CursorTop);
            Console.WriteLine("| Tréner Program - Edzés történet |");
            Console.SetCursorPosition((Console.WindowWidth - "+---------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+---------------------------------+");

            Console.SetCursorPosition((Console.WindowWidth - "\n+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+----------------------+---------------------------+---------------------------+");
            Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine($"| Dátum {"| Edzés formája",30} {"| Edzés időtartama",30} {"|",10}");
            Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+----------------------+---------------------------+---------------------------+");

            foreach (var item in exercise)
            {
                Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
                Console.WriteLine($"| {item.Date} {"|",10} {item.TypeOfExercise,25} | {item.Length,25} |");
            }

            Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+----------------------+---------------------------+---------------------------+");
            Console.WriteLine("\nNyomjon egy billentyűt a kilépéshez...");
            Console.ReadKey();
        }

        // A szűrést végző függvény
        static void HandleFilter()
        {
            Console.Clear();

            List<string> submenuOptions = new List<string>();
            using (StreamReader sr = new StreamReader("mozgas.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(';');
                    if (columns.Length > 1 && !submenuOptions.Contains(columns[1]))
                    {
                        submenuOptions.Add(columns[1]);
                    }
                }
                submenuOptions.Add("Vissza");
            }

            int subMenuSelectedIndex = 0;
            bool backSelected = false;

            while (true)
            {
                Console.SetCursorPosition((Console.WindowWidth - "+------------------------+".Length) / 2, Console.CursorTop);
                Console.WriteLine("+------------------------+");
                Console.SetCursorPosition((Console.WindowWidth - "| Tréner Program - Szűrő |".Length) / 2, Console.CursorTop);
                Console.WriteLine("| Tréner Program - Szűrő |");
                Console.SetCursorPosition((Console.WindowWidth - "+------------------------+".Length) / 2, Console.CursorTop);
                Console.WriteLine("+------------------------+");

                for (int i = 0; i < submenuOptions.Count; i++)
                {
                    if (i == subMenuSelectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine("");
                    Console.SetCursorPosition((Console.WindowWidth - $"| {submenuOptions[i]} |".Length) / 2, Console.CursorTop);
                    Console.WriteLine($"| {submenuOptions[i]} |");

                    Console.ResetColor();
                }

                ConsoleKeyInfo subMenuKey = Console.ReadKey();

                switch (subMenuKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        subMenuSelectedIndex = (subMenuSelectedIndex == 0) ? submenuOptions.Count - 1 : subMenuSelectedIndex - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        subMenuSelectedIndex = (subMenuSelectedIndex == submenuOptions.Count - 1) ? 0 : subMenuSelectedIndex + 1;
                        break;

                    case ConsoleKey.Enter:
                        if (submenuOptions[subMenuSelectedIndex] == "Vissza")
                        {
                            backSelected = true;
                            break;
                        }
                        else
                        {
                            Console.Clear();

                            string selectedExerciseType = submenuOptions[subMenuSelectedIndex];

                            // Az edzéseket szűrjük a kiválasztott típus alapján
                            var filteredRows = File.ReadLines("mozgas.txt")
                                .Where(line => line.Split(';').Length > 1 && line.Split(';')[1].ToLower() == selectedExerciseType.ToLower())
                                .ToList();

                            Console.SetCursorPosition((Console.WindowWidth - "+------------------------+".Length) / 2, Console.CursorTop);
                            Console.WriteLine("+------------------------+");
                            Console.SetCursorPosition((Console.WindowWidth - "| Tréner Program - Szűrő |".Length) / 2, Console.CursorTop);
                            Console.WriteLine("| Tréner Program - Szűrő |");
                            Console.SetCursorPosition((Console.WindowWidth - "+------------------------+".Length) / 2, Console.CursorTop);
                            Console.WriteLine("+------------------------+");

                            Console.SetCursorPosition((Console.WindowWidth - "\n+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
                            Console.WriteLine("+----------------------+---------------------------+---------------------------+");
                            Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
                            Console.WriteLine($"| Dátum {"| Edzés formája",30} {"| Edzés időtartama",30} {"|",10}");
                            Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
                            Console.WriteLine("+----------------------+---------------------------+---------------------------+");

                            foreach (var row in filteredRows)
                            {
                                string[] columns = row.Split(';');
                                Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
                                Console.WriteLine($"| {columns[0]} {"|",10} {columns[1],25} | {columns[2],25} |");
                            }

                            Console.SetCursorPosition((Console.WindowWidth - "+----------------------+---------------------------+---------------------------+".Length) / 2, Console.CursorTop);
                            Console.WriteLine("+----------------------+---------------------------+---------------------------+");
                            Console.WriteLine("\nNyomjon egy billentyűt a kilépéshez...");
                            Console.ReadKey();
                            break;
                        }
                }

                if (backSelected)
                {
                    // Kilépés a ciklusból és visszatérés a főmenühöz
                    break;
                }

                Console.Clear();
            }
        }

        // A statisztikák megjelenítését végző függvény
        static void DisplayStatistics()
        {
            var groupedExercises = exercise.GroupBy(e => e.TypeOfExercise.ToLower());

            Console.SetCursorPosition((Console.WindowWidth - "+------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+------------------------------+");
            Console.SetCursorPosition((Console.WindowWidth - "| Tréner Program - Statisztika |".Length) / 2, Console.CursorTop);
            Console.WriteLine("| Tréner Program - Statisztika |");
            Console.SetCursorPosition((Console.WindowWidth - "+------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+------------------------------+");

            Console.SetCursorPosition((Console.WindowWidth - "\n+------------------------------------------------------------------------------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+--------------------+--------------------------+----------------+--------------+-----------------------+");
            Console.SetCursorPosition((Console.WindowWidth - "+-------------------------------------------------------------------------------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine($"| Edzés formája {"| Edzések száma",20} {"| Összidő",20} {"| Átlagos idő",20} {"| Leghosszabb edzés",20} {"|",5}");
            Console.SetCursorPosition((Console.WindowWidth - "+-------------------------------------------------------------------------------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+--------------------+--------------------------+----------------+--------------+-----------------------+");

            foreach (var group in groupedExercises)
            {
                int exerciseCount = group.Count();
                int totalDuration = group.Sum(e => e.Length);
                int averageDuration = exerciseCount > 0 ? totalDuration / exerciseCount : 0;
                int longestDuration = group.Max(e => e.Length);

                Console.SetCursorPosition((Console.WindowWidth - "+-------------------------------------------------------------------------------------------------------+".Length) / 2, Console.CursorTop);
                Console.WriteLine($"| {group.Key} {"|",14} {exerciseCount,24} | {totalDuration,14} | {averageDuration,12} | {longestDuration,21} |");
            }

            Console.SetCursorPosition((Console.WindowWidth - "+-------------------------------------------------------------------------------------------------------+".Length) / 2, Console.CursorTop);
            Console.WriteLine("+--------------------+--------------------------+----------------+--------------+-----------------------+");

            Console.WriteLine("\nNyomjon egy billentyűt a kilépéshez...");
            Console.ReadKey();
        }
    }
}
