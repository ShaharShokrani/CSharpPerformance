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
            if (true)
            {
                ForVsForeach.Run();
            }
        }
    }
}
