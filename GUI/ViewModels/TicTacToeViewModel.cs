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
            bool CanPlay = _game.PlayOnceTime(Convert.ToInt32(position));
            this.GetCurrentPlayer = _getCurrentPlayer;
            return CanPlay;
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

        private string _getCurrentPlayer;
        public string GetCurrentPlayer
        {
            get
            {
                if(_game.GetIdCurrentPlayer() == 1)
                {
                    return "1 Ficha: X";
                }
                else
                {
                    return "2 Ficha: O ";
                }
            }
            set
            {
                _getCurrentPlayer = value;
                OnPropertyChanged(nameof(GetCurrentPlayer));
            }
        }

        //public void PaintView(Button sender)
        //{
        //    if (_game.GetIdCurrentPlayer() == 2)
        //    {
        //        sender.Content = "X";
        //        this.ContentButton = sender.Content.ToString();

        //    }
        //    else
        //    {

        //        sender.Content = "O";
        //        this.ContentButton = sender.Content.ToString();
        //    }
        //}


        
        //TODO - actualizar botones
        //private string _contentButton;

        //public string ContentButton
        //{
        //    get
        //    {
        //        return this._contentButton;
        //    }
        //    set
        //    {
        //        this._contentButton = value;
        //        OnPropertyChanged(nameof(ContentButton));
        //    }
        //}

        public void Reset()
        {
            //this.ContentButton = "6";
            this._game = new GameController();
        }


    }
}
