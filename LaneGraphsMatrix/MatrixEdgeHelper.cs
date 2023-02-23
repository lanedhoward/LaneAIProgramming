using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneGraphsMatrix
{
    // simple data class to hold row, column, and the 1 or 0 from the matrix input.
    // so i dont have to pass all my textboxes to the next form
    public class MatrixEdgeHelper
    {
        public int X;
        public int Y;
        public bool Connection;
        public MatrixEdgeHelper(int x, int y, bool connection)
        {
            X = x;
            Y = y;
            Connection = connection;
        }
    }
}
