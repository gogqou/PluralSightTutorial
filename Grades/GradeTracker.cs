using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                         DECLARATIONS AND INITIALIZATIONS                         **************//
        //    
        public event NameChangedDelegate NameChanged; //changing the delegate into an event

        public string Name;
        protected string courseName;
        protected string courseTerm;

        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                           PROPERTIES                                              **************//
        //         
        public string CourseTerm
        {
            get { return courseTerm; }
            //I didn't set a set accessor, so this property is a read-only property
            set { }
        }
        public string CourseName
        {
            get { return courseName; }
            set //since I generated a set accessor here, CourseTerm can be changed
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (courseName != value)
                {
                    var oldValue = courseName;
                    courseName = value;
                    if (NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChanged(this, args);
                    }

                }
            }
        }



        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                                  METHODS                                         **************//
        //                                                                                                  **************//
        public abstract void AddGrade(string studentName, double grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract double lookUpGrade(string studentName);
        public abstract void WriteGrades(TextWriter textWriter);
        public abstract IEnumerator GetEnumerator();

        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
    }
}
