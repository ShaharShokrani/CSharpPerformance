using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    public class FastStringConcatination
    {
        // constants
        private const int numRepetitions = 100000;

        public static double MeasureA()
        {
            string s = string.Empty;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numRepetitions; i++)
            {
                s = s + "a";
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static double MeasureB()
        {
            StringBuilder sb = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numRepetitions; i++)
            {
                sb.Append("a");
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
            double stringDuration = MeasureA();
            double stringBuilderDuration = MeasureB();

            // display results
            Console.WriteLine("String performance: {0} milliseconds", stringDuration);
            Console.WriteLine ("StringBuilder performance: {0} milliseconds", stringBuilderDuration);
            Console.WriteLine();
            Console.WriteLine("StringBuilder performance is {0} times faster.", stringDuration / stringBuilderDuration);

            /*
                String performance: 884.9953 milliseconds
                StringBuilder performance: 0.3675 milliseconds

                StringBuilder performance is 2408.15047619048 times faster.
            */
        }
    }
}
