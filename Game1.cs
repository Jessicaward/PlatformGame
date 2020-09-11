using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlatformGame
{
    public class Game1 : Game
    {
        Texture2D wallTexture;
        Texture2D floorTexture;
        Texture2D playerTexture;
        Texture2D enemyTexture;
        Texture2D pickupTexture;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            wallTexture = Content.Load<Texture2D>("wall");
            floorTexture = Content.Load<Texture2D>("floor");
            playerTexture = Content.Load<Texture2D>("player");
            enemyTexture = Content.Load<Texture2D>("enemy");
            pickupTexture = Content.Load<Texture2D>("pickup");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}