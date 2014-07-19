using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutionsConsole.Solutions
{
    class _4_LargestPalindromeProduct : Solution
    {
        public static string Description
        {
            get
            {
                return @"A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.";
            }
        }

        public override int GetValue()
        {
            int num1, num2;
            int palindrome = 0;

            for (int i = 1; i < 1000; i++)
            {
                for (int j = i; j < 1000; j++)
                {
                    if (IsPalindrome(i * j) &&  i*j > palindrome)
                    {
                        num1 = i;
                        num2 = j;
                        palindrome = i * j;
                    }
                }
            }

            return palindrome;

        }

        public bool IsPalindrome(int n)
        {
            string p = n.ToString();

            // even length
            if (p.Length % 2 == 0)
            {
                int len = p.Length;
                int halflen = len / 2;

                for (int i = 0; i < halflen; i++)
                {
                    if (p[i] != p[len - i - 1])
                        return false;
                }
                return true;
            }
            else
            {
                // single digit, handle separately
                if (p.Length == 1) return true;

                int len = p.Length - 1;
                int halflen = len / 2;
                
                for (int i = 0; i < halflen; i++)
                {
                    if (p[i] != p[len - i - 1])
                        return false;
                }
                return true;
            }
        }
    }
}
