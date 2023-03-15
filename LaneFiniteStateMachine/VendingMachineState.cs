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

        public virtual FSMOutput AddQuarter()
        {
            return new FSMOutput(this, VendingMachine.OutputItems.Nothing);
        }

        public virtual FSMOutput Cancel()
        {
            return new FSMOutput(this, VendingMachine.OutputItems.Nothing);
        }

        public virtual FSMOutput Purchase()
        {
            return new FSMOutput(this, VendingMachine.OutputItems.Nothing);
        }
    }
}
