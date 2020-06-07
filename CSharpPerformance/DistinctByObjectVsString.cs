using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    public class HGW_DomesticPassengers
    {
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
        public override int GetHashCode()
        {
            return Adults.GetHashCode() + 7 * this.Children.GetHashCode() + 13 * this.Infants.GetHashCode();
        }
    }

    public static class Extensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
                Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return _(); IEnumerable<TSource> _()
            {
                var knownKeys = new HashSet<TKey>(comparer);
                foreach (var element in source)
                {
                    if (knownKeys.Add(keySelector(element)))
                        yield return element;
                }
            }
        }
    }

    class DistinctByObjectVsString
    {
        // constants
        private const int numElements = 10000;

        // fields        
        private static List<HGW_DomesticPassengers> _list;

        public static void PrepareList()
        {
            var list = Enumerable.Range(0, numElements)
                    .Select(r => new HGW_DomesticPassengers()
                    {
                        Adults = 2,
                        Children = 0,
                        Infants = 0
                    });

            _list = list.ToList();
        }

        public static long MeasureA1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var distinct = _list.DistinctBy(p => new { p.Adults, p.Children, p.Infants }).ToList();

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureA2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var distinct = _list.DistinctBy(p => $"{p.Adults}{p.Children}{p.Infants}").ToList();

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long MeasureA3()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var distinct = _list.Distinct().ToList();

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static void Run()
        {
            // prepare lists
            PrepareList();

            MeasureA1();
            MeasureA2();
            MeasureA3();

            // measurement run
            double durationA1 = MeasureA1();
            double durationA2 = MeasureA2();
            double durationA3 = MeasureA3();

            Console.WriteLine("new: {0}", durationA1);
            Console.WriteLine("string: {0}", durationA2);
            Console.WriteLine("distinct(): {0}", durationA3);
            Console.WriteLine("new: performance is {0} times faster than string.", durationA2 / durationA1);

        }
    }
}
