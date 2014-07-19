using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _7_10001stPrime : Solution
    {
        public static string Description
        {
            get
            {
                return @"By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?";
            }
        }

        // sieve up to 10 000 000 to speed up the process
        public const int maxSieve = 10000000;

        public override int GetValue()
        {
            
            List<int> primes = DoEratosthenes();

            // primes now contains all primes up to the 10 millionth integer
            return primes[10000];

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
