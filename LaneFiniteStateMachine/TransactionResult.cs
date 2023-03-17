using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneFiniteStateMachine
{
    public class TransactionResult
    {
        public VendingMachineState newState;
        public VendingMachine.OutputItems outputItem;

        public TransactionResult(VendingMachineState _newState, VendingMachine.OutputItems _outputItem)
        {
            newState = _newState;
            outputItem = _outputItem;
        }
    }
}
