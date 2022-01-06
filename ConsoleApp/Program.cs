using Business.Models;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ganador _playerOne
            GameController game = new GameController();
            game.CheckShifts(1);
            game.CheckShifts(4);
            game.CheckShifts(2);
            game.CheckShifts(9);
            game.CheckShifts(3);
            Console.WriteLine("Game 1 = " + game.Winner.Id);

            //tablero completo
            GameController game2 = new GameController();
            game2.CheckShifts(1);
            game2.CheckShifts(2);
            game2.CheckShifts(3);
            game2.CheckShifts(4);
            game2.CheckShifts(5);
            game2.CheckShifts(7);
            game2.CheckShifts(6);
            game2.CheckShifts(9);
            game2.CheckShifts(8);
            Console.WriteLine("Game 2 = " + game2.GameOver + game2.Winner);



        }
    }
}
