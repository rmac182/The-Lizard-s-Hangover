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
        private readonly int WindowWidth = 45;
        private readonly int WindowHeight = 30;

        public Game()
        {
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Map = new Map();
            Player = new Player
            {
                //Set player starting position
                PlayerX = 5,
                PlayerY = 10
            };
            // an array of all the items in the game. if the InPossession is true, the item is added to the 
            // players inventory. if the map is true the map is printed. having the torch will print the 
            // map only in the areas adjacent to player(not done yet).
            GameItems = new Item[6] ;
            GameItems[0] = new Sword("sword " , true );
            GameItems[1] = new Potion(" potion", false);
            GameItems[2] = new MapItem(" map  ",  false);
            GameItems[3] = new GemStone("gem stone", false);
            GameItems[4] = new Potion(" potion", false);
            GameItems[5] = new Torch(" torch", false);
        }

        private Map Map { get; set; }
        private Player Player { get; set; }
        public Item[] GameItems { get; set; }
        

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
        private void PrintInventory()
        {
            Console.ForegroundColor = MENU_COLOR;
            Console.BackgroundColor = MENU_BACKGROUND;
            Console.WriteLine("==============INVENTORY=============");
            Console.Write("=====");
            for (int i = 0; i < GameItems.Length; i++)
            {
                
                if (i < 2) {
                    if (GameItems[i].InPossession == true)
                    {
                        Console.Write("| " + GameItems[i].ItemName +"|");
                    }
                    else
                    {
                        Console.Write("| EMPTY |");
                    }
                }
                else if(i == 2)
                {
                    if (GameItems[i].InPossession == true)
                    {
                        Console.WriteLine("| " + GameItems[i].ItemName + "|====");
                        Console.Write("=====");
                    }
                    else
                    {
                        Console.WriteLine("| EMPTY |====");
                        Console.Write("=====");
                    }
                    
                }
                else if(i > 2 &&  i < 5)
                {
                    if (GameItems[i].InPossession == true)
                    {
                        Console.Write("| " + GameItems[i].ItemName + "|");
                    }
                    else
                    {
                        Console.Write("| EMPTY |");
                    }
                }
                else if (i == 5)
                {
                    
                    if (GameItems[i].InPossession == true)
                    {
                        Console.Write("| " + GameItems[i].ItemName + "|====");
                        
                    }
                    else
                    {
                        Console.Write("| EMPTY |====");
                        
                    }
                }




            }
            Console.Write("\n");
            Console.WriteLine("====================================");
            Console.WriteLine("====================================");


        }

        public void Play()
        {

            while (true)
            {
                Console.Clear();
                PrintBanner();
                Map.Print(Player , GameItems[2]);
                // for testing prints player x and y position on map above description
                Console.WriteLine("X pos: " + Player.PlayerX + " Y pos: " + Player.PlayerY);
                Map.PrintDescription(Player);
                // Clunky as hell but demonstrates how the map "works". cant access PickupMap(); 
                // from the MapItem class for some reason. from the start. go N,W,W,N to find the map.
                if (Player.PlayerX == 3 && Player.PlayerY == 8)
                {
                    GameItems[2].InPossession = true;
                    Console.Clear();
                    PrintBanner();
                    Map.Print(Player, GameItems[2]);
                    Map.PrintDescription(Player);
                    Console.WriteLine("you found a map!");
                }
                PrintMenu();
                PrintInventory();
                
                

                
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Map.Move(Direction.North , Player);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Map.Move(Direction.South , Player);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Map.Move(Direction.East , Player);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Map.Move(Direction.West , Player);
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