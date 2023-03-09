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
            WaitForKeyPress();
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
            DemoPermutationsPick(1, InputList);
            DemoPermutationsPick(2, InputList);
            DemoPermutationsPick(3, InputList);
            DemoPermutationsPick(4, InputList);
            DemoPermutationsPick(5, InputList);
        }

        public void DemoPermutationsPick(int r, List<char> input)
        {
            Print($"This is all possible permutations for {input.Count}P{r} ");

            List<List<char>> permutations = PermutationsMath.CreateAllPermutations(InputList, r);

            PrintListListChar(permutations);
            
            Print("Total Permutations: " + PermutationsMath.FindPermutationsCount(InputList.Count, r));
            WaitForKeyPress();
        }

        public void PrintListListChar(List<List<char>> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                List<char> chars = input[i];
                PrintSameLine((i + 1) + ".   ");

                for (int j = 0; j < chars.Count; j++)
                {
                    PrintSameLine(chars[j].ToString());
                }
                Print();
            }
            Print();
        }

        
    }
}
