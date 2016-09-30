using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class Gradebook : GradeTracker
    {
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                         DECLARATIONS AND INITIALIZATIONS                         **************//
        //                                                                                                  **************//
        
        public static float MinGrade = 0;
        public static float MaxGrade = 100;
        //instantiates the dictionary grades and defines is as having keys in string type and values as floats
        protected Dictionary<string, double> grades;
        protected List<double> gradesOnly;
        //public NameChangedDelegate NameChanged; // delegate that communicates if the Gradebook name has changed
        
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                                CONSTRUCTORS                                       **************//
        //                                                                                                  **************//
        //no arguments constructor:
        public Gradebook()
            : this("unknown", "unknown") //a way to call the other constructor with essentially default values
            //just an example left here to show that this is possible

        {    

        }

        //arguments for course name and course term, constructor:
        public Gradebook(string cN, string cT)
        {
            courseName = cN;
            courseTerm = cT;
            grades = new Dictionary<string, double>();
            gradesOnly = new List<double>();
        }
        public Gradebook(Dictionary<string,double> gradeDict)
            :this("unknown", "unknown", gradeDict)
        {

        }
        public Gradebook(string cN, string cT, Dictionary<string, double> gradeDict)
        {
            courseName = cN;
            courseTerm = cT;
            grades = gradeDict;
            gradesOnly = new List<double>();
            foreach (string key in gradeDict.Keys)
            {
                gradesOnly.Add(gradeDict[key]);
            }
        }
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                           PROPERTIES                                              **************//
        //                                                                                                  **************//
        //public string CourseTerm
        //{
        //    get { return courseTerm; }
        //    //I didn't set a set accessor, so this property is a read-only property
        //}
        //public string CourseName
        //{
        //    get { return courseName; }
        //    set //since I generated a set accessor here, CourseTerm can be changed
        //    {
        //        if (String.IsNullOrEmpty(value))
        //        {
        //            throw new ArgumentException("Name cannot be null or empty");
        //        }
        //        if (courseName != value)
        //        {
        //            var oldValue = courseName;
        //            courseName = value;
        //            if (NameChanged !=null)
        //            {
        //                NameChangedEventArgs args = new NameChangedEventArgs();
        //                args.OldValue = oldValue;
        //                args.NewValue = value;
        //                NameChanged(this, args);
        //            }
                    
        //        }
        //    }
        //}
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                                  METHODS                                         **************//
        //                                                                                                  **************//
        //method for adding grades, which populates the dictionary "grades" with the student's name and grade, as a float
        public override void AddGrade(string studentName, double grade)
        {
            grades.Add(studentName, grade);
            gradesOnly.Add(grade);
        }
        //method for looking up grades by checking the student name as a key in the dictionary "grades"
        public override double lookUpGrade(string studentName)
        {
            double indivGrade = grades[studentName];
            return indivGrade;
        }

        //calculates stats related to the gradebook
        //uses the class GradeStatistics to encapsulate these values

        //public GradeStatistics ComputeStatistics()    //original version; changed when learning about polymorphisms, which is
        //why we needed to make it a virtual method
        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            stats.GradeMean = gradesOnly.Average();
            stats.LowGrade = gradesOnly.Min();
            stats.HighGrade = gradesOnly.Max();
            return stats;
        }
        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Here comes the individual grades");
            foreach (string key in grades.Keys)
            {
                textWriter.WriteLine(key + ", " + grades[key]);
            }
        }
        public override IEnumerator GetEnumerator()
        {
            return gradesOnly.GetEnumerator();
        }
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
    }
}
