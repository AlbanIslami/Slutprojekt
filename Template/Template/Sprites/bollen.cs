using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template.Sprites
{
    public class Ball : Sprite
    {
        private float tid = 0f; // Ökning av farten 
        private Vector2? startpositionen = null;
        private float? Starten;
        private bool spelar;

        public poäng poäng;
        public int SpeedIncrementSpan = 10; //Hur ofta farten ska öka

        public Ball(Texture2D texture)
          : base(texture)
        {
            Hastighet = 7f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (startpositionen == null)
            {
                startpositionen = Position;
                Starten = Hastighet;

                Restart();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                spelar = true;

            if (!spelar)
                return;

            tid += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (tid > SpeedIncrementSpan) //om hastigheten på bollen ska öka och timern restartas.
            {
                Hastighet++;
                tid = 0;
            }

            //när bollen rör någon av spelarna.
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if (this.Röra.X > 0 && this.IsTouchingLeft(sprite))
                    this.Röra.X = -this.Röra.X;
                if (this.Röra.X < 0 && this.IsTouchingRight(sprite))
                    this.Röra.X = -this.Röra.X;
                if (this.Röra.Y > 0 && this.IsTouchingTop(sprite))
                    this.Röra.Y = -this.Röra.Y;
                if (this.Röra.Y < 0 && this.IsTouchingBottom(sprite))
                    this.Röra.Y = -this.Röra.Y;
            }

            if (Position.Y <= 0 || Position.Y + bilder.Height >= Game1.ScreenHeight) //bollen kommer 'studsa'
                Röra.Y = -Röra.Y;

            if (Position.X <= 0) //spelare 2 får poäng och spelet börjar om
            {
                poäng.Poäng2++;
                Restart();
            }

            if (Position.X + bilder.Width >= Game1.ScreenWidth) //spelare 1 får poäng och spelet börjar om
            {
                poäng.Poäng1++;
                Restart();
            }

            Position += Röra * Hastighet;
        }

        public void Restart() //när spelet ska restartas
        {
            var direction = Game1.Random.Next(0, 4); //random riktning bollen åker när spelet börjar.

            switch (direction)
            {
                case 0:
                    Röra = new Vector2(1, 1);
                    break;
                case 1:
                    Röra = new Vector2(1, -1);
                    break;
                case 2:
                    Röra = new Vector2(-1, -1);
                    break;
                case 3:
                    Röra = new Vector2(-1, 1);
                    break;
            }

            Position = (Vector2)startpositionen; //när spelet är 'pausat'
            Hastighet = (float)Starten;
            tid = 0;
            spelar = false;
        }
    }
}