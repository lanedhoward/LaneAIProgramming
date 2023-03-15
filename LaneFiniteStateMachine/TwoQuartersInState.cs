using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneFiniteStateMachine
{
    public class TwoQuartersInState : VendingMachineState
    {
        public TwoQuartersInState() : base()
        {
            Dialogue = "The machine has 2 quarters in.";
        }
        public override FSMOutput AddQuarter()
        {
            return new FSMOutput(new ThreeQuartersInState(), VendingMachine.OutputItems.Nothing);
        }

        public override FSMOutput Cancel()
        {
            return new FSMOutput(new LockedState(), VendingMachine.OutputItems.TwoQuarters);
        }

        public override FSMOutput Purchase()
        {
            return new FSMOutput(new LockedState(), VendingMachine.OutputItems.Gum);
        }
    }
}
