using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        private List<float> grades;
        public NameChangedDelegate NameChanged;

        private string _name;
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_name != value)
                    {
                        NameChanged(_name, value);
                    }
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Caution : {0} just tried to insert null or empty to name", Environment.UserName);
                }

            }
        }

        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();

        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public void AddGrade(float grade)
        {
            //add grades to book and persist it
            grades.Add(grade);
        }

    }
}
