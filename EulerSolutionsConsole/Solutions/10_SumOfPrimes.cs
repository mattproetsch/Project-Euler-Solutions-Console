using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _10_SumOfPrimes : Solution
    {
        public static string Description
        {
            get
            {
                return @"The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.";
            }
        }

        // literally just copying and pasting the code from solution 7
        // sieve up to 2 000 000
        public const int maxSieve = 2000000;

        public override int GetValue()
        {

            List<int> primes = DoEratosthenes();

            // primes now contains all primes up to the 10 millionth integer
            long sum = 0;
            foreach (int prime in primes)
                sum += prime;

            Console.WriteLine(sum);
            return 0;

        }

        private List<int> DoEratosthenes()
        {
            bool[] primes = new bool[maxSieve];
            List<int> primesList = new List<int>();

            for (int i = 2; i < maxSieve; i++)
            {
                // False is prime, true is composite
                if (!primes[i])
                {
                    primesList.Add(i);

                    // Mark all multiples of this prime up to maxSieve as composite
                    int cur = i;
                    while (cur < maxSieve)
                    {
                        primes[cur] = true;
                        cur += i;
                    }
                }
            }

            return primesList;
        }
    }
}
