using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaneLibrary;
using static LaneLibrary.ConsoleUtils;

namespace LanePermutations
{
    public class PermutationsDemo
    {
        private string Input;
        private List<char> InputList;

        public PermutationsDemo()
        {
            Input = "";
            InputList = new List<char>();
        }

        public void Run()
        {
            Setup();
            GetInput();
            FindAllPermutations();
            FindAllOrderedPartitions();
            FindAllCombinations();

            ClearScrollable();
            Print("Play again?");
            if (GetInputBool())
            {
                ClearScrollable();
                Run();
            }
        }

        public void WelcomeMessage()
        {
            Print("Welcome to Lane's Permutations and Counting Demo");
        }

        public void Setup()
        {
            WelcomeMessage();
            Console.Title = "Lane's Permutations and Counting Demo";
        }

        public void GetInput()
        {
            Print("Please enter 5 characters: ");
            string? rawInput = Console.ReadLine();

            if (String.IsNullOrEmpty(rawInput) || rawInput.Length < 5)
            {
                Print("Error: Not enough characters");
                WaitForKeyPress();
                ClearScrollable();
                GetInput();
                return;
            }
            else
            {
                Input = rawInput.Substring(0, 5);
                Print("Your input was: " + Input);
                InputList = Input.ToList();
                WaitForKeyPress();
            }

        }

        public void FindAllPermutations()
        {
            ClearScrollable();
            Print("1- All permutations of 5P1, 5P2, 5P3,  5P4, 5P5 and their count");
            WaitForKeyPress();

            DemoPermutationsPick(1, InputList);
            DemoPermutationsPick(2, InputList);
            DemoPermutationsPick(3, InputList);
            DemoPermutationsPick(4, InputList);
            DemoPermutationsPick(5, InputList);
        }
        public void FindAllOrderedPartitions()
        {
            ClearScrollable();
            Print("2- All Ordered partitions where n = length of input");
            WaitForKeyPress();

            DemoOrderedPartitionsPick(2, InputList);
        }
        public void FindAllCombinations()
        {
            ClearScrollable();
            Print("3- All combinations of 5C1, 5C2, 5C3, 5C4, 5C5 and their count");
            WaitForKeyPress();

            DemoCombinationsPick(1, InputList);
            DemoCombinationsPick(2, InputList);
            DemoCombinationsPick(3, InputList);
            DemoCombinationsPick(4, InputList);
            DemoCombinationsPick(5, InputList);
        }

        public void DemoPermutationsPick(int r, List<char> input)
        {
            ClearScrollable();
            Print($"This is all possible permutations for {input.Count}P{r} ");

            List<List<char>> permutations = PermutationsMath.CreateAllPermutations(InputList, r);

            PrintListListChar(permutations);
            
            Print("Total Permutations: " + PermutationsMath.FindPermutationsCount(InputList.Count, r));
            WaitForKeyPress();
        }

        public void DemoOrderedPartitionsPick(int r, List<char> input)
        {
            ClearScrollable();
            Print($"This is all possible ordered partitions for {input.Count}P{r} ");

            List<List<char>> partitions = PermutationsMath.CreateAllOrderedPartitions(InputList, InputList.Count);

            PrintListListChar(partitions);

            List<int> rs = new List<int>();

            /*
             * this was my attempt to find duplicates but it didn't work
             * 
            for (int i = 0; i < InputList.Count; i++)
            {
                int repeats = 0;
                for (int j = 0; j < i; j++)
                {
                    if (InputList[i] == InputList[j])
                    {
                        repeats += 1;
                    }
                }
                if (repeats > 0)
                {
                    rs.Add(repeats);
                }
            }
            */

            // linq query to find how many duplicate items adapted from
            // https://stackoverflow.com/questions/18547354/c-sharp-linq-find-duplicates-in-list
            var query = InputList.GroupBy(x => x) //group if they have the same value
              .Where(g => g.Count() > 1) // get the groups that have more than 1 member
              .ToDictionary(x => x.Key, y => y.Count()); // put that in a dictionary
            foreach (var k in query) //then i take that dictionary and make it into my rs list
            {
                rs.Add(k.Value); 
            }

            Print("Total Ordered Partitions: " + PermutationsMath.FindOrderedPartitionsCount(InputList.Count, rs));
            WaitForKeyPress();
        }

        public void DemoCombinationsPick(int r, List<char> input)
        {
            ClearScrollable();
            Print($"This is all possible combinations for {input.Count}P{r} ");

            List<List<char>> combinations = PermutationsMath.CreateAllCombinations(InputList, r);

            PrintListListChar(combinations);

            Print("Total Combinations: " + PermutationsMath.FindCombinationsCount(InputList.Count, r));
            WaitForKeyPress();
        }

        public void PrintListListChar(List<List<char>> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                List<char> chars = input[i];
                PrintSameLine((i + 1) + ".   ");

                Print(new string(chars.ToArray()));
            }
            Print();
        }

        
    }
}
