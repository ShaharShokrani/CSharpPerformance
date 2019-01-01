using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    public class BoxingAndUnboxing
    {
        private const int arraySize = 10000000;

        /// <summary>
        /// Base Measure for increamenting a by 1 for 1,000,000 times without unboxing.
        /// </summary>
        /// <returns>Elapsed Milliseconds</returns>
        public static long MeasureA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int a = 1;
            for (int i = 0; i < arraySize; i++)
            {
                a = a + 1;
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Base Measure for increamenting a by 1 for 1,000,000 times with unboxing.
        /// </summary>
        /// <returns>Elapsed Milliseconds</returns>
        public static long MeasureB()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            object a = 1;
            for (int i = 0; i < arraySize; i++)
            {
                a = (int)a + 1;
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static void Run()
        {
            //First run to eliminate any startups overhead.
            BoxingAndUnboxing.MeasureA();
            BoxingAndUnboxing.MeasureB();

            //Real measurment
            long intDuration = BoxingAndUnboxing.MeasureA();
            long objDuration = BoxingAndUnboxing.MeasureB();

            //Display the results
            Console.WriteLine("Integer performance: {0} elapsed milliseconds.", intDuration);
            Console.WriteLine("Object performance: {0} elapsed milliseconds.", objDuration);
            Console.WriteLine();
            Console.WriteLine("Integer performance is {0} times faster.", objDuration / intDuration);

            /*
            Integer performance: 5 elapsed milliseconds.
            Object performance: 28 elapsed milliseconds.

            Integer performance is 5 times faster.
            */
        }
    }
}
