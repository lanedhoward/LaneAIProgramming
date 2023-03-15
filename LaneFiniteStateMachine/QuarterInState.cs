using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneFiniteStateMachine
{
    public class QuarterInState : VendingMachineState
    {
        public QuarterInState() : base()
        {
            Dialogue = "The machine has 1 quarter in.";
        }
        public override FSMOutput AddQuarter()
        {
            return new FSMOutput(new TwoQuartersInState(), VendingMachine.OutputItems.Nothing);
        }

        public override FSMOutput Cancel()
        {
            return new FSMOutput(new LockedState(), VendingMachine.OutputItems.Quarter);
        }

        public override FSMOutput Purchase()
        {
            return new FSMOutput(this, VendingMachine.OutputItems.Nothing);
        }
    }
}
