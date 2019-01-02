using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class ForVsForeach
    {
        // constants
        private const int numElements = 10000000;

        // fields
        private static ArrayList arrayList = new ArrayList(numElements);
        private static List<int> genericList = new List<int>(numElements);
        private static int[] array = new int[numElements];


        public static void PrepareList()
        {
            Random random = new Random();
            for (int i = 0; i < numElements; i++)
            {
                int number = random.Next(256);
                arrayList.Add(number);
                genericList.Add(number);
                array[i] = number;
            }

        }

        public static long MeasureA1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                int result = (int)arrayList[i];
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureA2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int i in arrayList)
            {
                int result = i;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureB1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                int result = genericList[i];
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureB2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int i in genericList)
            {
                int result = i;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureC1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                int result = array[i];
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureC2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int i in array)
            {
                int result = i;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static void Run()
        {
            // prepare lists
            PrepareList();

            // measurement run
            long durationA1 = MeasureA1();
            long durationA2 = MeasureA2();
            long durationB1 = MeasureB1();
            long durationB2 = MeasureB2();
            long durationC1 = MeasureC1();
            long durationC2 = MeasureC2();

            Console.WriteLine("ArrayList for: {0}", durationA1);
            Console.WriteLine("ArrayList foreach: {0}", durationA2);
            Console.WriteLine("List<int> for: {0}", durationB1);
            Console.WriteLine("List<int> foreach: {0}", durationB2);
            Console.WriteLine("int[] for: {0}", durationC1);
            Console.WriteLine("int[] foreach: {0}", durationC2);

            /*
                ArrayList for: 49
                ArrayList foreach: 109
                List<int> for: 20
                List<int> foreach: 51
                int[] for: 3
                int[] foreach: 4
             */
        }
    }
}
