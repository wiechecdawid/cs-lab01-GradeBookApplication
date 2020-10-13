using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var sortedStudents = Students.OrderByDescending(x => x.AverageGrade).ToArray();

            if (averageGrade >= sortedStudents[(Students.Count * 2 / 10) - 1].AverageGrade)
                return 'A';
            if (averageGrade >= sortedStudents[(Students.Count * 4 / 10) - 1].AverageGrade)
                return 'B';
            if (averageGrade >= sortedStudents[(Students.Count * 6 / 10) - 1].AverageGrade)
                return 'C';
            if (averageGrade >= sortedStudents[(Students.Count * 8 / 10) - 1].AverageGrade)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
