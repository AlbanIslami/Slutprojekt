using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.bilder
{
    public class spelare : Bilder
    {
        public Spelare(Texture2D texture)
            : base(texture)
        {
            hastighet = 5f;
        }

        public override void Update(GameTime gameTime, List<Bilder> bilders)
        {
            if (input == null)
                throw new Exception("ge ett värde till input");

            if (Keyboard.GetState().IsKeyDown(input.ned))
                röra.Y = -hastighet;
            else if (Keyboard.GetState().IsKeyDown(input.Upp))
                röra.Y = hastighet;

            Position += röra;

            Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.ScreenHeight - bild.Height);

            röra = Vector2.Zero;

        }
    }
}
