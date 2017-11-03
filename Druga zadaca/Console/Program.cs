using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prvi_zadatak;
using Drugi_zadatak;
using Cetvrti_zadatak;

namespace Console
{
    class Program
    {

        static void Main(string[] args)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //LongOperation("A");
            //LongOperation("B");
            //LongOperation("C");
            //LongOperation("D");
            //LongOperation("E");
            //stopwatch.Stop();
            //System.Console.WriteLine(" Synchronous long operation calls finished {0} sec.",
            //    stopwatch.Elapsed.TotalSeconds);

            //Stopwatch stopwatch1 = new Stopwatch();
            //stopwatch.Start();
            //Parallel.Invoke(() => LongOperation("A"),
            //    () => LongOperation("B"),
            //    () => LongOperation("C"),
            //    () => LongOperation("D"),
            //    () => LongOperation("E"));
            //stopwatch.Stop();
            //System.Console.WriteLine(" Parallel long operation calls finished {0} sec.",
            //    stopwatch.Elapsed.TotalSeconds);

            //int counter = 0;
            //Parallel.For(0, 100000, (i) =>
            //{
            //    Thread.Sleep(1);
            //    counter += 1;
            //});
            //System.Console.WriteLine(" Counter should be 100000. Counter is {0}", counter);

            //int counter = 0;
            //object objectUsedForLock = new object();
            //Parallel.For(0, 100000, (i) =>
            //{
            //    Thread.Sleep(1);
            //    lock (objectUsedForLock)
            //    {
            //        counter += 1;
            //    }
            //}) ;
            //System.Console.WriteLine(" Counter should be 100000. Counter is {0}", counter);

            //List<int> results = new List<int>();
            //Parallel.For(0, 100000, (i) =>
            //{
            //    Thread.Sleep(1);
            //    results.Add(i * i);
            //}) ;
            //System.Console.WriteLine("Bag length should be 100000. Length is {0}",
            //    results.Count);

            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                iterations.Add(i);
            }) ;
            System.Console.WriteLine("Bag length should be 100000. Length is {0}",
                iterations.Count);
        }

        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            System.Console.WriteLine($"{taskName} Finished . Executing Thread : {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Case1()
        {
            var topStudents = new List<Student>()
            {
            new Student (" Ivan ", jmbag :" 001234567 ") ,
            new Student (" Luka ", jmbag :" 3274272 ") ,
            new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);
            System.Console.WriteLine(isIvanTopStudent);
            
        }

        static void Case2()
        {
            var list = new List<Student>()
            {
            new Student (" Ivan ", jmbag :" 001234567 ") ,
            new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();
            System.Console.WriteLine(distinctStudentsCount);
        }

        static void Case3()
        {
            var topStudents = new List<Student>()
            {
            new Student (" Ivan ", jmbag :" 001234567 ") ,
            new Student (" Luka ", jmbag :" 3274272 ") ,
            new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
            System.Console.WriteLine(isIvanTopStudent);
        }

    }
}
