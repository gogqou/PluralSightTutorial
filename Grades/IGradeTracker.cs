using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public interface IGradeTracker :IEnumerable
    {
        string CourseName { get; set; }
        string CourseTerm { get; set; }
        event NameChangedDelegate NameChanged;



        GradeStatistics ComputeStatistics();
        double lookUpGrade(string studentName);
        void WriteGrades(TextWriter textWriter);
        void AddGrade(string studentName, double grade);
    }
}
