using Business.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace GUI.ViewModels
{
    public class TicTacToeViewModel : INotifyPropertyChanged
    {

        public GameController _game;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
        public TicTacToeViewModel()
        {            
            Reset();
        }

        public bool ExecuteMovement(int position)
        {
            bool canPlay = _game.PlayOnceTime(Convert.ToInt32(position));
            this.CurrentPlayer = _game.GetIdCurrentPlayer();
            this.PrintCurrentPlayer = this.CurrentPlayer == 1 ? "1 Ficha: X" : "2 Ficha: O ";
            return canPlay;
        }

        public string? MessageGameEnded()
        {
            string? status = null;
            if (_game.GameOver)
            {
                if (_game.Winner != null)
                {
                    status = "Jugador ganador : " + _game.Winner.Id + ". ¿Quiere jugar otra partida ? ";
                }
                else
                {
                    status = "Empate!. ¿Quiere jugar otra partida ? ";
                }
            }
            return status;
        }

        private int _currentPlayer;
        public int CurrentPlayer
        {
            get
            {
                return _currentPlayer;
            }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        private string _printcurrentPlayer;
        public string PrintCurrentPlayer
        {
            get
            {               
                return _printcurrentPlayer;
            }
            set
            {
                _printcurrentPlayer = value;
                OnPropertyChanged(nameof(PrintCurrentPlayer));
            }
        }

        //TODO - PARA HACER EL BINDING A LOS BOTONES
        /*private string _contentButton1;
        private string _contentButton2;
        private string _contentButton3;
        private string _contentButton4;
        private string _contentButton5;
        private string _contentButton6;
        private string _contentButton7;
        private string _contentButton8;
        private string _contentButton9;

        public string ContentButton1
        {
            get
            {
                return this._contentButton1;
            }
            set
            {
                this._contentButton1 = value;
                OnPropertyChanged(nameof(ContentButton1));
            }
        }
        public string ContentButton2
        {
            get
            {
                return this._contentButton2;
            }
            set
            {
                this._contentButton2 = value;
                OnPropertyChanged(nameof(ContentButton2));
            }
        }
        public string ContentButton3
        {
            get
            {
                return this._contentButton3;
            }
            set
            {
                this._contentButton3 = value;
                OnPropertyChanged(nameof(ContentButton3));
            }
        }
        public string ContentButton4
        {
            get
            {
                return this._contentButton4;
            }
            set
            {
                this._contentButton4 = value;
                OnPropertyChanged(nameof(ContentButton4));
            }
        }
        public string ContentButton5
        {
            get
            {
                return this._contentButton5;
            }
            set
            {
                this._contentButton5 = value;
                OnPropertyChanged(nameof(ContentButton5));
            }
        }
        public string ContentButton6
        {
            get
            {
                return this._contentButton6;
            }
            set
            {
                this._contentButton6 = value;
                OnPropertyChanged(nameof(ContentButton6));
            }
        }
        public string ContentButton7
        {
            get
            {
                return this._contentButton7;
            }
            set
            {
                this._contentButton7 = value;
                OnPropertyChanged(nameof(ContentButton7));
            }
        }
        public string ContentButton8
        {
            get
            {
                return this._contentButton8;
            }
            set
            {
                this._contentButton8 = value;
                OnPropertyChanged(nameof(ContentButton8));
            }
        }
        public string ContentButton9
        {
            get
            {
                return this._contentButton9;
            }
            set
            {
                this._contentButton9 = value;
                OnPropertyChanged(nameof(ContentButton9));
            }
        }*/

        public void Reset()
        {
            this.CurrentPlayer = 1;
            this.PrintCurrentPlayer = this.CurrentPlayer == 1 ? "1 Ficha: X" : "2 Ficha: O ";
            this._game = new GameController();
        }

    }
}
