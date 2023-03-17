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
        public override TransactionResult AddQuarter()
        {
            return new TransactionResult(new ThreeQuartersInState(), VendingMachine.OutputItems.Nothing);
        }

        public override TransactionResult Cancel()
        {
            return new TransactionResult(new LockedState(), VendingMachine.OutputItems.TwoQuarters);
        }

        public override TransactionResult Purchase()
        {
            return new TransactionResult(new LockedState(), VendingMachine.OutputItems.Gum);
        }
    }
}
