using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Lizard_s_Hangover
{
    public class Game
    {
        private const ConsoleColor BANNER_COLOR = ConsoleColor.DarkGreen;
        private const ConsoleColor BANNER_BACKGROUND = ConsoleColor.Black;
        private const ConsoleColor MENU_COLOR = ConsoleColor.DarkGreen;
        private const ConsoleColor MENU_BACKGROUND = ConsoleColor.Black;

        public Game()
        {
            Map = new Map();
        }
        private Map Map { get; set; }

        private void PrintBanner()
        {
            Console.ForegroundColor = BANNER_COLOR;
            Console.BackgroundColor = BANNER_BACKGROUND;
            Console.WriteLine("░▒▓██████████████████████████████▓▒░");
            Console.Write("░▒▓█");
            Console.ForegroundColor = BANNER_BACKGROUND;
            Console.BackgroundColor = BANNER_COLOR;
            Console.Write(" The Lizard's Hangover v1.00");
            Console.ForegroundColor = BANNER_COLOR;
            Console.BackgroundColor = BANNER_BACKGROUND;
            Console.WriteLine("█▓▒░");
            Console.WriteLine("░▒▓██████████████████████████████▓▒░");
        }
        private void PrintMenu()
        {
            Console.ForegroundColor = MENU_COLOR;
            Console.BackgroundColor = MENU_BACKGROUND;
            Console.WriteLine("====================================");
            Console.WriteLine("====== Move: A,D,W,S Quit: Q =======");
            Console.WriteLine("====================================");
        }

        public void Play()
        {

            while (true)
            {
                Console.Clear();
                PrintBanner();
                Map.Print();
                Map.PrintDescription(Map.PlayerX , Map.PlayerY);
                PrintMenu();
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Map.Move(Direction.North);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Map.Move(Direction.South);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Map.Move(Direction.East);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Map.Move(Direction.West);
                        break;
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        PrintExitMessage();
                        return;

                }
            }

        }

        private void PrintExitMessage()
        {
            Console.WriteLine("Thanks for playing!");
        }


    }
}