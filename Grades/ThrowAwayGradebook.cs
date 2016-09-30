using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class ThrowAwayGradebook : Gradebook
    {
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                                CONSTRUCTORS                                       **************//
        //    
        public ThrowAwayGradebook(string cN, string cT)
            :base(cN, cT)
        {

        }
        public ThrowAwayGradebook(Dictionary<string,double> gradeDict)
            :base(gradeDict)
        {

        }
        public ThrowAwayGradebook(string cN, string cT, Dictionary<string,double> gradeDict)
            :base(cN, cT, gradeDict)

        {

        }
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //                                                  METHODS                                         **************//
        //   
        public override GradeStatistics ComputeStatistics()
        {
            double lowest = double.MaxValue;
            foreach(double grade in gradesOnly)
            {
                lowest = Math.Min(lowest, grade);
            }
            gradesOnly.Remove(lowest);
            Console.WriteLine("Removed lowest grade, {0}", lowest);
            return base.ComputeStatistics();
        }
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
    }

}
