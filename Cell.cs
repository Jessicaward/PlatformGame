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
        }

        public int YCoord
        {
            get { return yCoord; }
        }

        public Cell()
        {

        }
    }
}