using Business.Models;
using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ganador _playerOne
            //Game1();

            //////tablero completo
            //Game2();

            //TODO
            //Game3();

            Game4();

        }

        public static void Game1()
        {
            GameController game = new GameController();
            game.PlayOnceTime(1);
            game.PlayOnceTime(4);
            game.PlayOnceTime(2);
            game.PlayOnceTime(9);
            game.PlayOnceTime(3);
            //game.MainBoard.PrintBoard();
            Console.WriteLine("Game 1 = " + game.Winner.Id);
        }

        public static void Game2()
        {
            GameController game2 = new GameController();
            game2.PlayOnceTime(1);
            game2.PlayOnceTime(2);
            game2.PlayOnceTime(3);
            game2.PlayOnceTime(4);
            game2.PlayOnceTime(5);
            game2.PlayOnceTime(7);
            game2.PlayOnceTime(6);
            game2.PlayOnceTime(9);
            game2.PlayOnceTime(8);
            //game2.MainBoard.PrintBoard();

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
            game3.PlayOnceTime(1);
            game3.PlayOnceTime(1);
            //game3.PlayOnceTime(2);
            //game3.PlayOnceTime(9);
            //game3.PlayOnceTime(3);
        }

        public static void Game4()
        {
            GameController game = new GameController();
            Random rand = new Random();
            while (!game.GameOver)
            {
                int num = rand.Next(1, 9);
                //int num =Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Juagdor " + game.GetIdCurrentPlayer() + ": " + (num - 1));

                if (!game.PlayOnceTime(num))
                {
                    Console.WriteLine("Turno inavlido, vuelva a tirar");
                }
                PrintBoard(game.MainBoard.GetBoard());               

            }

            if (game.Winner == null)
            {
                Console.WriteLine("Se lleno el tablero");
            }
            else
            {
                Console.WriteLine("Gano jugador : " + game.Winner.Id);
            }
        }


        public static void PrintBoard(int[] grid)
        {
            for (int i = 0; i < 9; i += 3)
            {
                Console.WriteLine(grid[i] + " " + grid[i + 1] + " " + grid[i + 2]);
            }

        } 
    }
}

