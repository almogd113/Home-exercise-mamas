using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048.logic
{
    public class Cell
    {
        public int Row
        { get; private set; }

        public int Col
        { get; private set; }

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
