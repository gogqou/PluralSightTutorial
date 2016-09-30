using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractice
{
    class Program
    {
        public static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] assemblyTypes = assembly.GetTypes();
            foreach (Type type in assemblyTypes)
            {
                if (type.Namespace.Contains("University"))
                {
                    Console.WriteLine(type.Name);
                }
            
            }
            Console.ReadKey();
        }
        //public static int Main()
        //{
        //    Console.WriteLine("\nReflection.MethodInfo");
        //    TestObj test1 = new TestObj();
        //    Type test1Type = test1.GetType();
        //    MethodInfo AddNumMethodInfo = test1Type.GetMethod("AddNum");
        //    object[] parameters = new object[] {5,10};
        //    Console.Write("\nFirst method - " + test1Type.FullName + " returns " +
        //                 AddNumMethodInfo.Invoke(test1, parameters) + "\n");
        //    Console.Write("This method is {0}, which is Abstract ({1}) or Regular Class ( {2}).", test1Type, test1Type.IsAbstract, test1Type.IsClass);

        //    Type testObj2Type = typeof(TestObj2);
        //    object test2 = Activator.CreateInstance(testObj2Type);
        //    object[] parameters2 = new object[] { 5, 10 };
        //    int res = (int)testObj2Type.InvokeMember("AddNum", BindingFlags.InvokeMethod, null, test2, parameters2);
        //    Console.Write("\n Result: {0} \n", res);
        //    Console.ReadKey();
        //    return 0;
        //}
    }

    public class TestObj
    {
        public virtual int AddNum(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }
    }
    public class TestObj2
    {
        int answer;
        public TestObj2()
        {
            answer = 0;

        }
        public int AddNum(int num1, int num2)
        {
            answer = num1 + num2;
            return answer;
        }
    }
}
namespace University
{

    public class Student
    {
        public string FullName { get; set; }

        public int Class { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string GetCharacteristics()
        {
            return "";
        }
    }

    namespace Department
    {

        public class Professor
        {

            public string FullName { get; set; }

        }
    }
}
