using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneFiniteStateMachine
{
    public class LockedState : VendingMachineState
    {
        public LockedState() : base()
        {
            Dialogue = "The machine is locked";
        }
        public override FSMOutput AddQuarter()
        {
            return new FSMOutput(new QuarterInState(), VendingMachine.OutputItems.Nothing);
        }

        public override FSMOutput Cancel()
        {
            return new FSMOutput(this, VendingMachine.OutputItems.Nothing);
        }

        public override FSMOutput Purchase()
        {
            return new FSMOutput(this, VendingMachine.OutputItems.Nothing);
        }
    }
}
