using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _1_MultiplesOf3And5 : Solution
    {

        public static string Description
        {
            get
            {
                return @"If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
Find the sum of all the multiples of 3 or 5 below 1000.";
            }
        }

        public override int GetValue()
        {
            return Enumerable.Range(1, 999).Where((i) => i % 3 == 0 || i % 5 == 0).Sum();
        }
    }
}
