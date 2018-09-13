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
            //Set player starting position
            PlayerX = 5;
            PlayerY = 10;

        }

        //Short form properties with private setters, in other words read-only outside the class
        public int PlayerX { get; private set; }
        public int PlayerY { get; private set; }

        //Read-only properties to get the width and height of the map
        public int Width
        {
            get { return _mapGrid.GetLength(0); }
        }

        public int Height
        {
            get { return _mapGrid.GetLength(1); }
        }

        public bool Move(Direction direction)
        {
            int newX = PlayerX;
            int newY = PlayerY;

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

            PlayerX = newX;
            PlayerY = newY;
            return true;
        }

        public void Print()
        {


            Console.ForegroundColor = MAP_COLOR;
            Console.BackgroundColor = MAP_BACKGROUND;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var currentTile = _mapGrid[y, x];
                    if (x == PlayerX && y == PlayerY)
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
        public void PrintDescription( int x , int y)
        {
            Console.WriteLine(_mapGrid[x , y].TileDescription);
        }

    }


}