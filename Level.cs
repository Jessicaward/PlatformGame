using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PlatformGame
{
    public class Level
    {
        private SquareType[,] map;
        private int pickupsRemaining;
        Texture2D wallTexture;
        Texture2D floorTexture;

        public SquareType[,] Map
        {
            get { return map; }
        }

        public int PickupsRemaining
        {
            get { return pickupsRemaining; }
        }

        public Texture2D WallTexture
        {
            get { return wallTexture; }
            set { wallTexture = value; }
        }

        public Texture2D FloorTexture
        {
            get { return floorTexture; }
            set { floorTexture = value; }
        }

        public Level(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Smol:
                default:
                    map = Generate(new SquareType[64,64]);
                    pickupsRemaining = 6;
                    
                    break;
                case Difficulty.Reggi:
                    map = new SquareType[256, 256];
                    pickupsRemaining = 25;
                    Generate(map);
                    break;
                case Difficulty.Chonky:
                    map = new SquareType[512, 512];
                    pickupsRemaining = 50;
                    Generate(map);
                    break;
            }
        }

        public SquareType GetSquareType(int x, int y) => map[x,y];

        public void Update(GameTime gameTime)
        {
            //remove coins here etc
        }

        private SquareType[,] Generate(SquareType [,] mapArray)
        {
            mapArray = InitialiseMaze(mapArray);

            bool check = false;

            int xIndex = 0;
            int yIndex = 1;
            do
            {
                Walk(xIndex, yIndex, mapArray);
            } while (!check);
        }

        private int[] Walk(int x, int y, SquareType[,] map)
        {
            bool check2 = false;

            Random rnd = new Random();
        }

        private SquareType[,] InitialiseMaze(SquareType[,] map)
        {
            for(var x = 0; x < map.GetLength(0); x++)
            { 
                for (var y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = SquareType.Wall;
                }
            }

            map[0, 1] = SquareType.Floor;

            return map;
        }
    }
}