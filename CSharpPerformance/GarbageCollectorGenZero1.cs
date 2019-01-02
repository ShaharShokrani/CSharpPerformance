using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class GarbageCollectorGenZero1
    {
        // constants
        private const int numRepetitions = 100000;

        public static double MeasureA()
        {
            StringBuilder sb = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numRepetitions; i++)
            {
                sb.Append(i);
                sb.Append("KB");
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// The string concationation creates extra objects on the heap (the strings are immutable).
        /// </summary>
        /// <returns></returns>
        public static double MeasureB()
        {
            StringBuilder sb = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numRepetitions; i++)
            {
                sb.Append(i + "KB");
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }        

        public static void Run()
        {
            // 1st run to eliminate any startup overhead
            MeasureA();
            MeasureB();

            // measurement run
            double appendDuration = MeasureA();
            double stringConcatDuration = MeasureB();

            // display results
            Console.WriteLine("StringBuilder append performance: {0} milliseconds", appendDuration);
            Console.WriteLine("StringConcatination performance: {0} milliseconds", stringConcatDuration);
            Console.WriteLine();
            Console.WriteLine("StringBuilder append performance is {0} times faster.", stringConcatDuration / appendDuration);

            /*
                StringBuilder append performance: 11.90 milliseconds
                StringConcatination performance: 13.11 milliseconds

                StringBuilder append performance is 1.10 times faster.
            */
        }
    }
}
