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
        private readonly int WindowWidth = 40;
        private readonly int WindowHeight = 40;

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
            // map only in the areas adjacent to player.
            // cant get the mechanics of giving the choice of picking items up when found and setting
            // the item to true so it shows in the inventory. 
            GameItems = new Item[6];
            Item sword = new Item("sword " , true );
            Item potion1 = new Item("potion", false);
            Item map = new Item(" map  ",  false); 
            Item gemStone = new Item("stone ", false);
            Item potion2 = new Item("potion", false);
            Item torch  = new Item("torch ", false);
            

            GameItems[0] = sword;
            GameItems[1] = potion1;
            GameItems[2] = map;
            GameItems[3] = gemStone;
            GameItems[4] = potion2;
            GameItems[5] = torch;


        }

        private Map Map { get; set; }
        private Player Player { get; set; }
        public Item[] GameItems { get; set; }
        

        public void PrintBanner()
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
       
        public void PrintMenu()
        {
            Console.ForegroundColor = MENU_COLOR;
            Console.BackgroundColor = MENU_BACKGROUND;
            Console.WriteLine("====================================");
            Console.WriteLine("====== Move: A,D,W,S Quit: Q =======");
            Console.WriteLine("====================================");
        }
        public void PrintInventory()
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
                Map.Print(Player , GameItems[2] , GameItems[5]);
                // for testing prints player x and y position on map above description
                Console.WriteLine(Map._mapGrid[Player.PlayerX , Player.PlayerY].TileName);
                
                Map.PrintDescription(Player , GameItems , this);
                if (Player.Alive)
                {
                    PrintMenu();
                    PrintInventory();
                }
                else
                {
                    PrintDeadMessage();
                    Console.ReadLine();
                    PrintExitMessage();
                }
                if (Player.Alive && Player.Wins)
                {
                    
                    PrintWinMessage();
                   
                    
                }
               



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
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("==================================");
            Console.WriteLine("=======Thanks for playing!========");
            Console.WriteLine("==================================");
            Console.WriteLine("==================================");

            Console.ReadLine();

        }

        public void PrintDeadMessage()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("====================================");
            Console.WriteLine("===========Your Are Dead!===========");
            Console.WriteLine("=============GAME OVER==============");
            Console.WriteLine("====================================");
            Console.WriteLine("====================================");
            Console.WriteLine("====================================");
            Console.WriteLine("========Thanks for playing!=========");
            Console.WriteLine("====================================");
            Console.WriteLine("====================================");

            Console.ReadLine();



        }

        public void PrintWinMessage()
        {
            Console.Clear();
            Console.WriteLine("==========CONGRATULATIONS!==========");
            Console.WriteLine("===                              ===");
            Console.WriteLine("= You win because you are totally  =");
            Console.WriteLine("===        Rich and Stuff!       ===");
            Console.WriteLine("===          GAME OVER           ===");
            Console.WriteLine("===                              ===");
            Console.WriteLine("===     Thanks for playing!      ===");
            Console.WriteLine("===                              ===");
            Console.WriteLine("====================================");

            Console.ReadLine();



        }

    }
}
            
            