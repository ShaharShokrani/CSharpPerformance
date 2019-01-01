using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    public class ArrayListVsGenericVsNative
    {
        private const int numElements = 1000000;

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

        public static double MeasureC()
        {
            int[] list = new int[numElements];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                list[i] = i;
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static void Run()
        {
            // measurement run
            double arrayListDuration = MeasureA();
            double genericDuration = MeasureB();
            double nativeDuration = MeasureC();

            Console.WriteLine("ArrayList: {0}", arrayListDuration);
            Console.WriteLine("List<int>: {0}", genericDuration);
            Console.WriteLine("int[]: {0}", nativeDuration);

            //Display the results
            Console.WriteLine();
            Console.WriteLine("List<int>: performance is {0} times faster than ArrayList.", arrayListDuration / genericDuration);
            Console.WriteLine("int[]: performance is {0} times faster than ArrayList.", arrayListDuration / nativeDuration);
            Console.WriteLine("int[]: performance is {0} times faster than List<int>.", genericDuration / nativeDuration);

            /*
             ArrayList: 68.3633
            List<int>: 24.265
            int[]: 4.426

            List<int>: performance is 2.82 times faster than ArrayList.
            int[]: performance is 15.45 times faster than ArrayList.
            int[]: performance is 5.48 times faster than List<int>. 
             */
        }

    }
}
