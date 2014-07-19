using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _6_SumSquareDifference : Solution
    {

        public static string Description
        {
            get
            {
                return @"The sum of the squares of the first ten natural numbers is,
1^2 + 2^2 + ... + 10^2 = 385

The square of the sum of the first ten natural numbers is,
(1 + 2 + ... + 10)^2 = 55^2 = 3025

Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";
            }
        }

        public override int GetValue()
        {
            int sumOfSquares = 0; // smaller value
            int squareOfSums = 0; // larger value

            for (int i = 1; i <= 100; i++)
            {
                sumOfSquares += i*i;
            }

            // add half to the float value and cast to an int to round to the nearest integer value
            squareOfSums = (int) (Math.Pow((100 * 101) / 2, 2) + 0.5d); // sum from one to n of n equals n times n plus one over two


            return squareOfSums - sumOfSquares;
        }
    }
}
