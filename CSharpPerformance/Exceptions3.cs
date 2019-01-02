using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    public class Exceptions3
    {
        // constants
        private const int elements = 1000000;

        // fields
        private static List<int> numbers = new List<int>();
        private static Dictionary<int, string> lookup = new Dictionary<int, string> {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" }
        };

        public static void PrepareList()
        {
            Random random = new Random();
            for (int i = 0; i < elements; i++)
            {
                numbers.Add(random.Next(11));
            }
        }

        public static long MeasureA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < elements; i++)
            {
                string s = null;
                try
                {
                    s = lookup[numbers[i]];
                }
                catch (KeyNotFoundException)
                {
                }
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureB()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < elements; i++)
            {
                string s = null;
                int key = numbers[i];
                if (lookup.ContainsKey(key))
                    s = lookup[key];
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static void Run()
        {
            // initialization
            PrepareList();

            // measurement run
            long duration1 = MeasureA();
            long duration2 = MeasureB();

            Console.WriteLine("Lookup: {0}", duration1);
            Console.WriteLine("Lookup with check: {0}", duration2);

            Console.WriteLine("Lookup with check: performance is {0} than Lookup without check", duration1 / duration2);

            /*
                Lookup: 1552
                Lookup with check: 19
                Lookup with check: performance is 81 than Lookup without check
             * /
        }
    }
}
