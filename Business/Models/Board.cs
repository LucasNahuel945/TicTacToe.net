using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Models
{
    public class Board
    {
        private int[] _grid { get; set; }

        public Board()
        {
            this._grid = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public bool PaintBox(int position, int playerId)
        {
            if (this.IsAValidPosition(position - 1) && this.BoxIsEmpty(position - 1))
            {
                _grid[position - 1] = playerId;
                return true;
            }
            return false;
        }

        private bool BoxIsEmpty(int position)
        {
            return this._grid[position] == 0;
        }

        private bool IsAValidPosition(int position)
        {
            return (position < this._grid.Length) && (position >= 0);
        }

        public bool IsFull()
        {
            return this._grid.All(x => x != 0);
        }

        public List<int[]> GetLines()
        {
            List<int[]> lines = new List<int[]>();

            // Rows
            lines.Add(new int[] { this._grid[0], this._grid[1], this._grid[2] });
            lines.Add(new int[] { this._grid[3], this._grid[4], this._grid[5] });
            lines.Add(new int[] { this._grid[6], this._grid[7], this._grid[8] });

            // Columns
            lines.Add(new int[] { this._grid[0], this._grid[3], this._grid[6] });
            lines.Add(new int[] { this._grid[1], this._grid[4], this._grid[7] });
            lines.Add(new int[] { this._grid[2], this._grid[5], this._grid[8] });

            // Diagonals
            lines.Add(new int[] { this._grid[0], this._grid[4], this._grid[8] });
            lines.Add(new int[] { this._grid[2], this._grid[4], this._grid[6] });

            return lines;
        }

        //public string PrintBoard()
        //{
        //    string grid = "";
        //    for (int i = 0; i < 9; i ++)
        //    {
        //        grid += _grid[i].ToString();

        //    }
        //    return grid;
        //}

        public int[] GetBoard()
        {
            return this._grid;
        }
    }
}
