using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class GarbageCollectorLifetime2
    {
        // constants
        private const int numElements = 10000;
        
        class Pair
        {
            private int i;
            private int v;

            public Pair(int i, int v)
            {
                this.i = i;
                this.v = v;
            }
        }

        /// <summary>
        /// Big object with a numElements short live objects.
        /// </summary>
        /// <returns></returns>
        public static double MeasureA()
        {
            ArrayList bigList = new ArrayList(85190);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                bigList.Add(new Pair(i, i+1));
            }
            
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// 2 Big long live objects.
        /// </summary>
        /// <returns></returns>
        public static double MeasureB()
        {
            int[] bigList1 = new int[85190];
            int[] bigList2 = new int[85190];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                bigList1[i] = i;
                bigList2[i] = i + 1;
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }



        public static void Run()
        {
            MeasureA();
            MeasureB();

            // measurement run
            double bigShortLiveWithManySmallShortLivedDuration = MeasureA();
            double twoBigLongLiveDuration = MeasureB();

            Console.WriteLine("Big with many short-live objects: {0}", bigShortLiveWithManySmallShortLivedDuration);
            Console.WriteLine("Two Big long-live objects: {0}", twoBigLongLiveDuration);

            //Display the results
            Console.WriteLine();
            Console.WriteLine("Two Big long-live performance is {0} times faster than Big with many short-live objects.", bigShortLiveWithManySmallShortLivedDuration / twoBigLongLiveDuration);

            /*
                Big with many short-live objects: 0.14
                Two Big long-live objects: 0.03

                Two Big long-live performance is 4.47 times faster than Big with many short-live objects.
             */
        }
    }
}
