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

        private Tile[,] _mapGrid;
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
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(false),new Tile(true ),new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(true ),new Tile(true ),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) },
                {new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false),new Tile(false) }
           };
        
            
            //set descriptions for accessible tiles
            _mapGrid[6, 10].TileDescription = "There is like a fairy here. she's \nlike, kinda hot, and offers you a potion.";
            _mapGrid[5, 9].TileDescription = "A long trail before you to the north.\n or go west, seriously dude. Go west.";
            _mapGrid[5, 8].TileDescription = "A long trail before you, walk! numbNuts!!!";
            _mapGrid[5, 7].TileDescription = "A long trail before you, walk! numbNuts!!!";
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

        public bool Move(Direction direction , Player _player)
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

        public void Print(Player _player)
        {


            Console.ForegroundColor = MAP_COLOR;
            Console.BackgroundColor = MAP_BACKGROUND;
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
        public void PrintDescription( Player _player)
        {
            Console.WriteLine(_mapGrid[_player.PlayerX , _player.PlayerY].TileDescription);

        }

    }


}