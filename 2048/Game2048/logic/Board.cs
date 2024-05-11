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
            SetValueRandomCell();
            SetValueRandomCell();
            SetValueRandomCell();
            SetValueRandomCell();
            SetValueRandomCell();
            SetValueRandomCell();
            SetValueRandomCell();
            SetValueRandomCell();
            SetValueRandomCell();
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

        public void AddCellToEmptyCellsList(Cell cell)
        {
            _emptyCellsPosition.Add(cell);
        }

        public int GetRandomEmptyCellIndex()
        {
            int countEmptyCells = _emptyCellsPosition.Count;
            Random rnd = new Random();
            int choosenCellIndex = rnd.Next(0, countEmptyCells);
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

        public int MoveVertically(Direction direction)
        {
            // Merge Cells that are next to each other and have the same value

            //init merge:
            _pointPreMovement = this.MergeVertically(direction);

            //first movement:
            //  setting data for loop
            int init = 0;
            int end = Data.GetLength(0)-1;

            int coefficient = direction == Direction.Up ? 1 : -1;

            for (int row = direction == Direction.Up ? init : end;
                row + coefficient >= 0 && row + coefficient < Data.GetLength(0);
                row += coefficient)
            {

                for (int col = 0; col < Data.GetLength(0); col += 1)
                {

                    Cell firstEmptyCell = GetFirstEmptyCellInCol(col,direction);
                    Cell firstValuedCell = GetFirstValuedCellInCol(col, row, direction);
                    if (firstValuedCell.Row != -1 && firstValuedCell.Col != -1)
                    {
                        if (IsOnColsLimits(firstValuedCell, firstEmptyCell, direction))
                        {
                            MoveCell(firstValuedCell, firstEmptyCell);
                            RemoveCellFromEmptyCellsList(firstEmptyCell.Row, firstEmptyCell.Col);
                            AddCellToEmptyCellsList(firstValuedCell);
                        }
                    }
                }
            }
            return _pointPreMovement;

        }
        private Cell GetFirstEmptyCellInCol(int col, Direction direction)
        {
            //for Up
            int prevValueRowUp = 4; // default to start running on the list , does not exist
            //for Down
            int prevValueRowDown = -1; //default to start running on the list , does not exist
            foreach (Cell item in _emptyCellsPosition)
            {
                if (item.Col == col)
                {
                    prevValueRowUp = item.Row < prevValueRowUp ? item.Row : prevValueRowUp;
                    prevValueRowDown = item.Row > prevValueRowDown ? item.Row : prevValueRowDown;
                }
            }
            Cell minEmptyCell = new Cell(prevValueRowUp, col);
            Cell maxEmptyCell = new Cell(prevValueRowDown, col);
            if(direction == Direction.Up)
                return minEmptyCell;
            return maxEmptyCell;
        }

        private Cell GetFirstValuedCellInCol(int col, int initRow, Direction direction)
        {
            int end = Data.GetLength(0)-1;
            int coefficient = direction == Direction.Up ? 1 : -1;

            for (int row = initRow;
                row + coefficient >= 0 && row + coefficient < Data.GetLength(0);
                row += coefficient)
            {
                if (Data[row, col] != EmptyCellValue)
                    return new Cell(row, col);
            }

            return new Cell(-1, -1); //does not exist
        }
        private bool canMove(Cell current, Cell next)
        {
            //check if there is an empty cell to move the next cell.
            return Data[current.Row, current.Col] == EmptyCellValue && Data[next.Row, next.Col] != EmptyCellValue;
        }
     
        public int MergeVertically(Direction direction)
        {
            //  setting data for loop
            int init = 0;
            int end = Data.GetLength(0)-1;

            int coefficient = direction == Direction.Up ? 1 : -1;

            for (int row = direction == Direction.Up ? init : end;
                row + coefficient >= 0 && row + coefficient < Data.GetLength(0);
                row += coefficient)
            {
                for (int col = 0; col < Data.GetLength(0); col += 1)
                {
                    Cell upperCell;
                    Cell bottomCell;
                    if (direction == Direction.Up)
                    {
                        //moving up - rows different, cols are the same
                        upperCell = new Cell(row, col);
                        bottomCell = new Cell(row + 1, col);
                    }
                    else
                    {
                        //moving down - rows different, cols are the same
                        upperCell = new Cell(row-1, col);
                        bottomCell = new Cell(row, col);
                    }
                    if (IsSameValue(bottomCell, upperCell))
                    {
                        //merging up cells 
                        Cell cellToMergeValue = upperCell;
                        Cell cellToEmptyValue = bottomCell;
                        //merging down cells
                        if (direction == Direction.Down)
                        {
                            cellToMergeValue = bottomCell;
                            cellToEmptyValue = upperCell;
                        }

                        //merge cells operation
                        this.MergeCells(cellToMergeValue, cellToEmptyValue);
                        int valueCellMerged = GetCellValue(cellToMergeValue);
                        AddCellToEmptyCellsList(cellToEmptyValue);
                        _pointPreMovement += valueCellMerged;
                    }

                }
            }
            return _pointPreMovement;
        }

        public int MergeHorizontally(Direction direction)
        {
            //  setting data for loop
            int init = 0;
            int end = Data.GetLength(0)-1;

            int coefficient = direction == Direction.Up ? 1 : -1;
            //merging same cells
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = direction == Direction.Up ? init : end;
                    row + coefficient >= 0 && col + coefficient < Data.GetLength(0);
                    col += coefficient)
                {
                    //moving up - rows different, cols are the same
                    Cell upperCell = new Cell(row, col);
                    Cell bottomCell = new Cell(row + 1, col);
                    if (IsSameValue(bottomCell, upperCell))
                    {
                        //merging up cells 
                        Cell cellToMergeValue = upperCell;
                        Cell cellToEmptyValue = bottomCell;
                        //merging down cells
                        if (direction == Direction.Down)
                        {
                            cellToMergeValue = bottomCell;
                            cellToEmptyValue = upperCell;
                        }

                        //merge cells operation
                        this.MergeCells(cellToMergeValue, cellToEmptyValue);
                        int valueCellMerged = GetCellValue(cellToMergeValue);
                        _pointPreMovement += valueCellMerged;

                    }

                }
            }
            return _pointPreMovement;
        }


        public bool IsSameValue(Cell firstCell, Cell secondCell)
        {
            return Data[firstCell.Row, firstCell.Col] == Data[secondCell.Row, secondCell.Col]
               && Data[firstCell.Row, firstCell.Col] != EmptyCellValue;
        }
        private bool IsOnColsLimits(Cell movingCell, Cell targetMovingCell, Direction direction)
        {
            if (direction == Direction.Up)
            {
                return movingCell.Col == targetMovingCell.Col &&
                       movingCell.Row > targetMovingCell.Row;
            }
            else
            {
                return movingCell.Col == targetMovingCell.Col &&
                       movingCell.Row < targetMovingCell.Row;
            }
        }
        public void MoveCell(Cell movingCell, Cell targetMovingCell)
        {
            Data[targetMovingCell.Row, targetMovingCell.Col] = Data[movingCell.Row, movingCell.Col];
            SetCellEmpty(movingCell);
        }
        public void SetCellValueMerged(Cell cell)
        {
            Data[cell.Row, cell.Col] *= 2;
        }

        public void SetCellEmpty(Cell cell)
        {
            Data[cell.Row, cell.Col] = EmptyCellValue;
        }

        public void MergeCells(Cell cellToMergeValue, Cell cellToEmptyValue)
        {
            SetCellValueMerged(cellToMergeValue);
            SetCellEmpty(cellToEmptyValue);
        }
    }
}

