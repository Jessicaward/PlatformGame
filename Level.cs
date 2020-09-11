using Microsoft.Xna.Framework;

namespace PlatformGame
{
    public class Level
    {
        SquareType[,] map;
        public Level(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Smol:
                default:
                    map = new SquareType[64, 64];
                    break;
                case Difficulty.Reggi:
                    map = new SquareType[256, 256];
                    break;
                case Difficulty.Chonky:
                    map = new SquareType[512, 512];
                    break;
            }
        }

        public SquareType GetSquareType(int x, int y) => map[x,y];

        public void Update(GameTime gameTime)
        {

        }
    }
}