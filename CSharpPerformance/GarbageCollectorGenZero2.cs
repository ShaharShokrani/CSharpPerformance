using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class GarbageCollectorGenZero2
    {
        // constants
        private const int numElements = 100000;

        /// <summary>
        /// The Array list uses boxing - which creates many objects on the heap.
        /// </summary>
        /// <returns></returns>
        public static double MeasureA()
        {
            ArrayList list = new ArrayList();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static double MeasureB()
        {
            List<int> list = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static void Run()
        {
            // measurement run
            double genericDuration = MeasureA();
            double arrayListDuration = MeasureB();

            Console.WriteLine("ArrayList: {0}", genericDuration);
            Console.WriteLine("List<int>: {0}", arrayListDuration);

            //Display the results
            Console.WriteLine();
            Console.WriteLine("List<int>: performance is {0} times faster than ArrayList.", genericDuration / arrayListDuration);

            /*
                ArrayList: 1.5334
                List<int>: 0.6065

                List<int>: performance is 2.5282769991756 times faster than ArrayList.
             */
        }
    }
}
