using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class FastArrays
    {
        // constants
        private const int numElements = 1000;

        public static double MeasureA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] list = new int[numElements * numElements];
            for (int i = 0; i < numElements * numElements; i++)
            {
                list[i] = i;
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static double MeasureB()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[,] list = new int[numElements, numElements];
            for (int i = 0; i < numElements; i++)
            {
                for (int j = 0; j < numElements; j++)
                {
                    list[i, j] = 1;
                }
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static double MeasureC()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[][] list = new int[numElements][];
            for (int i = 0; i < numElements; i++)
            {
                list[i] = new int[numElements];
            }
            for (int i = 0; i < numElements; i++)
            {
                for (int j = 0; j < numElements; j++)
                {
                    list[i][j] = 1;
                }
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static void Run()
        {
            // measurement run
            double duration1 = MeasureA();
            double duration2 = MeasureB();
            double duration3 = MeasureC();

            Console.WriteLine("int[]: {0}", duration1);
            Console.WriteLine("int[,]: {0}", duration2);
            Console.WriteLine("int[][]: {0}", duration3);

            /*
                int[]: 7.01
                int[,]: 8.15
                int[][]: 7.84
             */
        }

    }
}
