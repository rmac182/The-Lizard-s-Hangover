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
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) }
           };


            //set descriptions for accessible tiles

            _mapGrid[5, 10].TileDescription = "An interesting aroma and strange glow\n" +
                "to the east. To the north, a narrow, \ncovered trail.";
            _mapGrid[6, 10].TileDescription = "There is like a fairy here. she's \nlike, kinda hot, and offers you a \npotion.";
            _mapGrid[5, 9].TileDescription = "A long trail before you to the north.\n or go west, seriously dude. Go west.";
            _mapGrid[5, 8].TileDescription = "A long trail before you.";
            _mapGrid[5, 7].TileDescription = "A long trail before you.";
            _mapGrid[5, 6].TileDescription = "A long trail before you.";
            _mapGrid[3,8].TileDescription = "A dead end. Looks like there is \nnowhere to go. You are worried you\nare lost. Then you see something";

            _mapGrid[3, 8].ContainsItem = true;
           
           

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

       


        public void PrintDescription( Player _player )
        {
            Console.ForegroundColor = MAP_COLOR;
            Console.WriteLine(_mapGrid[_player.PlayerX , _player.PlayerY].TileDescription);

        }

    }


}
                                
                                

                                