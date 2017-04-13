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
            //WriteBytes(int.MinValue);
            //WriteBytes(int.MaxValue);
            GradeBook book = new GradeBook();
            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            book.NameChanged += new NameChangedDelegate(OnNameChanged2);

            book.Name = "Ravi's Grade Book";

            book.Name = "Ravi's new Grade Book";
            book.Name = null;
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", (int)stats.LowestGrade);
            Console.ReadLine();
        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Gradebook changing name from {existingName} to {newName}");
        }

        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("*******");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description} : {result:F2}");
        }
        //public static void WriteBytes(int value)
        //{
        //    byte[] bytes = BitConverter.GetBytes(value);

        //    foreach (byte b in bytes)
        //    {
        //        Console.WriteLine("0:x{0:X2}", b);
        //    }
        //}

    }
}
