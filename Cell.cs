using System;
using Microsoft.Xna.Framework;
namespace PlatformGame
{
    public class Cell
    {
        private SquareType type;
        private int xCoord;
        private int yCoord;
        private bool visited;

        public SquareType Type
        {
            get { return type; }
        }
        public int XCoord
        {
            get { return xCoord; }
            set { xCoord = value; }
        }
        public int YCoord
        {
            get { return yCoord; }
            set { yCoord = value; }
        }
        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        public Cell(SquareType type, int xCoord, int yCoord, bool visited)
        {
            this.type = type;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.visited = visited;
        }
    }
}
