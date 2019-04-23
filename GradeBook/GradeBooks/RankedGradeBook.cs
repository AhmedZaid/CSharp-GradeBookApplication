using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new System.InvalidOperationException();
            int index = (int)System.Math.Ceiling(Students.Count * 0.2);
            var grade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grade[index - 1] <= averageGrade)
                return 'A';
            else if (grade[index * 2 - 1] <= averageGrade)
                return 'B';
            else if (grade[index * 3 - 1] <= averageGrade)
                return 'C';
            else if (grade[index * 4 - 1] <= averageGrade)
                return 'D';

            return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();

        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
