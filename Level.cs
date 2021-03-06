﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PlatformGame
{
    public class Level
    {
        private Cell[,] map;
        private int pickupsRemaining;
        Texture2D wallTexture;
        Texture2D floorTexture;

        public Cell[,] Map
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
                    map = Generate(new Cell[64,64]);
                    pickupsRemaining = 6;
                    
                    break;
                case Difficulty.Reggi:
                    map = Generate(new Cell[256, 256]);
                    pickupsRemaining = 25;
                    
                    break;
                case Difficulty.Chonky:
                    map = Generate(new Cell[512, 512]);
                    pickupsRemaining = 50;
                    
                    break;
            }
        }

        public SquareType GetSquareType(int x, int y)
        {
            return map[x, y].Type;
        }

        public void Update(GameTime gameTime)
        {
            //remove coins here etc
        }

        public Cell[,] Generate(Cell [,] mapArray)
        {
            mapArray = InitialiseMaze(mapArray);

            bool check = false;

            Cell start = mapArray[0, 1];

            Cell activeCell = start;
       
            return mapArray;
        }

        private Cell Walk(Cell cell)
        {
            bool check2 = false;
            
            return cell;
        }

        private Cell[,] InitialiseMaze(Cell[,] map)
        {
            for(var x = 0; x < map.GetLength(0); x++)
            { 
                for (var y = 0; y < map.GetLength(1); y++)
                {
                    Cell cell = new Cell(SquareType.Wall, x, y, false);

                    map[x, y] = cell;
                }
            }

            return map;
        }
    }
}