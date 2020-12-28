using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBusiness.Helper
{
    public class RobotSquare
    {

        public RobotSquare(int rowValue, int colValue)
        {
            RowCount = rowValue;
            ColumnCount = colValue;
        }

        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        /// Determines whether the specified x and y position exists in the table.
        public bool IsPositionExists(int xPosition, int yPosition)
        {
            return (XValueInRange(xPosition) && YValueInRange(yPosition));
        }

        /// Determines whether the specified x value in range.
        private bool XValueInRange(int xPosition)
        {
            return (xPosition >= 0 && xPosition < ColumnCount);
        }

        /// Determines whether the specified y value in range.
        private bool YValueInRange(int yPosition)
        {
            return (yPosition >= 0 && yPosition < RowCount);
        }
       
    }
}
