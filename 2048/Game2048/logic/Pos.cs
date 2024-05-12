﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048.logic
{
    public class Pos
    {
        public int Row
        { get; private set; }

        public int Col
        { get; private set; }

        public Pos(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}