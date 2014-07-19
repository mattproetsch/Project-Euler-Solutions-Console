using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using TypeExtensions;
using System.Reflection;

namespace EulerSolutionsConsole
{
    abstract class Solution
    {

        public abstract int GetValue();


        private static Type[] _solutions;
        public static Type[] Solutions
        {
            get
            {
                if (_solutions == null)
                {
                    RegisterSolutions();
                }
                return _solutions;
            }
            private set
            {
                _solutions = value;
            }
        }

        static void RegisterSolutions()
        {
            List<Type> classes = null;
            List<Type> solutions = null;

            try
            {
                classes = Assembly.GetExecutingAssembly().GetTypes().Where((t) => t.IsClass).ToList<Type>();
            } catch (Exception e) {
                Debug.WriteLine("Error getting class types of executing assembly:\n" + e);
            }

            try
            {
                solutions = classes.Where((t) => ((t.BaseType != null) && t.BaseType.Name.Contains("Solution"))).ToList<Type>();
            } catch (Exception e) {
                Debug.WriteLine("Error getting classes extending Solution:\n" + e);
            }

            if (solutions != null && solutions.Count > 0)
            {
                // sort Types based on static properties
                solutions.Sort(delegate(Type t1, Type t2) {
                    return NumberOf(t1) - NumberOf(t2);
                });
                _solutions = solutions.ToArray();
            }
            
        }

        public static int NumberOf(Type t)
        {
            return Convert.ToInt32(t.Name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0]);
        }

        public static string NameOf(Type t)
        {
            string[] NameCamelCase = t.Name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            // tokenize based on case
            List<string> name = new List<string>();
            // Start at i=1 to prevent iterating thru the solution number
            for (int i = 1; i < NameCamelCase.Length; i++)
            {
                char currentChar;
                char prevChar = '\0';

                int prevSplitPt = -1;

                string currentStr = NameCamelCase[i];
                char[] currentStrCharArray = currentStr.ToCharArray();

                for (int j = 0; j < currentStrCharArray.Length; j++)
                {
                    currentChar = currentStrCharArray[j];

                    if (j == 0 && j == currentStrCharArray.Length - 1)
                    {
                        // This character is the only one in this string
                        name.Add(currentChar.ToString());
                    }

                    else if (j > 0 && Mismatch(prevChar, currentChar))
                    {
                        // This character marks the beginning of a new token
                        name.Add(currentStr.Substring(prevSplitPt + 1, j - (prevSplitPt + 1)));
                        prevSplitPt = j - 1;
                    }

                    prevChar = currentChar;
                }

                name.Add(currentStr.Substring(prevSplitPt + 1, currentStr.Length - (prevSplitPt + 1)));
            }

            return name.Aggregate((left, right) => LowercaseWords.Contains(right) ? left + " " + right.ToLower() : left + " " + right);
        }


        static char CharacterValue(int val, int idx)
        {
            return Convert.ToChar(val);
        }

        static char[] CapitalLetters = Enumerable.Range(65, 26).Select(CharacterValue).ToArray();
        static char[] LowercaseLetters = Enumerable.Range(97, 26).Select(CharacterValue).ToArray();
        static char[] Numbers = Enumerable.Range(48, 10).Select(CharacterValue).ToArray();
        static string[] LowercaseWords = new string[] { "In", "A", "And", "The", "For", "Of" };

        static bool Mismatch(char prev, char cur)
        {
            bool prevIsCapital = CapitalLetters.Contains<char>(prev);
            bool prevIsLower = LowercaseLetters.Contains<char>(prev);
            bool prevIsNumber = Numbers.Contains<char>(prev);

            bool curIsCapital = CapitalLetters.Contains<char>(cur);
            bool curIsLower = LowercaseLetters.Contains<char>(cur);
            bool curIsNumber = Numbers.Contains<char>(cur);

            // regular case: "...ultiplesOf..."
            // Beginning of a new word
            if (curIsCapital && (prevIsLower || prevIsNumber))
                return true;
            // "Of3..."
            // Beginning of a new number
            else if (curIsNumber && !prevIsNumber)
                return true;
            else if (curIsCapital && prevIsCapital)
                return true;

            return false;

        }


        
    }
}
