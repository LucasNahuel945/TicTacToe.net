using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.ViewModels
{
    public class TicTacToeViewModel
    {

        public GameController _game;

        public TicTacToeViewModel()
        {
            this._game = new GameController();
        }

        public bool Game(int position)
        {
            return _game.PlayOnceTime(Convert.ToInt32(position));                                   
        }

        public string MessageStatusGame()
        {
            string status = "";
            if (_game.Winner != null)
            {
                status = "Ganador del juego : " + _game.Winner.Id;
            }
            else
            {
                status = "Empate!";
            }
            return status;
        }

        //TODO - metodo GameOver

    }
}
