
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Template.Sprites
{
    public class Spelare : Sprite
    {
        private enum pausad //pausa spelarna.
        {
            spela,
            pausa
        }
        private pausad terminator;
        public Spelare(Texture2D texture)
          : base(texture)
        {
            Hastighet = 8f; //hastigheten spelaren har
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Keyboard.GetState().IsKeyDown(input.Escape)&& terminator == pausad.spela) //spelet pausas genom att trycka escape
            {
                terminator = pausad.pausa;
                Debug.WriteLine("pausad");
            }
            else if (Keyboard.GetState().IsKeyDown(input.Escape) && terminator == pausad.pausa) //spelet unpausar genom att trycka escape
            {
                terminator = pausad.spela;
                Debug.WriteLine("spelar");
            }
            if (input == null)
                throw new Exception("ge ett värde till input");
            if (terminator == pausad.spela)
            {
                if (Keyboard.GetState().IsKeyDown(input.Upp))  //spelarnas rörelse. 
                    Röra.Y = -Hastighet;
                else if (Keyboard.GetState().IsKeyDown(input.ned))
                    Röra.Y = Hastighet;
                Position += Röra;

                Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.ScreenHeight - bilder.Height);

                Röra = Vector2.Zero;
            }
        }
    }
}