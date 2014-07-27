using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _14_LongestCollatzSequence : Solution
    {
        public static string Description
        {
            get
            {
                return @"The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:
13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.";
            }
        }

        public override int GetValue()
        {
            Dictionary<int, int> collatz = new Dictionary<int, int>();

            int maxSeq = 0;
            int maxSeqSeed = 1;

            for (int seed = 1; seed < 1000000; seed++)
            {
                ulong collatzNum = (ulong)seed;
                int seq = 1;
                // A proof that this loop terminates is a proof of the Collatz Conjecture... so for now let's just cross our fingers
                while (collatzNum != 1)
                {
                    if (collatz.ContainsKey((int)collatzNum))
                    {
                        // While we're at it, using a dictionary to store all the previously computed Collatz sequence lengths, it would
                        // also be possible to store the lengths of all the intermediate numbers in the chain, by representing the chain
                        // as a stack, and assigning each element the length from it to the end of the chain
                        seq += collatz[(int)collatzNum] - 1;
                        break;
                    }

                    if (collatzNum % 2 == 0)
                        collatzNum = collatzNum / 2;
                    else
                        collatzNum = 3 * collatzNum + 1;

                    seq++;
                }

                collatz[seed] = seq;

                if (seq > maxSeq)
                {
                    maxSeq = seq;
                    maxSeqSeed = seed;
                }
            }

            Console.WriteLine("{0} had a sequence that is {1} numbers long", maxSeqSeed, maxSeq);
            return 0;
        }
    }
}
