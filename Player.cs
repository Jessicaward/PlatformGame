﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlatformGame
{
    public class Player
    {
        private bool dead;
        private bool winState;
        private int score;
        private int livesRemaining;
        private Vector2 playerPosition;
        Texture2D texture;

        public bool Dead
        {
            get { return dead; }
        }

        public bool WinState
        {
            get { return winState; }
        }

        public int Score
        {
            get { return score; }
        }

        public int LivesRemaining
        {
            get { return livesRemaining; }
        }

        public Vector2 PlayerPosition
        {
            get { return playerPosition; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        //Initialise variables
        public Player()
        {
            livesRemaining = 3;
            playerPosition = new Vector2(0, 0);
            dead = false;
            score = 0;
        }

        public void Update(GameTime gameTime, Level level)
        {
            var keyboardState = Keyboard.GetState();
            var proposedPosition = new Vector2();
            
            if (keyboardState.IsKeyDown(Keys.A))
            {
                proposedPosition = new Vector2(playerPosition.X - 1, playerPosition.Y);
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                proposedPosition = new Vector2(playerPosition.X + 1, playerPosition.Y);
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                proposedPosition = new Vector2(playerPosition.X, playerPosition.Y + 1);
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                proposedPosition = new Vector2(playerPosition.X, playerPosition.Y - 1);
            }

            UpdatePlayerPosition(proposedPosition, level);
        }

        private void UpdatePlayerPosition(Vector2 proposedPosition, Level level)
        {
            //If player is dead
            if (dead)
            {
                return;
            }

            //If player is trying to enter a wall tile
            if (level.GetSquareType((int)Math.Floor(proposedPosition.X), (int)Math.Floor(proposedPosition.Y)) == SquareType.Wall)
            {
                return;
            }

            //If player is trying to enter the exit tile
            if (level.GetSquareType((int)Math.Floor(proposedPosition.X), (int)Math.Floor(proposedPosition.Y)) == SquareType.Exit)
            {
                //Check if the player has picked up all pickups
                if(level.PickupsRemaining > 0)
                {
                    return;
                }

                //player wins!
                winState = true;
            }

            //If none of the above checks hit, then move player to the tile they're trying to enter
            playerPosition = proposedPosition;
        }
    }
}