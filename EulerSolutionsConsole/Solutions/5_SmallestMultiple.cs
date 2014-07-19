using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _5_SmallestMultiple : Solution
    {
        public static string Description
        {
            get
            {
                return @"2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";
            }
        }

        public override int GetValue()
        {
            // Only test increments of 20; any smaller increment is wasteful
            for (int i = 20; ; i += 20)
            {
                // All numbers divisible by 11 AND 12 AND ... AND 20 are also divisible by 1 AND 2 AND ... AND 10
                // but not vice versa
                // so only test the larger divisors
                for (int j = 11; j <= 19; j++)
                {
                    if (i % j != 0) break;
                    if (j == 19) return i;
                }
            }
        }
    }
}
