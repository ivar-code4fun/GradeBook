using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            //book.NameChanged += OnNameChanged;
            book.Name = null;

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.WriteGrades(Console.Out);

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Letter Grade", stats.LetterGrade);
            WriteResult("Description", stats.Description);
            Console.ReadLine();
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
