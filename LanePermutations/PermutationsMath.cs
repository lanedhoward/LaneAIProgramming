using LaneLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanePermutations
{
    public static class PermutationsMath
    {
        /// <summary>
        /// Recursive Factorial Function
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Factorial(int n)
        {
            if (n < 0)
            {
                throw new Exception("Error: cannot find factorial of a negative number");
            }
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        public static int FindPermutationsCount(int n, int r)
        {
            if (n < 1 || r < 1 || r > n)
            {
                throw new Exception("Error: invalid n or r for permutations");
            }
            // formula: n! / (n-r)!
            return Factorial(n) / Factorial(n - r);
        }


        /*
        public static List<List<T>> FindAllPermutations<T>(List<T> values, int r)
        {
            List<List<T>> results = new List<List<T>>();

            int n = values.Count;

            // LOOK AT EXAMPLE ON SLIDE 9

            for (int i = 0; i < n-1; i++)
            {
                results.Add(new List<T>() { values[i] });
            }
            


            return results;
        }

        /// <summary>
        /// input a list of list of the original inputs.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="permutations"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<List<T>> CopyListAndAddALayerOfPossibleOptions<T>(List<List<T>> permutations, int r)
        {
            int n = permutations.Count;

            int currentLayer = permutations[0].Count;

            if (currentLayer >= r)
            {
                //gone too far
                return permutations;
            }

            //modified fisher yates shuffle

            for (int i = n-1; i > 0; i--) 
            {
                // i is the current index, also i is the amount of possible items remaining for that layer

                //for each i
                    //make a loop j=0, j < i-1, j++
                    // in this loop, we copy the array i-1 times,
                    // and each j swap the array[i] with array[i+j]
                        //then we would need to do the above again (recusrion!!

            }
        }
        */

        public static List<List<T>> CreateAllPermutations<T>(List<T> input, int r)
        {
            int n = input.Count;
            List<List<T>> results = Permutate(input, n, r, 0);

            if (n > r)
            {
                foreach (List<T> permutation in results)
                {
                    permutation.RemoveRange(r , n - r);
                }
            }

            return results;
        }

        public static List<List<T>> Permutate<T>(List<T> input, int n, int r, int currentWorkingIndex)
        {
            // n = total number of Ts
            // "In the 1 location, we can insert any of the 3 possible symbols remaining"
            // "1 location" 1 is currentWorkingIndex
            // "3 possible symbols remaining" 3 is n-currentWorkingIndex

            List<List<T>> results = new List<List<T>>();

            // exit condition!!
            if (currentWorkingIndex == r)
            {
                results.Add(input);
                return results;
            }


            int possibleSymbolsRemaining = n - currentWorkingIndex;

            for (int j = 0; j < possibleSymbolsRemaining; j++) 
            {
                /*if (j == 0)
                {
                    // just leave it there, that can be the default one
                    results.Add(input);
                }
                else
                */
                {


                    List<T> current = new List<T>(input); // copy input
                    // should be left alone for the first one when j == 0
                    Swapper.SwapValuesAtIndices(current, currentWorkingIndex, currentWorkingIndex + j);

                    results.AddRange(Permutate(current, n, r, currentWorkingIndex + 1));
                }
            }
            return results;
        }

        public static List<List<T>> CreateAllCombinations<T>(List<T> input, int r)
        {
            int n = input.Count;
            List<List<T>> results = new List<List<T>>();



            return results;
        }



        
    }
}
