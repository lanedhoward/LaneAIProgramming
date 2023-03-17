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
        public override TransactionResult AddQuarter()
        {
            return new TransactionResult(new TwoQuartersInState(), VendingMachine.OutputItems.Nothing);
        }

        public override TransactionResult Cancel()
        {
            return new TransactionResult(new LockedState(), VendingMachine.OutputItems.Quarter);
        }

        public override TransactionResult Purchase()
        {
            return new TransactionResult(this, VendingMachine.OutputItems.Nothing);
        }
    }
}
