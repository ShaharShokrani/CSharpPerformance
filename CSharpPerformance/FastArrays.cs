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

        public static long MeasureA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] list = new int[numElements * numElements];
            for (int i = 0; i < numElements * numElements; i++)
            {
                list[i] = i;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureB()
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
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureC()
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
            return stopwatch.ElapsedMilliseconds;
        }

        public static void Run()
        {
            // measurement run
            long duration1 = MeasureA();
            long duration2 = MeasureB();
            long duration3 = MeasureC();

            Console.WriteLine("int[]: {0}", duration1);
            Console.WriteLine("int[,]: {0}", duration2);
            Console.WriteLine("int[][]: {0}", duration3);
        }

    }
}
