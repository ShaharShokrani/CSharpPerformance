﻿using System;
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
            if (true)
            {
                ArrayListVsGenericVsNative.Run();
            }

        }
    }
}
