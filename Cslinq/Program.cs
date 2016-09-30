using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;
using System.Data;

namespace Cslinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //MovieDB db = new MovieDB();
            //IEnumerable<Movie> query = db.Movies.Where(m => m.Title.StartsWith("Star"))
            //    .OrderBy(m => m.ReleaseDate.Year);
            //foreach(var movie in query)
            //{
            //    Console.WriteLine(movie.Title);
            //}
            WorkWithFuncs();
            Console.ReadKey();
        }
        private static void QueryCities()
        {
            IEnumerable<string> cities = new[] { "Ghent", "London", "Las Vegas", "Hyderabad" };
            

            //IEnumerable<string> query = cities.Filter((item)=> item.StartsWith("L")); //lambda expression
            IEnumerable<string> query = cities.Where(city => city.StartsWith("L"))
                                        .OrderByDescending(city=>city.Length);
            foreach (string city in query)
            {
                Console.WriteLine(city);
            }
            Console.ReadKey();

            
        }
        private static void WorkWithFuncs()
        {
            //type for LINQ/delegates/lambda expressions
            Func<int, int> square = x => x * x;
            Action<int> write = x => Console.WriteLine(x);
            write(square(3));
        }
    }
}
namespace Extensions
{
    public static class FilterExtensions
    {
        public static IEnumerable<T> Filter<T>
            //below is no longer necessary if using Func<>
            //(this IEnumerable<T> input, FilterDelegate<T> predicate) //any IEnumerable type works; predicate is basically a function
            //that checks whether something about T item is true and returns bool (true/false)
            //this makes this filter setup more generic
            //you're predicating on a condition about T

            (this IEnumerable<T> input, Func<T, bool> predicate)
        {
            foreach (var item in input)
                if (predicate(item))
                {
                    yield return item;
                }
                
        }
    }
    //not necessary when using Func for the delegate rather than defining the delegate
    //public delegate bool FilterDelegate<T>(T item);

}
    