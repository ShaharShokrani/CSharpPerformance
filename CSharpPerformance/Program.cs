using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            if (false)
            {
                BoxingAndUnboxing.Run();
            }
            if (false)
            {
                FastStringConcatination.Run();
            }
            if (false)
            {
                ArrayListVsGenericVsNative.Run();
            }
            if (false)
            {
                FastArrays.Run();
            }
            if (false)
            {
                Exceptions1.Run();
            }
            if (false)
            {
                Exceptions2.Run();
            }
            if (false)
            {
                Exceptions3.Run();
            }
            if (false)
            {
                ForVsForeach.Run();
            }
            if (false)
            {
                GarbageCollectorGenZero1.Run();
            }
            if (false)
            {
                GarbageCollectorGenZero2.Run();
            }
            if (false)
            {
                GarbageCollectorGenZero3.Run();
            }
            if (true)
            {
                GarbageCollectorLifetime1.Run();
            }
        }

        public static IDictionary<char, int> GetCharacterCount(string name)
        {
            var result = new Dictionary<char, int>();
            name = name.ToLower();

            foreach (char c in name)
            {
                if (Char.IsWhiteSpace(c))
                {
                    continue;
                }

                if (!result.ContainsKey(c))
                    result.Add(c, 1);
                else
                    result[c]++;
            }
            return result;
        }

    }
}
