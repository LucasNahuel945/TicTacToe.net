using System.Collections.Generic;
using System.Linq;

namespace Business.Models
{
    public class Board
    {
        public int[] Grid { get; private set; }

        public Board()
        {
            this.Grid = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public bool PaintBox(int position, int playerId)
        {
            if (this.IsAValidPosition(position - 1) && this.BoxIsEmpty(position - 1))
            {
                Grid[position - 1] = playerId;
                return true;
            }
            return false;
        }

        private bool BoxIsEmpty(int position)
        {
            return this.Grid[position] == 0;
        }

        private bool IsAValidPosition(int position)
        {
            return (position < this.Grid.Length) && (position >= 0);
        }

        public bool IsFull()
        {
            return this.Grid.All(x => x != 0);
        }

        public List<int[]> GetLines()
        {
            List<int[]> lines = new List<int[]>();

            // Rows
            lines.Add(new int[] { this.Grid[0], this.Grid[1], this.Grid[2] });
            lines.Add(new int[] { this.Grid[3], this.Grid[4], this.Grid[5] });
            lines.Add(new int[] { this.Grid[6], this.Grid[7], this.Grid[8] });

            // Columns
            lines.Add(new int[] { this.Grid[0], this.Grid[3], this.Grid[6] });
            lines.Add(new int[] { this.Grid[1], this.Grid[4], this.Grid[7] });
            lines.Add(new int[] { this.Grid[2], this.Grid[5], this.Grid[8] });

            // Diagonals
            lines.Add(new int[] { this.Grid[0], this.Grid[4], this.Grid[8] });
            lines.Add(new int[] { this.Grid[2], this.Grid[4], this.Grid[6] });

            return lines;
        }
    }
}
