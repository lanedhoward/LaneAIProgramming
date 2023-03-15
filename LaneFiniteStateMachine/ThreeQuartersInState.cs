using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneFiniteStateMachine
{
    public class ThreeQuartersInState : VendingMachineState
    {
        public ThreeQuartersInState() : base()
        {
            Dialogue = "The machine has 3 quarters in.";
        }
        public override FSMOutput AddQuarter()
        {
            return new FSMOutput(this, VendingMachine.OutputItems.Quarter);
        }

        public override FSMOutput Cancel()
        {
            return new FSMOutput(new LockedState(), VendingMachine.OutputItems.ThreeQuarters);
        }

        public override FSMOutput Purchase()
        {
            return new FSMOutput(new LockedState(), VendingMachine.OutputItems.Granola);
        }
    }
}
