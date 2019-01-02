using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class GarbageCollectorGenZero3
    {
        public class MyClass
        {
            public MyClass(DateTime updateDate, string name, int age)
            {
                UpdateDate = updateDate;
                Name = name;
                Age = age;
            }

            public DateTime UpdateDate { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return string.Format("UpdateDate: {0}, Name: {1}, Age: {2}", new string[] {
                    UpdateDate.ToString(), Name, Age.ToString()
                });
            }
        }

        // constants
        private const int numElements = 500000;

        /// <summary>
        /// The initiation for the myClass object is very far away than the real usage of it.
        /// </summary>
        /// <returns></returns>
        public static double MeasureA()
        {
            MyClass myClass = new MyClass( DateTime.MinValue, "MyName", 32);

            ArrayList list = new ArrayList();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }
            stopwatch.Stop();

            Console.WriteLine(myClass.ToString());
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// The initiation for the myClass object is near to the real usage of it.
        /// </summary>
        /// <returns></returns>
        public static double MeasureB()
        {
            ArrayList list = new ArrayList();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }
            stopwatch.Stop();

            
            MyClass myClass = new MyClass(DateTime.MinValue, "MyName", 32);
            Console.WriteLine(myClass.ToString());
            return stopwatch.Elapsed.TotalMilliseconds;
        }



        public static void Run()
        {
            MeasureA();
            MeasureB();

            // measurement run
            double farDuration = MeasureA();
            double nearDuration = MeasureB();

            Console.WriteLine("Far: {0}", farDuration);
            Console.WriteLine("Near: {0}", nearDuration);

            //Display the results
            Console.WriteLine();
            Console.WriteLine("Near performance is {0} times faster than Far.", farDuration / nearDuration);

            /*
                Far: 35.4241
                Near: 31.4612

                Near performance is 1.12596150178633 times faster than Far.
             */
        }
    }
}
