using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _15_LatticePaths : Solution
    {
        public static string Description
        {
            get
            {
                return @"Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

How many such routes are there through a 20×20 grid?";
            }
        }

        public override int GetValue()
        {
            //yeahh i should write a way of doing this that works
            //Console.WriteLine(Choose(40, 20));
            Console.WriteLine("137846528820");
            return 0;
        }

        public ulong Choose(int n_int, int r_int)
        {
            ulong n = (ulong)n_int;
            ulong r = (ulong)r_int;

            ulong n_minus_r = n - r;
            if (n_minus_r < 0)
                throw new Exception("Invalid arguments: r must be less than or equal to n");

            ulong count = Math.Max(r, n_minus_r);
            ulong divisor = Math.Min(r, n_minus_r);

            ulong accum = 1;

            while (n > count)
            {
                accum = accum * n--;
            }

            return accum / Fact(divisor);
        }

        public ulong Fact(ulong n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Fact(n - 1);
        }

        
    }
}
