using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneFiniteStateMachine
{
    public abstract class VendingMachineState
    {

        protected string Dialogue;


        public VendingMachineState()
        {
            Dialogue = "Testing ";
        }

        public virtual string SayDialogue()
        {
            return Dialogue;
        }

        public virtual TransactionResult AddQuarter()
        {
            return new TransactionResult(this, VendingMachine.OutputItems.Nothing);
        }

        public virtual TransactionResult Cancel()
        {
            return new TransactionResult(this, VendingMachine.OutputItems.Nothing);
        }

        public virtual TransactionResult Purchase()
        {
            return new TransactionResult(this, VendingMachine.OutputItems.Nothing);
        }
    }
}
