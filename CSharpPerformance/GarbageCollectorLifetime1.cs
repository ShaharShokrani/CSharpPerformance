using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class GarbageCollectorLifetime1
    {
        // constants
        private const int numElements = 500000;

        /// <summary>
        /// Big object with a short live.
        /// </summary>
        /// <returns></returns>
        public static double MeasureA()
        {
            ArrayList bigList = new ArrayList(85190);

            ArrayList list = new ArrayList();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }
            
            bigList = new ArrayList(85190);

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Big object with a long live.
        /// </summary>
        /// <returns></returns>
        public static double MeasureB()
        {
            ArrayList bigList = new ArrayList(85190);

            ArrayList list = new ArrayList();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }

            bigList.Clear();

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }



        public static void Run()
        {
            MeasureA();
            MeasureB();

            // measurement run
            double bigShortLiveDuration = MeasureA();
            double bigLongLiveDuration = MeasureB();

            Console.WriteLine("Big with short-live: {0}", bigShortLiveDuration);
            Console.WriteLine("Big with long-live: {0}", bigLongLiveDuration);

            //Display the results
            Console.WriteLine();
            Console.WriteLine("Big with long-live performance is {0} times faster than Big with short-live.", bigShortLiveDuration / bigLongLiveDuration);

            /*
                Big with short-live: 36.1289
                Big with long-live: 33.904

                Big with long-live performance is 1.06562352524776 times faster than Big with short-live.
             */
        }
    }
}
