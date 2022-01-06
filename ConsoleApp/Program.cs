using Business.Models;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            game.Play(1);
            game.Play(4);
            game.Play(2);
            game.Play(9);
            game.Play(3);
           
        }
    }
}
