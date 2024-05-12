using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048.Logic
{
    public class Board
    {
        private const int EmptyCellValue = 0;
        private const int Size = 4;
        private int _pointPreMovement;
        private List<Pos> _emptyCellsPosition;
        public Pos MaxValueCellPos
        { get; private set; }
        public int[,] Data
        { get; protected set; }

        public Board()
        {
            this.Data = new int[Size, Size];
            _pointPreMovement = 0;
            _emptyCellsPosition = new List<Pos>();
            GetEmptyCells();
            MaxValueCellPos = new Pos(0, 0); //init 
           

        }
        public Board(Board board)
        {
            Data = board.Data;
            _pointPreMovement = board._pointPreMovement;
            _emptyCellsPosition = board._emptyCellsPosition;
            MaxValueCellPos = board.MaxValueCellPos;
            
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

        }

        public void SetValueRandomCell()
        {
            //random value and empty cell
            Random rnd = new Random();
            int rndCellValue = rnd.NextDouble() > 0.5 ? 2 : 4;
            int rndCellIndex = this.GetRandomEmptyCellIndex();

            //remove cell from empty cells list
            Pos cellToSet = _emptyCellsPosition[rndCellIndex];
            RemoveCellFromEmptyCellsList(cellToSet.Row, cellToSet.Col);

            //set cell value
            Data[cellToSet.Row, cellToSet.Col] = rndCellValue;
            MaxValueCellPos = rndCellValue > GetCellValue(MaxValueCellPos) ? cellToSet : MaxValueCellPos;


        }

        public void RemoveCellFromEmptyCellsList(int row, int col)
        {
            foreach (Pos item in _emptyCellsPosition)
            {
                if (item.Row == row && item.Col == col)
                {
                    _emptyCellsPosition.Remove(item);
                    return;
                }
            }
        }

        public void AddCellToEmptyCellsList(Pos cell)
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

        public int GetNumberEmptyCells()
        {
            return _emptyCellsPosition.Count;
        }

        public int GetCellValue(Pos cell)
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
                        _emptyCellsPosition.Add(new Pos(i, j));
                }
            }

        }

        ////move functions:
        public int Move(Direction direction)
        {
            int pointsForMove = direction == Direction.Up || direction == Direction.Down ? MoveVertically(direction) : MoveHorizantlly(direction);
            if(GetNumberEmptyCells() > 0)
                SetValueRandomCell();
            return pointsForMove;
        }

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

                    Pos firstEmptyCell = GetFirstEmptyCell(col, row ,direction);
                    Pos firstValuedCell = GetFirstValuedCellInCol(col, row, direction);
                    if ((firstValuedCell.Row != -1 && firstValuedCell.Col != -1) &&
                        (firstEmptyCell.Row >= 0 && firstEmptyCell.Row < Data.GetLength(0)))
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

        public bool IsBoardIdentical(Board boardToCompare)
        {
            for (int i = 0; i < this.Data.GetLength(0); i++)
            {
                for (int j = 0; j < this.Data.GetLength(1); j++)
                {
                    if (boardToCompare.Data[i, j] != this.Data[i, j])
                        return false;
                }
            }
            return true;
        }
        public int MoveHorizantlly(Direction direction)
        {
            //init merge:
            _pointPreMovement = this.MergeHorizontally(direction);

            //first movement:
            //  setting data for loop
            int init = 0;
            int end = Data.GetLength(0) - 1;

            int coefficient = direction == Direction.Left ? 1 : -1;

            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = direction == Direction.Left ? init : end;
                    col + coefficient >= 0 && col + coefficient < Data.GetLength(0);
                    col += coefficient)
                {

                    Pos firstEmptyCell = GetFirstEmptyCell(col,row, direction);
                        Pos firstValuedCell = GetFirstValuedCellInRow(col, row, direction);
                        if ((firstValuedCell.Row != -1 && firstValuedCell.Col != -1) &&
                            (firstEmptyCell.Row >= 0 && firstEmptyCell.Row < Data.GetLength(0)))
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
        
        private Pos GetFirstEmptyCell(int col, int row, Direction direction)
        {
            //for Up
            int prevValueRowUp = 4; // default to start running on the list , does not exist
            //for Down
            int prevValueRowDown = -1; //default to start running on the list , does not exist

            //for Right
            int prevValueColRight = -1;

            //for Left
            int prevValueColLeft = 4;
            foreach (Pos item in _emptyCellsPosition)
            {
                if (direction == Direction.Down || direction == Direction.Up)
                {
                    if (item.Col == col)
                    {
                        prevValueRowUp = item.Row < prevValueRowUp ? item.Row : prevValueRowUp;
                        prevValueRowDown = item.Row > prevValueRowDown ? item.Row : prevValueRowDown;
                    }
                }

                else //for Left and Right
                {
                    if(item.Row == row)
                    {
                        prevValueColRight = item.Col > prevValueColRight ? item.Col : prevValueColRight;
                        prevValueColLeft = item.Col < prevValueColLeft ? item.Col : prevValueColLeft;
                    }
                }
              
            }
            Pos minEmptyCellUp = new Pos(prevValueRowUp, col);
            Pos maxEmptyCellDown = new Pos(prevValueRowDown, col);
            Pos maxEmptyCellRight = new Pos(row, prevValueColRight);
            Pos minEmptyCellLeft = new Pos(row, prevValueColLeft);

            if (direction == Direction.Up)
                return minEmptyCellUp;
            else if (direction == Direction.Down)
                return maxEmptyCellDown;
            else if (direction == Direction.Right)
                return maxEmptyCellRight;
            else
                return minEmptyCellLeft;
        }

        private Pos GetFirstValuedCellInCol(int col, int initRow, Direction direction)
        {
            int coefficient = direction == Direction.Up ? 1 : -1;

            for (int row = initRow;
                row  >= 0 && row < Data.GetLength(0);
                row += coefficient)
            {
                if (Data[row, col] != EmptyCellValue)
                    return new Pos(row, col);
            }

            return new Pos(-1, -1); //does not exist
        }

        public Pos GetFirstValuedCellInRow(int initCol, int row, Direction direction)
        {
            int coefficient = direction == Direction.Left ? 1 : -1;
            for (int col = initCol;
            col >= 0 && col < Data.GetLength(0);
            col += coefficient)
            {
                if (Data[row, col] != EmptyCellValue)
                    return new Pos(row, col);
            }
            return new Pos(-1, -1); //does not exist

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
                    Pos upperCell;
                    Pos bottomCell;
                    if (direction == Direction.Up)
                    {
                        //moving up - rows different, cols are the same
                        upperCell = new Pos(row, col);
                        bottomCell = new Pos(row + 1, col);
                    }
                    else
                    {
                        //moving down - rows different, cols are the same
                        upperCell = new Pos(row-1, col);
                        bottomCell = new Pos(row, col);
                    }
                    if (IsSameValue(bottomCell, upperCell))
                    {
                        //merging up cells 
                        Pos cellToMergeValue = upperCell;
                        Pos cellToEmptyValue = bottomCell;
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
                        MaxValueCellPos = valueCellMerged > GetCellValue(MaxValueCellPos) ? cellToMergeValue : MaxValueCellPos;
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

            int coefficient = direction == Direction.Left ? 1 : -1;
            //merging same cells
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = direction == Direction.Left ? init : end;
                    col + coefficient >= 0 && col + coefficient < Data.GetLength(0);
                    col += coefficient)
                {
                    Pos rightPos;
                    Pos leftPos;
                    //moving Right - rows are the same, cols are different
                    if(direction == Direction.Right)
                    {
                        rightPos = new Pos(row, col);
                        leftPos = new Pos(row, col - 1);
                    }

                    else
                    {
                        rightPos = new Pos(row, col + 1);
                        leftPos = new Pos(row, col);
                    }
                    if (IsSameValue(rightPos, leftPos))
                    {
                        //merging Right cells 
                        Pos cellToMergeValue = rightPos;
                        Pos cellToEmptyValue = leftPos;
                        //merging Left cells
                        if (direction == Direction.Left)
                        {
                            cellToMergeValue = leftPos;
                            cellToEmptyValue = rightPos;
                        }

                        //merge cells operation
                        this.MergeCells(cellToMergeValue, cellToEmptyValue);
                        int valueCellMerged = GetCellValue(cellToMergeValue);
                        _pointPreMovement += valueCellMerged;
                        AddCellToEmptyCellsList(cellToEmptyValue);
                        MaxValueCellPos = valueCellMerged > GetCellValue(MaxValueCellPos) ? cellToMergeValue : MaxValueCellPos;


                    }

                }
            }
            return _pointPreMovement;
        }


        public bool IsSameValue(Pos firstCell, Pos secondCell)
        {
            return Data[firstCell.Row, firstCell.Col] == Data[secondCell.Row, secondCell.Col]
               && Data[firstCell.Row, firstCell.Col] != EmptyCellValue;
        }
        private bool IsOnColsLimits(Pos movingCell, Pos targetMovingCell, Direction direction)
        {
            if (direction == Direction.Up)
            {
                return movingCell.Col == targetMovingCell.Col &&
                       movingCell.Row > targetMovingCell.Row;
            }
            else if(direction == Direction.Down)
            {
                return movingCell.Col == targetMovingCell.Col &&
                       movingCell.Row < targetMovingCell.Row;
            }
            else if(direction == Direction.Right)
            {
                return movingCell.Row == targetMovingCell.Row &&
                    movingCell.Col < targetMovingCell.Col;
            }
            else
            {
                return movingCell.Row == targetMovingCell.Row &&
                 movingCell.Col > targetMovingCell.Col;
            }

        }
        public void MoveCell(Pos movingCell, Pos targetMovingCell)
        {
            Data[targetMovingCell.Row, targetMovingCell.Col] = Data[movingCell.Row, movingCell.Col];
            SetCellEmpty(movingCell);
        }
        public void SetCellValueMerged(Pos cell)
        {
            Data[cell.Row, cell.Col] *= 2;
        }

        public void SetCellEmpty(Pos cell)
        {
            Data[cell.Row, cell.Col] = EmptyCellValue;
        }

        public void MergeCells(Pos cellToMergeValue, Pos cellToEmptyValue)
        {
            SetCellValueMerged(cellToMergeValue);
            SetCellEmpty(cellToEmptyValue);
        }
    }
}

