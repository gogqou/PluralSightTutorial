using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        
        public double GradeMean;
        public double LowGrade;
        public double HighGrade;
        public string LetterGrade
        {
            get
            {
                string result;
                if (GradeMean >= 90)
                {
                    result = "A";
                }
                else if (GradeMean >=80)
                {
                    result = "B";
                }
                else if (GradeMean >= 70)
                {
                    result = "C";
                }
                else if (GradeMean >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }
        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent!";
                        break;
                    case "B":
                        result = "Doing well!";
                        break;
                    case "C":
                        result = "Average..";
                        break;
                    default:
                        result = "Doing poorly";
                        break;
                }
                    
                return result;
            }
        }
    }
}
