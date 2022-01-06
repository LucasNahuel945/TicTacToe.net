using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class GameController
    {
        private Player _playerOne;
        private Player _playerTwo;
        
        private Player _currentPlayer;
        public Player Winner { get; private set; }
        private Board _mainBoard;

        public bool GameOver { get; private set; }

        public GameController() {
            this._playerOne = new Player(1);
            this._playerTwo = new Player(2);
            this.Winner = null;
            this._mainBoard = new Board();
            this._currentPlayer = _playerOne;
            this.GameOver = false;

            // this.ResetGame();
        }

        public void CheckShifts(int boxPosition)
        {
            if (!GameOver)
            {
                this.Play(boxPosition);

                if (this.CheckWin())
                {
                    this.Winner = this._currentPlayer;
                    this.GameOver = true;
                }
                this.TogglePlayer();
            }

            if (this._mainBoard.IsFull()) this.GameOver = true;
        }

        public void Play(int boxPosition)
        {
             this._mainBoard.PaintBox(boxPosition, _currentPlayer.Id);
        }

        public void TogglePlayer()
        {
            this._currentPlayer = (this._currentPlayer.Equals(_playerOne))
                ? this._playerTwo
                : this._playerOne;
        }

        private bool CheckWin() {
            return this._mainBoard.GetLines().Any(line => this.CheckLine(line));
            
            /*
            bool status = false;

            foreach (int[] line in this.MainBoard.GetLines())
            {
                status = line.All(x => x == this.CurrentPlayer.Id);
                
                if (status) return status;
            }

            return status;
            */
        }

        private bool CheckLine(int[] line) {
            return line.All(box => box == this._currentPlayer.Id);
        }

    }
}
