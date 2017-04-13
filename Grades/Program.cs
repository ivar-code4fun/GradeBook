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
            WriteBytes(int.MinValue);
            WriteBytes(int.MaxValue);
            //GradeBook book = new GradeBook();
            //book.AddGrade(91);
            //book.AddGrade(89.5f);
            //book.AddGrade(75);

            //GradeStatistics stats = book.ComputeStatistics();

            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.HighestGrade);
            //Console.WriteLine(stats.LowestGrade);
            //Console.ReadLine();
        }

        public static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            foreach (byte b in bytes)
            {
                Console.WriteLine("0:x{0:X2}", b);
            }
        }

    }
}
