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
        public override TransactionResult AddQuarter()
        {
            return new TransactionResult(this, VendingMachine.OutputItems.Quarter);
        }

        public override TransactionResult Cancel()
        {
            return new TransactionResult(new LockedState(), VendingMachine.OutputItems.ThreeQuarters);
        }

        public override TransactionResult Purchase()
        {
            return new TransactionResult(new LockedState(), VendingMachine.OutputItems.Granola);
        }
    }
}
