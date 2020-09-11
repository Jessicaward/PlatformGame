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

        public SquareType type()
        {
            get { return type; }
        }
        public int xCoord()
        {

        }

        public Cell()
        {

        }
    }
}
