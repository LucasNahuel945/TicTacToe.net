using System.Linq;

namespace Business.Models
{
    public class GameController
    {
        private Player _playerOne;
        private Player _playerTwo;        
        private Player _currentPlayer;

        public Player Winner { get; private set; }
        public Board MainBoard { get; private set; }
        public bool GameOver { get; private set; }

        public GameController() {
            this._playerOne = new Player(1, true);
            this._playerTwo = new Player(2);
            this._currentPlayer = _playerOne;

            this.Winner = null;
            this.MainBoard = new Board();
            this.GameOver = false;
        }

        public void PlayOnceTime(int boxPosition)
        {
            if (!this.GameOver)
            {
                this.PaintBoxInBoard(boxPosition);
                this.CheckWinner();               
                this.UpdateGameStatus();  // empate        
                this.UpdateCurrentPlayer();
            }
        }

        public void PaintBoxInBoard(int boxPosition)
        {
            _currentPlayer.IsPlaying = this.MainBoard
                .PaintBox(boxPosition, _currentPlayer.Id);
        }

        private void UpdateCurrentPlayer()
        {
            if (!this._currentPlayer.IsPlaying) this.TogglePlayer();
        }
        public void TogglePlayer()
        {
            this._currentPlayer = (this._currentPlayer.Equals(_playerOne))
                ? this._playerTwo
                : this._playerOne;
        }

        private void CheckWinner()
        {
            if(this.GetThereIsCoincidenceInAnyLine())
            {
                this.Winner = this._currentPlayer;
                this.GameOver = true;
            };
        }

        private bool GetThereIsCoincidenceInAnyLine()
        {
            return this.MainBoard
                .GetLines()
                .Any(line => this.CheckCoincidenceInLine(line));
        }

        private bool CheckCoincidenceInLine(int[] line)
        {
            return line.All(box => box == this._currentPlayer.Id);
        }

        public void UpdateGameStatus()
        {
            this.GameOver = this.MainBoard.IsFull() ? true : this.GameOver;
        }
    }
}
