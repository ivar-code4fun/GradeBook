using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();
            //book.NameChanged += OnNameChanged;

            //GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Letter Grade", stats.LetterGrade);
            WriteResult("Description", stats.Description);
            Console.ReadLine();
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                //outputFile.Dispose();
            }
            //book.WriteGrades(Console.Out);
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name for the gradebook:");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"Gradebook changing name from {existingName} to {newName}");
        //}

        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Gradebook changing name from {args.ExistingName} to {args.NewName}");
        //}

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description} : {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description} : {result:F2}");
        }

    }
}
