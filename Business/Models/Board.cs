using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Board
    {
        public int[] _grid { get; set; }

        public Board()
        {
            this.Reset();
        }

        public void PaintBox(int position, int playerId)
        {
            if (this.BoxIsEmpty(position)) _grid[position - 1] = playerId;

        }

        //revisar 
        
        //public bool PaintBox(int position, int playerId)
        //{
        //    if (this.BoxIsEmpty(position))
        //    {
        //        _grid[position - 1] = playerId;
        //        return true;
        //    }        
        //     return false;        
        //}

        //public bool PaintBox(int position, int playerId)
        //{
        //    bool boxIsPainted = !this.BoxIsEmpty(position);

        //    if (!boxIsPainted) _grid[position - 1] = playerId;

        //    return boxIsPainted;
        //}

        public bool BoxIsEmpty(int position)
        {
            return this._grid[position - 1] == 0;
        }

        public bool IsFull()
        {
            return this._grid.All(x => x != 0);
        }

        public void Reset()
        {
            this._grid = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public List<int[]> GetLines()
        {
            List<int[]> lines = new List<int[]>();

            // Filas
            lines.Add(new int[] { this._grid[0], this._grid[1], this._grid[2] });
            lines.Add(new int[] { this._grid[3], this._grid[4], this._grid[5] });
            lines.Add(new int[] { this._grid[6], this._grid[7], this._grid[8] });

            // Columas
            lines.Add(new int[] { this._grid[0], this._grid[3], this._grid[6] });
            lines.Add(new int[] { this._grid[1], this._grid[4], this._grid[7] });
            lines.Add(new int[] { this._grid[2], this._grid[5], this._grid[8] });

            // Diagonales
            lines.Add(new int[] { this._grid[0], this._grid[4], this._grid[8] });
            lines.Add(new int[] { this._grid[2], this._grid[4], this._grid[6] });

            return lines;
        }
    }
}
