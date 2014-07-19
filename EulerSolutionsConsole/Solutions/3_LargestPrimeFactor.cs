using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _3_LargestPrimeFactor : Solution
    {
        public static string Description
        {
            get
            {
                return @"The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?";
            }
        }

        public override int GetValue()
        {

            List<long> factors = GetPrimeFactors(new List<long>(), 600851475143);
            foreach (int factor in factors)
            {
                Console.WriteLine(factor);
            }

            // Cast the largest factor to an int - this is safe since 2^31-1 is the largest positive value
            // that a System.Int32 can store and is the largest prime factor that a System.Int64 can hold
            return (int)factors.Max();
            
        }

        public List<long> GetPrimeFactors(List<long> factors, long n)
        {
            if (Prime(n))
            {
                factors.Add(n);
                return factors;
            }

            for (int i = 2; i < n; i++)
            {
                if (Prime(i))
                {
                    if (n % i == 0)
                    {
                        factors.Add(i);
                        return GetPrimeFactors(factors, n / i);
                    }
                }
            }

            return null;
        }

        bool Prime(long n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;

            long max = Convert.ToInt64(Math.Ceiling(Math.Sqrt(n)));
            for (int i = 2; i <= max; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
