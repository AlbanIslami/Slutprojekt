using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Template.bilder;
using Template.rörelse;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static Random Random;

        private poäng _poäng;
        private List<Bilder> bilders;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
            Random = new Random();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var bollenTexture = Content.Load<Texture2D>("gdgd.png");
            var SpelareTexture = Content.Load<Texture2D>("hand.jpg");

            _poäng = new poäng(Content.Load<SpriteFont>("Fontet"));

            bilders = new List<Bilder>();
            {
                new Bilder(Content.Load<Texture2D>("bakgrund.png"));
                new spelare(SpelareTexture)
                {
                    Position = new Vector2(20, (ScreenHeight / 2) - (SpelareTexture.Height / 2)),
                    input = new input()
                    {
                        Upp = Keys.W,
                        ned = Keys.S,
                    }
                };
                new spelare(SpelareTexture)
                {
                    Position = new Vector2(ScreenWidth - 20 - SpelareTexture.Width, (ScreenHeight / 2) - (SpelareTexture.Height / 2)),
                    input = new input()
                    {
                        Upp = Keys.Up,
                        ned = Keys.Down,
                    }
                };
                new Ball(bollenTexture)
                {
                    Position = new Vector2((ScreenWidth / 2) - (bollenTexture.Width / 2), (ScreenHeight / 2) - (bollenTexture.Height / 2)),
                    poäng = _poäng,
                };
                {
                };
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }




        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in bilders)
            {
                sprite.Update(gameTime, bilders);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var sprite in bilders)
                sprite.Draw(spriteBatch);

            _poäng.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
