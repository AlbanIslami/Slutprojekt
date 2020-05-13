
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template.Sprites
{
    public class Spelare : Sprite
    {
        public Spelare(Texture2D texture)
          : base(texture)
        {
            Hastighet = 8f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (input == null)
                throw new Exception("ge ett värde till input");

            if (Keyboard.GetState().IsKeyDown(input.Upp))
                Röra.Y = -Hastighet;
            else if (Keyboard.GetState().IsKeyDown(input.ned))
                Röra.Y = Hastighet;

            Position += Röra;

            Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.ScreenHeight - bilder.Height);

            Röra = Vector2.Zero;
        }
    }
}