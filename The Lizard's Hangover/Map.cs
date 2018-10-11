using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Lizard_s_Hangover
{
    public enum Direction
    {
        North,
        South,
        East,
        West
    }
    public class Map
    {

        public Tile[,] _mapGrid;
        private const ConsoleColor NO_MAP_COLOR = ConsoleColor.DarkGray;
        private const ConsoleColor MAP_COLOR = ConsoleColor.DarkGreen;
        private const ConsoleColor PLAYER_COLOR = ConsoleColor.White;
        private const ConsoleColor MAP_BACKGROUND = ConsoleColor.Black;

        public Map()
        {
            //create player
            Player player = new Player();
            //generate the default map
            _mapGrid = new Tile[,]
            {  
                {new Tile(  "0 0" , false , false),new Tile(  "0 1" , false  , false),new Tile(  "0 2" , false  , false),new Tile(  "0 3" , false  , false),new Tile(  "0 4" , false  , false),new Tile(  "0 5" , false  , false),new Tile(  "0 6" , false  , false),new Tile(  "0 7" , false  , false),new Tile(  "0 8" , false  , false),new Tile(  "0 9" , false  , false),new Tile( "0 10" , false  , false),new Tile( "0 11" , false  , false) },
                {new Tile(  "1 0" , false , false),new Tile(  "1 1" , false  , false),new Tile(  "1 2" , false  , false),new Tile(  "1 3" , true   , true ),new Tile(  "1 4" , false  , false),new Tile(  "1 5" , false  , false),new Tile(  "1 6" , false  , true ),new Tile(  "1 7" , false  , true ),new Tile(  "1 8" , false  , true ),new Tile(  "1 9" , false  , false),new Tile( "1 10" , false  , false),new Tile( "1 11" , false  , false) },
                {new Tile(  "2 0" , false , false),new Tile(  "2 1" , false  , true ),new Tile(  "2 2" , false  , false),new Tile(  "2 3" , false  , false),new Tile(  "2 4" , false  , true ),new Tile(  "2 5" , false  , false),new Tile(  "2 6" , true   , true ),new Tile(  "2 7" , false  , false),new Tile(  "2 8" , false  , true ),new Tile(  "2 9" , false  , false),new Tile( "2 10" , false  , false),new Tile( "2 11" , false  , false) },
                {new Tile(  "3 0" , false , false),new Tile(  "3 1" , false  , true ),new Tile(  "3 2" , false  , true ),new Tile(  "3 3" , false  , true ),new Tile(  "3 4" , false  , true ),new Tile(  "3 5" , false  , true ),new Tile(  "3 6" , false  , true ),new Tile(  "3 7" , false  , false),new Tile(  "3 8" , true   , true ),new Tile(  "3 9" , false  , false),new Tile( "3 10" , false  , false),new Tile( "3 11" , false  , false) },
                {new Tile(  "4 0" , false , false),new Tile(  "4 1" , false  , false),new Tile(  "4 2" , true   , false),new Tile(  "4 3" , false  , false),new Tile(  "4 4" , false  , false),new Tile(  "4 5" , false  , false),new Tile(  "4 6" , false  , false),new Tile(  "4 7" , false  , false),new Tile(  "4 8" , false  , true ),new Tile(  "4 9" , false  , false),new Tile( "4 10" , false  , false),new Tile( "4 11" , false  , false) },
                {new Tile(  "5 0" , false , false),new Tile(  "5 1" , false  , false),new Tile(  "5 2" , false  , false),new Tile(  "5 3" , false  , false),new Tile(  "5 4" , false  , false),new Tile(  "5 5" , true   , true ),new Tile(  "5 6" , false  , true ),new Tile(  "5 7" , false  , true ),new Tile(  "5 8" , false  , true ),new Tile(  "5 9" , false  , false),new Tile( "5 10" , false  , false),new Tile( "5 11" , false  , false) },
                {new Tile(  "6 0" , false , false),new Tile(  "6 1" , false  , true ),new Tile(  "6 2" , false  , true ),new Tile(  "6 3" , false  , false),new Tile(  "6 4" , false  , false),new Tile(  "6 5" , false  , true ),new Tile(  "6 6" , false  , false),new Tile(  "6 7" , false  , false),new Tile(  "6 8" , false  , true ),new Tile(  "6 9" , false  , false),new Tile( "6 10" , true   , false),new Tile( "6 11" , false  , false) },
                {new Tile(  "7 0" , false , false),new Tile(  "7 1" , false  , true ),new Tile(  "7 2" , false  , false),new Tile(  "7 3" , false  , false),new Tile(  "7 4" , false  , false),new Tile(  "7 5" , false  , true ),new Tile(  "7 6" , false  , false),new Tile(  "7 7" , false  , false),new Tile(  "7 8" , false  , false),new Tile(  "7 9" , false  , false),new Tile( "7 10" , false  , false),new Tile( "7 11" , false  , false) },
                {new Tile(  "8 0" , false , false),new Tile(  "8 1" , false  , true ),new Tile(  "8 2" , false  , false),new Tile(  "8 3" , false  , true ),new Tile(  "8 4" , false  , false),new Tile(  "8 5" , false  , true ),new Tile(  "8 6" , true   , false),new Tile(  "8 7" , false  , false),new Tile(  "8 8" , false  , false),new Tile(  "8 9" , false  , false),new Tile( "8 10" , false  , false),new Tile( "8 11" , false  , false) },
                {new Tile(  "9 0" , false , false),new Tile(  "9 1" , false  , true ),new Tile(  "9 2" , false  , true ),new Tile(  "9 3" , false  , true ),new Tile(  "9 4" , false  , true ),new Tile(  "9 5" , false  , true ),new Tile(  "9 6" , false  , false),new Tile(  "9 7" , false  , false),new Tile(  "9 8" , false  , false),new Tile(  "9 9" , false  , false),new Tile( "9 10" , false  , false),new Tile( "9 11" , false  , false) },
                {new Tile( "10 0" , false , false),new Tile( "10 1" , false  , false),new Tile( "10 2" , false  , false),new Tile( "10 3" , false  , false),new Tile( "10 4" , false  , false),new Tile( "10 5" , false  , true ),new Tile( "10 6" , false  , true ),new Tile( "10 7" , false  , false),new Tile( "10 8" , false  , false),new Tile( "10 9" , false  , false),new Tile("10 10" , false  , false),new Tile("10 11" , false  , false) },
                {new Tile( "11 0" , false , false),new Tile( "11 1" , false  , false),new Tile( "11 2" , false  , false),new Tile( "11 3" , false  , false),new Tile( "11 4" , false  , false),new Tile( "11 5" , false  , false),new Tile( "11 6" , false  , false),new Tile( "11 7" , false  , false),new Tile( "11 8" , false  , false),new Tile( "11 9" , false  , false),new Tile("11 10" , false  , false),new Tile("11 11" , false  , false) }
           };


            //set descriptions for accessible tiles as well as setting ContainsItem as true if needed.

            _mapGrid[5, 10].TileDescription = "An interesting aroma and strange glow \nto the east. To the north, a narrow, \ncovered trail.";
            _mapGrid[6, 10].TileDescription = "There is a fairy here. she smiles, \nand offers you a potion.";
            _mapGrid[5, 9].TileDescription = "A long trail before you to the north.\n or go west, seriously dude. Go west.";
            _mapGrid[5, 8].TileDescription = "A long trail before you.";
            _mapGrid[5, 7].TileDescription = "The trail continues. \nA dim glow in the distance.";
            _mapGrid[5, 6].TileDescription = "Nothing natural about the glow. \nIts brighter now. what the\nhell is that?";
            _mapGrid[5, 5].TileDescription = "Its a bright, rectangular light \nfloating in mid-air! Its like a \ndoor. You are afraid, and yet, \nyou feel a great urge to approach \nand enter!";
            _mapGrid[3, 1].TileDescription = "You wake up on the ground. \nYou do not remember much. \nYou look around. No doors. No way out. \nOne of the walls has a strange hole.\n" +
                "How did you get here? How do you \nget out?! There is no way out! \nYou starve to death and die.";
            _mapGrid[3, 8].TileDescription = "A dead end. Looks like there is \nnowhere to go. You are worried you\nare lost. Then you see something";
            _mapGrid[3, 9].TileDescription = "Here there are creepy statues among \nthe trees in the dark. You feel \nvery uneasy";
            _mapGrid[2, 6].TileDescription = "You see a stone pedastal. On it is a \nglowing green stone. No idea \nwhat it is, but it looks valuable.";
            _mapGrid[8, 6].TileDescription = "The shack is nothing but one dusty \nsmelly room. Nothing but a table \nOn the table is some kind of map.";
            _mapGrid[8, 5].TileDescription = "The path continues to the north. \nTo the south, is an old shack.";
            _mapGrid[4 ,2].TileDescription = "There is a fairy here. she \nsmiles, and offers you a \npotion."; ;
            _mapGrid[4, 3].TileDescription = "An interesting aroma and strange \nglow to the north. east and west, \nmore trail.";
            _mapGrid[1, 3].TileDescription = "There is a ferocious Dragon.\nHe is between you and great treasure! \nThis is it! This is why you are \nhere!";
            _mapGrid[1, 2].TileDescription = "There is an insane Fortune! \nTotally worth almost dying for!\nYou take all of it!\nPress a key to continue.";
        }



        //Read-only properties to get the width and height of the map
        public int Width
        {
            get { return _mapGrid.GetLength(0); }
        }

        public int Height
        {
            get { return _mapGrid.GetLength(1); }
        }

        public bool Move(Direction direction, Player _player)
        {
            int newX = _player.PlayerX;
            int newY = _player.PlayerY;

            switch (direction)
            {
                case Direction.North:
                    newY--;
                    break;
                case Direction.South:
                    newY++;
                    break;
                case Direction.East:
                    newX++;
                    break;
                case Direction.West:
                    newX--;
                    break;
                default:
                    return false;
            }

            if (newX < 0 || newY < 0 || newX >= Width || newY >= Height || _mapGrid[newY, newX].IsAccessible == false)
                return false;

            _player.PlayerX = newX;
            _player.PlayerY = newY;
            return true;
        }

        public void Print(Player _player, Item _itemMap , Item _itemTorch)
        {
            Console.ForegroundColor = MAP_COLOR;
            Console.BackgroundColor = MAP_BACKGROUND;

            if (_itemMap.InPossession == true)
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        var currentTile = _mapGrid[y, x];
                        if (x == _player.PlayerX && y == _player.PlayerY)
                        {
                            Console.ForegroundColor = PLAYER_COLOR;
                            Console.Write(" O ");
                            Console.ForegroundColor = MAP_COLOR;
                        }
                        else if (currentTile.IsAccessible)
                        {
                            Console.Write("   ");

                        }
                        else
                        {

                            Console.Write("▒▒▒");
                        }
                    }

                    Console.WriteLine();

                }
            }
            else if (_itemMap.InPossession == false && _itemTorch.InPossession == true)
            {
                // setting up variables for tiles surrounding the player to be lit by torch
                // if torch is in inventory and the map is not.

                var currentTileN = _mapGrid[_player.PlayerY - 1, _player.PlayerX];
                var currentTileNE = _mapGrid[_player.PlayerY - 1, _player.PlayerX + 1];
                var currentTileE = _mapGrid[_player.PlayerY, _player.PlayerX + 1];
                var currentTileSE = _mapGrid[_player.PlayerY + 1, _player.PlayerX + 1];
                var currentTileS = _mapGrid[_player.PlayerY + 1, _player.PlayerX];
                var currentTileSW = _mapGrid[_player.PlayerY + 1, _player.PlayerX - 1];
                var currentTileW = _mapGrid[_player.PlayerY, _player.PlayerX - 1];
                var currentTileNW = _mapGrid[_player.PlayerY - 1, _player.PlayerX - 1];

                currentTileN.TorchLit = true;
                currentTileNE.TorchLit = true;
                currentTileE.TorchLit = true;
                currentTileSE.TorchLit = true;
                currentTileS.TorchLit = true;
                currentTileSW.TorchLit = true;
                currentTileW.TorchLit = true;
                currentTileNW.TorchLit = true;


                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {

                        var currentTile = _mapGrid[y, x];

                        if (x == _player.PlayerX && y == _player.PlayerY)
                        {
                            Console.ForegroundColor = PLAYER_COLOR;
                            Console.Write(" O ");
                            Console.ForegroundColor = NO_MAP_COLOR;
                        }
                        else
                        {
                            if (currentTile.TorchLit == true)
                            {

                                if (currentTile.IsAccessible == true)
                                {
                                    Console.Write("   ");
                                    currentTile.TorchLit = false;
                                }
                                else
                                {
                                    Console.ForegroundColor = MAP_COLOR;
                                    Console.Write("▒▒▒");
                                    currentTile.TorchLit = false;
                                }

                            }
                            else
                            {
                                if (currentTile.TorchLit == false)
                                {
                                    Console.ForegroundColor = NO_MAP_COLOR;
                                    Console.Write("▒▒▒");
                                }
                            }

                        }
                    }

                    Console.WriteLine();
                }

            }
            else if (_itemMap.InPossession == false && _itemTorch.InPossession == false)
            {
                for(int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        var currentTile = _mapGrid[y, x];
                        if (x == _player.PlayerX && y == _player.PlayerY)
                        {
                            Console.ForegroundColor = PLAYER_COLOR;
                            Console.Write(" O ");
                            Console.ForegroundColor = NO_MAP_COLOR;

                        }
                        else
                        {
                            Console.ForegroundColor = NO_MAP_COLOR;
                            Console.Write("▒▒▒");
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.ForegroundColor = MAP_COLOR;
        }

       


        public void PrintDescription( Player _player  , Item[] _gameItems , Game _game)
        {
            Console.ForegroundColor = MAP_COLOR;
            Console.WriteLine(_mapGrid[_player.PlayerX , _player.PlayerY].TileDescription);


            //Gives player the option to take the potion (potion1) offered by the fairy. depending on the player's 
            //action, it adds potion to inventory and changes tile descriptions accordingly. if potion is not taken 
            //fairy laughs and vanishes no way to get this potion after that.
            if (_player.PlayerY == 10 && _player.PlayerX == 6 && _mapGrid[6 , 10].ContainsItem == true)
            {
                string choice;
                
                Console.WriteLine("Take the Potion? Y or N");
                _game.PrintInventory();
                _game.PrintMenu();
                choice = Console.ReadLine().ToLower();
                
                switch (choice)
                {
                    case "y":
                        _gameItems[1].InPossession = true;
                        _mapGrid[6, 10].ContainsItem = false;
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("As you take the potion, the cavern \nglows brightly, then dims to \ndarkness. the fairy is now gone.");
                        _mapGrid[6 , 10].TileDescription = "A dark, moist cavern.";
                        _mapGrid[5, 10].TileDescription = "Cold and dark to the east. To the \nnorth, a narrow, covered trail.";
                        _mapGrid[4, 2].TileDescription = "There is like a fairy here. she \nsmiles, and offers you a \npotion."; ;

                        break;

                    case "n":
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        _mapGrid[6, 10].ContainsItem = false;
                        Console.WriteLine("You are not about to drink anything \nthis strange, sleazy creature wants \nto give you. She laughs at you \nand vanishes. ");
                        _mapGrid[6, 10].TileDescription = "A dark, moist cavern.";
                        _mapGrid[5, 10].TileDescription = "Cold and dark to the east. To the \nnorth, a narrow, covered trail.";
                        _mapGrid[4, 2].TileDescription = "Its the fairy again. she \nrolls her eyes, and offers you a \npotion."; ;

                        break;
                    default:

                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("This answer is invalid.");
                        Console.WriteLine("Press a key to continue.");
                            
                        break;


                    

                }
                
                
                    
                        

            }
            //Gives player the option to take the torch found on tile [8,3]. depending on the player's 
            //action, it adds torch to inventory and changes tile descriptions accordingly.
            if (_player.PlayerY == 8 && _player.PlayerX == 3 && _mapGrid[3, 8].ContainsItem == true)
            {
                string choice;

                Console.WriteLine("Take the Torch? Y or N");
                _game.PrintInventory();
                _game.PrintMenu();
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "y":
                        _gameItems[5].InPossession = true;
                        _mapGrid[3, 8].ContainsItem = false;
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("You grab the torch. This will come \nin handy. A much clearer \nview of your immediate surroundings.");
                        _mapGrid[3, 8].TileDescription = "Nothing left of interest here.\nYou got a torch,man. Be grateful.";
                        _mapGrid[3, 9].TileDescription = "The trees and the statues aren't \nquite as scary as they were a moment \nago in the dark.";

                        break;

                    case "n":
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        
                        Console.WriteLine("You leave the torch in place. \nSome would question this decision. \nPerhaps, you are a moron.");
                        
                        break;

                    default:

                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("This answer is invalid.");
                        Console.WriteLine("Press a key to continue.");

                        break;




                }





            }
            //Gives the player the option to grab a stone. this stone will be used to exit the vortex if entered
            //if you enter the vortex without the stone you are trapped and starve to death.
            if (_player.PlayerY == 6 && _player.PlayerX == 2 && _mapGrid[2, 6].ContainsItem == true)
            {
                string choice;

                Console.WriteLine("Take the Stone? Y or N");
                _game.PrintInventory();
                _game.PrintMenu();
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "y":
                        _gameItems[3].InPossession = true;
                        _mapGrid[2, 6].ContainsItem = false;
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("You grab the stone. A Treasure! \nWho Knows what its Worth?!.");
                        _mapGrid[2, 6].TileDescription = "Nothing left of interest here.";

                        break;

                    case "n":
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);

                        Console.WriteLine("You leave the stone in place. \nYa coulda been rich!!");

                        break;

                    default:

                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("This answer is invalid.");
                        Console.WriteLine("Press a key to continue.");

                        break;




                }





            }

            //gives the player the option to grab the map. the map allows the player to see the entire map.

            if (_player.PlayerY == 6 && _player.PlayerX == 8 && _mapGrid[8, 6].ContainsItem == true)
            {
                string choice;

                Console.WriteLine("Take the map? Y or N");
                _game.PrintInventory();
                _game.PrintMenu();
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "y":
                        _gameItems[2].InPossession = true;
                        _mapGrid[8, 6].ContainsItem = false;
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("You grab the map.");
                        _mapGrid[8, 6].TileDescription = "An empty, old shack. \nNothing left of interest here.";

                        break;

                    case "n":
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);

                        Console.WriteLine("You leave the map.");

                        break;

                    default:

                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("This answer is invalid.");
                        Console.WriteLine("Press a key to continue.");

                        break;




                }





            }
            // another chance to get a potion(potion2) from a fairy. If you get to the dragon at the end
            // without a potion you cant fight and win.
            if (_player.PlayerY == 2 && _player.PlayerX == 4 && _mapGrid[4, 2].ContainsItem == true)
            {
                string choice;

                Console.WriteLine("Take the potion? Y or N");
                _game.PrintInventory();
                _game.PrintMenu();
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "y":
                        _gameItems[4].InPossession = true;
                        _mapGrid[4, 2].ContainsItem = false;
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("You take the potion. You cant have \ntoo much potion.The Fairy smiles at \nyou and disappears");
                        _mapGrid[4, 2].TileDescription = "A dark, moist cavern.";
                        _mapGrid[4, 3].TileDescription = "Cold and dark to the north. To the \nwest, more trail.";

                        break;

                    case "n":
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        _mapGrid[4, 2].ContainsItem = false;
                        if (_gameItems[1].InPossession == false)
                        {
                            Console.WriteLine("You are having a hard time trusting \nthis fairy. This time, her feelings \nseem hurt. She vanishes, crying. ");
                            _mapGrid[4, 2].TileDescription = "A dark, moist cavern.";
                            _mapGrid[4, 3].TileDescription = "Cold and dark to the north. To \nthe west, more trail.";
                        }else if(_gameItems[1].InPossession == true)
                        {
                            Console.WriteLine("'No thanks.' you say. 'I have \nenough potion.' The Fairy \nsmiles at you and disappears.");
                            _mapGrid[4, 2].TileDescription = "A dark, moist cavern.";
                            _mapGrid[4, 3].TileDescription = "Cold and dark to the north. To \nthe west, more trail.";
                        }
                            break;

                    default:

                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("This answer is invalid.");
                        Console.WriteLine("Press a key to continue.");

                        break;




                }





            }

            //uses the _mapGrid[5,5].containsItem switch to for a vortex. if you do not have the gemstone, 
            // and enter the vortex, you will be stuck in _mapGrid[1, 3] and starve to death.Game Over. 
            if (_player.PlayerY == 5 && _player.PlayerX == 5 && _mapGrid[5, 5].ContainsItem == true)
            {
                string choice;

                Console.WriteLine("Enter the glowing light? Y or N");
                _game.PrintInventory();
                _game.PrintMenu();
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "y":
                        
                        _mapGrid[5, 5].ContainsItem = false;
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("You step into the doorway....\nPress a key to continue.");
                        _mapGrid[5, 5].TileDescription = "You are back to where the strange\ndoor was. Now, only dark, wooded \narea. Nothing else of interest\nhere.";
                        _mapGrid[5, 6].TileDescription = "Cold and dark trail to the north.";
                        _mapGrid[5, 7].TileDescription = "Cold and dark trail to the north.";
                        _mapGrid[5, 8].TileDescription = "Cold and dark trail to the north.";
                        _player.PlayerX = 3;
                        _player.PlayerY = 1;


                        if (_gameItems[3].InPossession == false)
                        {
                            Console.Clear();
                            _game.PrintBanner();
                            Print(_player, _gameItems[2], _gameItems[5]);
                            Console.WriteLine(_mapGrid[_player.PlayerX, _player.PlayerY].TileDescription);
                            _game.PrintMenu();
                            _game.PrintInventory();
                            Console.ReadKey();
                            _player.Alive = false;

                        }
                        else
                        {
                            _mapGrid[3, 1].TileDescription = "You wake up on the ground. \nYou do not remember much. \nYou look around. No doors. No way out. \nOne of the walls has a strange hole.\n" +
                                "Its shaped exactly like the \ngemstone that you found!";
                
                            Console.Clear();
                            _game.PrintBanner();
                            Print(_player, _gameItems[2], _gameItems[5]);
                            Console.WriteLine(_mapGrid[_player.PlayerX, _player.PlayerY].TileDescription);
                            Console.WriteLine("Press a key to place the stone\nInto the hole.");
                            _game.PrintInventory();
                            _game.PrintMenu();
                            _player.PlayerX = 5;
                            _player.PlayerY = 5;
                            _gameItems[3].InPossession = false;
                            Console.ReadLine();
                            Console.Clear();
                            _game.PrintBanner();
                            Print(_player, _gameItems[2], _gameItems[5]);
                            PrintDescription(_player , _gameItems , _game);

                        }
                        break;
                        
                            


                    case "n":
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("You resist the temptation \nof the glowing vortex... \nfor now. Continue East or\nback South?");
                        
                        
                        break;

                    default:

                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("This answer is invalid.");
                        Console.WriteLine("Press a key to continue.");

                        break;




                }





            }
            //The dragon is here. kill the dragon, win the game. if you have a potion you will win.  
            //No potion, you die. Game Over.if you never met the fairy you die slow and painfully. if you
            //met her and turned down potion, you die remembering the fairy. and feeling stupid. lol
            if (_player.PlayerY == 3 && _player.PlayerX == 1 && _mapGrid[1, 3].ContainsItem == true)
            {
                string choice;

                Console.WriteLine("Fight the Dragon? (F)ight or (R)un");
                _game.PrintInventory();
                _game.PrintMenu();
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {

                    case "f":

                        if (_gameItems[1].InPossession == true || _gameItems[4].InPossession == true)
                        {
                            _mapGrid[1, 3].ContainsItem = false;
                            Console.Clear();
                            _game.PrintBanner();
                            Print(_player, _gameItems[2], _gameItems[5]);
                            Console.WriteLine("You draw your sword and ATTACK!\nHe thrashes You to near dead\nwith ease. You remember your potion. \nTime to trust the fairy. \nYou Chug it.. and feel amazing \nlife and energy course through\nyour veins and just in time!");
                            _mapGrid[1, 3].TileDescription = "There is a dead dragon. Nothing else\nof interest.";
                        }
                        else if (_gameItems[1].InPossession == false && _gameItems[4].InPossession == false)
                        {
                            if (_mapGrid[4, 2].ContainsItem == false && _mapGrid[6,10].ContainsItem == false)
                            {
                                Console.Clear();
                                _game.PrintBanner();
                                Print(_player, _gameItems[2], _gameItems[5]);
                                Console.WriteLine("You draw your sword and ATTACK!\nHe thrashes You to a bloody death\nwith ease. You remember the fairy. \nMaybe she was just trying to help.\nYou Moron! Press a Key.");
                                _game.PrintMenu();
                                _game.PrintInventory();
                                Console.ReadLine();
                                _player.Alive = false;
                            }
                            else
                            {
                                Console.Clear();
                                _game.PrintBanner();
                                Print(_player, _gameItems[2], _gameItems[5]);
                                Console.WriteLine("You draw your sword and ATTACK!\nHe thrashes You to a bloody death\nwith ease. \nYou die slowly and painfully! \nPress a Key.");
                                _game.PrintMenu();
                                _game.PrintInventory();
                                Console.ReadLine();
                                _player.Alive = false;
                            }

                        }
                        break;

                    case "r":
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("You Run like a coward! \nPress a key, you Wimp!");
                        _player.PlayerX = 2;
                        _player.PlayerY = 3;
                        
                        break;

                    default:

                        Console.Clear();
                        _game.PrintBanner();
                        Print(_player, _gameItems[2], _gameItems[5]);
                        Console.WriteLine("This answer is invalid.");
                        Console.WriteLine("Press a key to continue.");

                        break;




                }


               


            }
            if(_player.PlayerX == 1 && _player.PlayerY == 2)
            {
                _game.PrintMenu();
                _game.PrintInventory();
                Console.ReadKey();
                _player.Wins = true;
                
            }

        }

    }


}






                                
                       
                        
                       
                        

                                

                                