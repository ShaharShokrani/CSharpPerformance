using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class Exceptions1
    {
        private const int repetitions = 1000000;

        public static double MeasureA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            for (int r = 0; r < repetitions; r++)
            {
                count = count + 1;
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static double MeasureB()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            for (int r = 0; r < repetitions; r++)
            {
                try
                {
                    count = count + 1;
                    throw new InvalidOperationException();
                }
                catch (InvalidOperationException)
                {

                }
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static void Run()
        {
            // measurement run
            double normalDuration = MeasureA();
            double exceptionDuration = MeasureB();

            Console.WriteLine("Normal: {0}", normalDuration);
            Console.WriteLine("With exceptions: {0}", exceptionDuration);
            Console.WriteLine();
            Console.WriteLine("Normal performance is {0} times faster than exception.", exceptionDuration / normalDuration);

            /*
                Normal: 0.311
                With exceptions: 12621.0407

                Normal performance is 40582.124437299 times faster than exception.
             */
        }

    }
}
