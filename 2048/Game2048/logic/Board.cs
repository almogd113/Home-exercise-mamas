using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048.logic
{
    public class Board
    {
        private const int EmptyCellValue = 0;
        private const int Size = 4;
        private int _pointPreMovement;
        private List<Cell> _emptyCellsPosition;
        public int[,] Data
        { get; protected set; }

        public Board()
        {
            this.Data = new int[Size, Size];
            _pointPreMovement = 0;
            _emptyCellsPosition = new List<Cell>();
            GetEmptyCells();

        }

        public void Initalize()
        {
            //initalize two random empty cells with values: 2 or 4
            SetValueRandomCell();
            SetValueRandomCell();
        }

        public void SetValueRandomCell()
        {
            //random value and empty cell
            Random rnd = new Random();
            int rndCellValue = rnd.NextDouble() > 1 ? 2 : 4;
            int rndCellIndex = this.GetRandomEmptyCellIndex();

            //remove cell from empty cells list
            Cell cellToSet = _emptyCellsPosition[rndCellIndex];
            RemoveCellFromEmptyCellsList(cellToSet.Row, cellToSet.Col);

            //set cell value
            Data[cellToSet.Row, cellToSet.Col] = rndCellValue;

        }

        public void RemoveCellFromEmptyCellsList(int row, int col)
        {
            foreach (Cell item in _emptyCellsPosition)
            {
                if (item.Row == row && item.Col == col)
                {
                    _emptyCellsPosition.Remove(item);
                    return;
                }
            }
        }

        public int GetRandomEmptyCellIndex()
        {
            int countEmptyCells = _emptyCellsPosition.Count;
            Random rnd = new Random();
            int choosenCellIndex = rnd.Next(0, countEmptyCells + 1);
            return choosenCellIndex;

        }

        private int GetCellValue(Cell cell)
        {
            return Data[cell.Row, cell.Col];
        }
        private void GetEmptyCells()
        {

            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    if (Data[i, j] == EmptyCellValue)
                        _emptyCellsPosition.Add(new Cell(i, j));
                }
            }

        }

        ////move functions:
        ////public int Move(Direction direction)
        ////{
        ////    //move up

        ////    //move down
        ////    //move left
        ////    //move right

        ////}
        //public int MergeVertically(Direction direction)
        //{
        //    //merging same cells
        //    for (int i = 0; i < Data.GetLength(0) - 1; i++)
        //    {
        //        for (int j = 0; j < Data.GetLength(1); j++)
        //        {
        //            //moving up - rows different, cols are the same
        //            Cell upperCell = new Cell(i, j);
        //            Cell bottomCell = new Cell(i + 1, j);
        //            if (IsSameValue(bottomCell, upperCell))
        //            {
        //                //merging up cells 
        //                Cell cellToMergeValue = upperCell;
        //                Cell cellToEmptyValue = bottomCell;
        //                //merging down cells
        //                if(direction == Direction.Down)
        //                {
        //                    cellToMergeValue = bottomCell;
        //                    cellToEmptyValue = upperCell;
        //                }

        //                //merge cells operation
        //                this.MergeCells(cellToMergeValue, cellToEmptyValue);
        //                int valueCellMerged = GetCellValue(cellToMergeValue);
        //                _pointPreMovement += valueCellMerged;
        //            }

        //        }
        //    }
        //    return _pointPreMovement;
        //}

        //public int MergeHorizontally(Direction direction)
        //{
        //    //merging same cells
        //    for (int i = 0; i < Data.GetLength(0) - 1; i++)
        //    {
        //        for (int j = 0; j < Data.GetLength(1); j++)
        //        {
        //            //moving up - rows different, cols are the same
        //            Cell upperCell = new Cell(i, j);
        //            Cell bottomCell = new Cell(i + 1, j);
        //            if (IsSameValue(bottomCell, upperCell))
        //            {
        //                //merging up cells 
        //                Cell cellToMergeValue = upperCell;
        //                Cell cellToEmptyValue = bottomCell;
        //                //merging down cells
        //                if (direction == Direction.Down)
        //                {
        //                    cellToMergeValue = bottomCell;
        //                    cellToEmptyValue = upperCell;
        //                }

        //                //merge cells operation
        //                this.MergeCells(cellToMergeValue, cellToEmptyValue);
        //                int valueCellMerged = GetCellValue(cellToMergeValue);
        //                _pointPreMovement += valueCellMerged;
        //            }

        //        }
        //    }
        //    return _pointPreMovement;
        //}


        //public bool IsSameValue(Cell firstCell, Cell secondCell)
        //{
        //    return Data[firstCell.Row, firstCell.Col] == Data[secondCell.Row, secondCell.Col];

        //}
        //public void SetCellValueMerged(Cell cell)
        //{
        //    Data[cell.Row, cell.Col] *= 2;
        //}

        //public void SetCellEmpty(Cell cell)
        //{
        //    Data[cell.Row, cell.Col] = EmptyCellValue;
        //}

        //public void MergeCells(Cell cellToMergeValue, Cell cellToEmptyValue)
        //{
        //    SetCellValueMerged(cellToMergeValue);
        //    SetCellEmpty(cellToEmptyValue);
        //}
    }
}
