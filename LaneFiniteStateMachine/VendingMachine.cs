using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaneLibrary;
using static LaneLibrary.ConsoleUtils;

namespace LaneFiniteStateMachine
{
    public class VendingMachine
    {
        /*

            Write a FSM code for the following:

            A Vending machine that sells [ Gum for $0.50 ] and [ Granola for $0.75]. 
            The buyer can insert as many coins as they want, 
            but the machine takes only [Quarters] and can dispense [one item] per [transaction]. 

            Items in [ ] are singletons.

            To help you write your code, first Define the States, Inputs, and Transactions. 

            States = { Locked, QuarterIn, TwoQuartersIn, ThreeQuartersIn}
            Inputs = { AddQuarter, Cancel, Purchase }
            Output = { Gum, Granola, Nothing, Quarter }
         */
        public enum OutputItems
        {
            Gum,
            Granola,
            Nothing,
            Quarter,
            TwoQuarters,
            ThreeQuarters
        }

        VendingMachineState currentState;

        public VendingMachine()
        {
            currentState = new LockedState();
        }

        public void Run()
        {
            ClearScrollable();

            Print(@"
--------------------------------------------------
VENDING MACHINE
GUM: 50 CENTS
GRANOLA: 75 CENTS
--------------------------------------------------
");

            Print(currentState.SayDialogue());

            FSMOutput output;

            Print("Please input what you would like to do. 1: Add quarter. 2: Cancel. 3: Purchase");
            int input = GetInputIntKey(1, 3);
            switch(input)
            {
                case 1:
                    Print("Adding quarter...");
                    output = currentState.AddQuarter();
                    break;
                default:
                case 2:
                    Print("Canceling...");
                    output = currentState.Cancel();
                    break;
                case 3:
                    Print("Purchasing...");
                    output = currentState.Purchase();
                    break;
            }
            if (output.outputItem != OutputItems.Nothing)
            {
                Print("You got " + output.outputItem.ToString());
            }

            WaitForKeyPress(true);
            currentState = output.newState;
            Run();
        }
    }
}
