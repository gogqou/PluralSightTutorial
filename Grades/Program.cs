using System;
using System.IO;
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
            Dictionary<string, double> lines = new Dictionary<string, double>();

            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  
            string filename = "Grades.txt";
            try
            {
                lines = readFile(filename);
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not locate file {0},", filename);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No access to file {0}, filename");
                return;
            }
            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  
            //Gradebook book = new Gradebook("Algebra", "Spring, 2016", lines);
            //playing around with inheritance, polymorphisms
            //the following would make ComputeStatistics execute the method in Gradebook, not ThrowAwayGradebook
            //unless I make the method virtual and then override it in the inherited class
            //Gradebook book = new ThrowAwayGradebook("Algebra", "Spring, 2016", lines);
            //defining the type as "ThrowAwayGradebook" leads it to execute the method in that subclass if it wasn't a virtual method
            //ThrowAwayGradebook book = new ThrowAwayGradebook("Algebra", "Spring, 2016", lines);


            IGradeTracker book = CreateGradeBook(lines);
            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  
            //book.AddGrade("Tommy", 91);
            //book.AddGrade("John", 81.5);
            //book.AddGrade("Jane", 41.9);
            //book.AddGrade("Mike", 23);
            //book.AddGrade("Tammy", 88);
            //double tempGrade = book.lookUpGrade("Tommy");

            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  
            GradeStatistics stats = book.ComputeStatistics();


            //Playing with Methods
            WriteBytes(stats.GradeMean);

            //Learning about params, and variable parameter numbers in methods
            WriteNames("Scott", "Jake", "Betty");
            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  

            //this isn't legal if my delegate is an event:

            //***book.NameChanged = new NameChangedDelegate(OneNameChanged);

            //can also use book.NameChanged += OneNameChanged;
            //this means that we can create several methods in the delegate
            //that way, you don't overwrite with "new NameChangedDelegate", but rather add to it
            //so you can have different "components" watching this status; "subscribers"


            //this is when Events are helpful:

            //*************************************************
            book.NameChanged += OneNameChanged; //subscribing
            book.NameChanged += OneNameChanged; //subscribe twice
            book.NameChanged -= OneNameChanged; //unsubscribing

            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  

            //changing the courseName to test the delegate
            Console.WriteLine("Insert course name.");
            string input = Console.ReadLine();
            //loop til the user input is something valid (not null or empty)
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("That was an invalid course name. Please enter a string.");
                input = Console.ReadLine();
            }
            //assign the user input to the coursename
            //also includes checking for a change in the name and having an event that reports this
            //subscriptions, events, and delegates
            book.CourseName = input;

            //Learning about making something IEnumerable so you can iterate over an object
            foreach(double grade in book)
            {
                Console.WriteLine(grade);
            }

            //book.WriteGrades(Console.Out);
            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  
            //just checking the ability to read different properties and fields
            Console.WriteLine(book.CourseName + ", " + book.CourseTerm);
            //Console.WriteLine("Tommy's grade was " + tempGrade);
            Console.WriteLine("Average grade was " + stats.GradeMean);
            Console.WriteLine("Average grade was {0}", stats.LetterGrade);
            Console.WriteLine("The students are {0}", stats.Description);
            //checking stats 
            Console.WriteLine("High score was {0} and low score was {1}.", stats.HighGrade, stats.LowGrade);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            //                                                                                                  **************//
            //*****************************************************************************************************************//
            //*****************************************************************************************************************//
            //  
        }

        private static IGradeTracker CreateGradeBook(Dictionary<string,double> gradeDict)
        {
            IGradeTracker book = new ThrowAwayGradebook("Algebra", "Spring, 2016", gradeDict);
            return book; 

        }

        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //  
        private static Dictionary<string, double> readFile(string fileDirectory)
        {
            using (var reader = new StreamReader(File.OpenRead(@fileDirectory))) 
                //using "using" means that any streams or readers that need 
                //closing will do so at the end of the block
            {
                Dictionary<string, double> pairs = new Dictionary<string, double>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    pairs[values[0]] = Convert.ToDouble(values[1]);
                }
                return pairs;
            }
            
            
        }
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //  

        private static void OneNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        }

        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //  
        private static void WriteBytes(double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            foreach(byte b in bytes)
            {
                Console.WriteLine("0x{0:X}", b);
            }
        }
        //                                                                                                  **************//
        //*****************************************************************************************************************//
        //*****************************************************************************************************************//
        //  
    }
}
