using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _9_SpecialPythagoreanTriplet : Solution
    {
        public static string Description
        {
            get
            {
                return @"A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
a^2 + b^2 = c^2

For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.";
            }
        }

        public override int GetValue()
        {
            int a = 1;
            int b = 1;
            int c = 1;

            for (int a_i = 1; a_i < 500; a_i++)
                for (int b_i = a_i; b_i < 500; b_i++)
                {
                    int c_i = 1000 - b_i - a_i;
                    if (a_i*a_i + b_i*b_i == c_i*c_i)
                    {
                        a = a_i;
                        b = b_i;
                        c = c_i;
                        break;
                    }
                }

            return a * b * c;
        }
    }
}
