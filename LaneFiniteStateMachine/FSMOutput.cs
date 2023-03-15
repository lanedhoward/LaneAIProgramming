using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneFiniteStateMachine
{
    public class FSMOutput
    {
        public VendingMachineState newState;
        public VendingMachine.OutputItems outputItem;

        public FSMOutput(VendingMachineState _newState, VendingMachine.OutputItems _outputItem)
        {
            newState = _newState;
            outputItem = _outputItem;
        }
    }
}
