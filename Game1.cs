using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlatformGame
{
    public class Game1 : Game
    {
        Player player;
        Level level;
        int tileSize;
        Texture2D coinTexture;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            tileSize = 8;
        }

        protected override void Initialize()
        {
            player = new Player();
            level = new Level(Difficulty.Smol); //todo: this should take difficulty from player
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.Texture = Content.Load<Texture2D>("player");
            level.WallTexture = Content.Load<Texture2D>("wall");
            level.FloorTexture = Content.Load<Texture2D>("floor");
            coinTexture = Content.Load<Texture2D>("coin");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime, level);
            level.Update(gameTime);

            if (player.WinState)
            {
                //todo: Player wins, show credits or something idk
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            for(var x = 0; x < level.Map.GetLength(0); x++)
            {
                for(var y = 0; y < level.Map.GetLength(1); y++)
                {
                    switch (level.Map[x, y].Type)
                    {
                        case SquareType.Wall:
                            _spriteBatch.Draw(level.WallTexture, new Rectangle(new Point(x * tileSize, y * tileSize), new Point(tileSize, tileSize)), Color.White);
                            break;
                        case SquareType.Floor:
                            _spriteBatch.Draw(level.FloorTexture, new Rectangle(new Point(x * tileSize, y * tileSize), new Point(tileSize, tileSize)), Color.White);
                            break;
                        case SquareType.FloorWithCoin:
                            _spriteBatch.Draw(level.FloorTexture, new Rectangle(new Point(x * tileSize, y * tileSize), new Point(tileSize, tileSize)), Color.White);
                            _spriteBatch.Draw(coinTexture, new Rectangle(new Point(x * tileSize, y * tileSize), new Point(tileSize, tileSize)), Color.White);
                            break;
                    }
                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}