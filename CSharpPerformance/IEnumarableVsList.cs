using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class IEnumarableVsList
    {
        // constants
        private const int numElements = 1000000;

        // fields        

        private static List<int> _list;
        private static IEnumerable<int> _enumerable;

        public static void PrepareList()
        {
            Random _rand = new Random();
            var randomList = Enumerable.Range(0, _rand.Next(100))
                    .Select(r => _rand.Next(100));

            _enumerable = randomList;
            _list = randomList.ToList();
        }

        public static int SummarizeIEnumerable(IEnumerable<int> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                count += 1;
            }

            return count;
        }

        public static int SummarizeList(List<int> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                count += 1;
            }

            return count;
        }

        public static long MeasureA1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                SummarizeIEnumerable(_enumerable);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureA2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numElements; i++)
            {
                SummarizeList(_list);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static void Run()
        {
            // prepare lists
            PrepareList();

            MeasureA1();
            MeasureA2();

            // measurement run
            double durationA1 = MeasureA1();
            double durationA2 = MeasureA2();

            Console.WriteLine("IEnumerable: {0}", durationA1);
            Console.WriteLine("List: {0}", durationA2);
            Console.WriteLine("IEnumerable: performance is {0} times faster than List.", durationA2 / durationA1);

            /*
                IEnumerable: 2584
                List: 357
                IEnumerable: performance is 0.138157894736842 times faster than List.
             */
        }
    }
}
