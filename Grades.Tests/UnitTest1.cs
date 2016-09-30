using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;
namespace Grades.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculatesHighestGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade("Tom", 50);
            book.AddGrade("Andy", 90);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(90, stats.HighGrade);
        }
    }
}
