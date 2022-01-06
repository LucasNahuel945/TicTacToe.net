using Business.Models;
using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ganador _playerOne
            Game1();

            ////tablero completo
            Game2();

            //TODO
            //Game3();

        }

        public static void Game1()
        {
            GameController game = new GameController();
            game.CheckPlay(1);
            game.CheckPlay(4);
            game.CheckPlay(2);
            game.CheckPlay(9);
            game.CheckPlay(3);
            PrintGrid(game._mainBoard._grid);
            Console.WriteLine("Game 1 = " + game.Winner.Id);
        }

        public static void Game2()
        {
            GameController game2 = new GameController();
            game2.CheckPlay(1);
            game2.CheckPlay(2);
            game2.CheckPlay(3);
            game2.CheckPlay(4);
            game2.CheckPlay(5);
            game2.CheckPlay(7);
            game2.CheckPlay(6);
            game2.CheckPlay(9);
            game2.CheckPlay(8);
            PrintGrid(game2._mainBoard._grid);

            if (game2.Winner == null)
            {
                Console.WriteLine("Game 2 = " + game2.GameOver);
            }
            else
            {
                Console.WriteLine("Game 2 = " + game2.GameOver + game2.Winner.Id);
            }

        }

        public static void Game3()
        {
            GameController game3 = new GameController();
            game3.CheckPlay(1);
            game3.CheckPlay(1);
            //game3.CheckPlay(2);
            //game3.CheckPlay(9);
            //game3.CheckPlay(3);
        }

        public static void PrintGrid(int[] grid)
        {

            for (int i = 0; i < 9; i += 3)
            {
                Console.WriteLine(grid[i] +" "+ grid[i + 1] +" "+ grid[i + 2]);
            }

        }





    }
}

