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
        public Board _mainBoard;

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


        // revisar nombre
        public void CheckPlay(int boxPosition)
        {
            if (!this.GameOver)
            {
                this.Play(boxPosition);
                this.CheckWin();               
                this.ChecKBoardFull();  // empate        
                this.TogglePlayer();
            }
        }

        public void Play(int boxPosition)
        {
            this._mainBoard.PaintBox(boxPosition, _currentPlayer.Id) ;
        
        }

        public void TogglePlayer()
        {
            this._currentPlayer = (this._currentPlayer.Equals(_playerOne))
                ? this._playerTwo
                : this._playerOne;
        }

        private void CheckWin() {

            if(this._mainBoard.GetLines().Any(line => this.CheckLine(line)))
            {
                this.Winner = this._currentPlayer;
                this.GameOver = true;
            };
        }

        private bool CheckLine(int[] line) {
            return line.All(box => box == this._currentPlayer.Id);
        }

        public void ChecKBoardFull()
        {
            this.GameOver = this._mainBoard.IsFull() ? true : this.GameOver;
        }
    }
}
