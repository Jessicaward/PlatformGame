using Microsoft.Xna.Framework;

namespace PlatformGame
{
    public class Level
    {
        private SquareType[,] map;
        private int pickupsRemaining;

        public SquareType[,] Map
        {
            get { return map; }
        }

        public int PickupsRemaining
        {
            get { return pickupsRemaining; }
        }

        public Level(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Smol:
                default:
                    map = new SquareType[64, 64];
                    pickupsRemaining = 6;
                    break;
                case Difficulty.Reggi:
                    map = new SquareType[256, 256];
                    pickupsRemaining = 25;
                    break;
                case Difficulty.Chonky:
                    map = new SquareType[512, 512];
                    pickupsRemaining = 50;
                    break;
            }
        }

        public SquareType GetSquareType(int x, int y) => map[x,y];

        public void Update(GameTime gameTime)
        {
            //remove coins here etc
        }
    }
}