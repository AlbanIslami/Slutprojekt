using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Template.rörelse;
using Template.Sprites;

namespace Template
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth; // bredden på skärmen
        public static int ScreenHeight; // höjden på skärmen
        public static Random Random;

        private poäng poäng;
        private List<Sprite> sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            ScreenWidth = graphics.PreferredBackBufferWidth; // ladda in höjden och bredden på skärmen. 
            ScreenHeight = graphics.PreferredBackBufferHeight;
            Random = new Random();

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice); // laddar in bilderna

            var spelarTexture = Content.Load<Texture2D>("btt");
            var bollenTexture = Content.Load<Texture2D>("lul");

            poäng = new poäng(Content.Load<SpriteFont>("Fontet")); // ladda in fonten

            sprites = new List<Sprite>()
      {
        new Sprite(Content.Load<Texture2D>("bk")),
        new Spelare(spelarTexture) 
        {
          Position = new Vector2(20, (ScreenHeight / 2) - (spelarTexture.Height / 2)), //laddar in spelaren 
          input = new input()
          {
            Upp = Keys.W,
            ned = Keys.S,
            Escape = Keys.Escape
          }
        },
                new Spelare(spelarTexture)
                {
                    Position = new Vector2(ScreenWidth - 20 - spelarTexture.Width, (ScreenHeight / 2) - (spelarTexture.Height / 2)), //laddar in den andra spelaren
                    input = new input()
                    {
                        Upp = Keys.Up,
                        ned = Keys.Down,
                        Escape = Keys.Escape
                    }
                },
        new Ball(bollenTexture)
        {
            Position = new Vector2((ScreenWidth / 2) - (bollenTexture.Width / 2), (ScreenHeight / 2) - (bollenTexture.Height / 2)), //laddar in bollen i mitten av skärmen
            poäng = poäng,
        }
      };
        }



        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime, sprites);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var sprite in sprites)
                sprite.Draw(spriteBatch);

            poäng.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
