using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using TypeExtensions;

namespace EulerSolutionsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Type[] solutionTypes = Solution.Solutions;

            if (args.Length < 1)
            {
                Console.WriteLine();
                foreach (Type solType in solutionTypes)
                {
                    Console.WriteLine("Solution " + Solution.NumberOf(solType));
                    Console.WriteLine("\tName: " + Solution.NameOf(solType));
                    Console.WriteLine("\tDesc: " + solType.GetStaticPropertyValue<string>("Description"));
                    Console.WriteLine(Enumerable.Repeat<char>('=', 80).ToArray());
                }
            }

            else if (args.Length == 1)
            {
                try 
                {
                    Convert.ToInt32(args[0]);
                } catch (Exception) {
                    Console.WriteLine("Parameter must be a valid integer");
                    return;
                }

                // Get the number value of the solution
                int solutionNumber = Convert.ToInt32(args[0]);
                // Get the instantiated Solution
                Solution s = null;

                try
                {
                    Console.WriteLine("Instantiating solution #" + solutionNumber);
                    s = Activator.CreateInstance(solutionTypes.Where((solType) => Solution.NumberOf(solType) == solutionNumber).ToArray<Type>()[0]) as Solution;
                } catch (Exception e) {
                    Console.WriteLine("Could not instantiate solution #" + solutionNumber + ":\n" + e);
                    return;
                }

                if (s == null) {
                    Console.WriteLine("Could not instantiate solution #" + solutionNumber);
                }

                Console.WriteLine(s.GetValue());
            }

            Console.ReadLine();
        }


    }
}
