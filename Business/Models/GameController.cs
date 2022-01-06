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
        
        private Player CurrentPlayer;
        //public Player Winner { get; private set; }
        private Board MainBoard;

        public bool GameOver { get; private set; }

        public GameController() {
            this._playerOne = new Player(1);
            this._playerTwo = new Player(2);

            // this.ResetGame();
            this.MainBoard = new Board();
            this.CurrentPlayer = _playerOne;
            this.GameOver = false;
        }

        // TODO
        public void Play(int boxPosition)
        {

            if(!GameOver)
            {
                this.MainBoard.PaintBox(boxPosition, CurrentPlayer.Id);

                if (this.CheckWin()) {
                    //this.Winner = this.CurrentPlayer;
                    this.GameOver = true;
                }
                this.TogglePlayer();
            }

            if (this.MainBoard.IsFull()) this.GameOver = true;
        }

        public void TogglePlayer()
        {
            this.CurrentPlayer = (this.CurrentPlayer.Equals(_playerOne))
                ? this._playerTwo
                : this._playerOne;
        }

        private bool CheckWin() {
            return this.MainBoard.GetLines().Any(line => this.CheckLine(line));
            
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
            return line.All(box => box == this.CurrentPlayer.Id);
        }
    }
}
