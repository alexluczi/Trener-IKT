using System;
using System.Collections.Generic;
using System.IO;
using static Trener.Program;

namespace Trener;

class Program
{
    public class Exercise
    {
        public string Date { get; set; }
        public string TypeOfExercise { get; set; }
        public int Length { get; set; }

        public Exercise(string date, string typeOfExercise, int length)
        {
            Date = date;
            TypeOfExercise = typeOfExercise;
            Length = length;
        }
    }

    static List<Exercise> exercise = new List<Exercise>();

    static void fillUp()
    {
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

    static void Main(string[] args)
    {
        fillUp();
        Console.CursorVisible = false;

        string[] menuOptions = { "Új edzés", "Edzés történet", "Szűrő", "Statisztika", "Kilépés" };
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
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
                        // Exit the program
                        Console.Clear();
                        Console.WriteLine("Kilépés a programból...");
                        return;
                    }
                    else
                    {
                        if (menuOptions[selectedIndex] == "Új edzés")
                        {
                            Console.Clear();
                            Console.WriteLine("Új edzés");
                            Console.Write("Dátum: ");
                            string? date = Console.ReadLine();
                            Console.Write("Edzés formája: ");
                            string? exerciseType = Console.ReadLine();
                            Console.Write("Edzés időtartama (percben): ");
                            int exerciseLength = Convert.ToInt32(Console.ReadLine());

                            string path = @"mozgas.txt";
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine($"{date};{exerciseType};{exerciseLength}");
                            }

                            Console.ReadKey();
                        }
                        else if (menuOptions[selectedIndex] == "Edzés történet")
                        {
                            Console.Clear();
                            foreach (var item in exercise)
                            {
                                Console.WriteLine($"Dátum: {item.Date}, Edzés: {item.TypeOfExercise}, Idő: {item.Length}");
                            }
                            Console.ReadKey();
                        }
                        else if (menuOptions[selectedIndex] == "Szűrő")
                        {
                            Console.Clear();
                            Console.WriteLine($"Selected: {menuOptions[selectedIndex]}");
                            Console.WriteLine("3");
                            Console.ReadKey();
                        }
                        else if (menuOptions[selectedIndex] == "Statisztika")
                        {
                            Console.Clear();
                            Console.WriteLine($"Selected: {menuOptions[selectedIndex]}");
                            Console.WriteLine("4");
                            Console.ReadKey();
                        }
                    }                        
                    break;
            }
        }
    }
}

