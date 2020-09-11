using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PlatformGame
{
    public class Player
    {
        private bool dead = false;
        private int score = 0;
        private int livesRemaining = 3000;
        private Vector2 playerPosition = new Vector2();

        public bool Dead
        {
            get { return dead; }
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
            get { return PlayerPosition; }
        }

        public void Update(GameTime gameTime)
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

            if (keyboardState.IsKeyDown(Keys.W))
            {
                proposedPosition = new Vector2(playerPosition.X, playerPosition.Y + 1);
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                proposedPosition = new Vector2(playerPosition.X, playerPosition.Y - 1);
            }

            UpdatePlayerPosition(proposedPosition);
        }

        public void UpdatePlayerPosition(Vector2 proposedPosition)
        {
            if (dead)
            {
                return;
            }

            if (Level.GetSquareType(proposedPosition.X, proposedPosition.Y) == SquareType.Wall)
            {
                return;
            }

            playerPosition = proposedPosition;
        }
    }
}