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
        public override TransactionResult AddQuarter()
        {
            return new TransactionResult(new QuarterInState(), VendingMachine.OutputItems.Nothing);
        }

        public override TransactionResult Cancel()
        {
            return new TransactionResult(this, VendingMachine.OutputItems.Nothing);
        }

        public override TransactionResult Purchase()
        {
            return new TransactionResult(this, VendingMachine.OutputItems.Nothing);
        }
    }
}
