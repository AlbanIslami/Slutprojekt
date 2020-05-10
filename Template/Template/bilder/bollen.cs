using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Template.bilder
{
    public class Ball : Bilder
    {
        private float tid = 0f;
        private Vector2? startpositionen = null;
        public float? speed;
        public bool spelande;

        public poäng poäng;
        public int SpeedIncrementSpan = 10;

        public Ball(Texture2D texture)
            : base(texture)
        {
            speed = 3f;
        }

        public override void Update(GameTime gameTime, List<Bilder> sprites)
        {
            if (startpositionen == null)
            {
                startpositionen = Position;
                speed = hastighet;

                Restart();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                spelande = true;

            if (!spelande)

                return;
            

            tid += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (tid > SpeedIncrementSpan)
            {
                speed++;
                tid = 0;
            }
            foreach (var bilder in sprites)
            {
                if (bilder == this)
                    continue;

                if (this.röra.X > 0 && this.rörvänster(bilder))
                    this.röra.X = -this.röra.X;
                if (this.röra.X < 0 && this.rörhöger(bilder))
                    this.röra.X = -this.röra.X;
                if (this.röra.Y < 0 && this.rörtoppen(bilder))
                    this.röra.Y = -this.röra.Y;
                if (this.röra.Y < 0 && this.rörbotten(bilder))
                    this.röra.Y = -this.röra.Y;
            }

            if (Position.Y <= 0 || Position.Y + bild.Height >= Game1.ScreenHeight)
                röra.Y = -röra.Y;

            if (Position.X <= 0)
            {
                poäng.Poäng2++;
                Restart();
            }

            if (Position.X + bild.Width >= Game1.ScreenWidth)
            {
                poäng.Poäng1++;
                Restart();
            }

            Position += röra * hastighet;
        }



        public void Restart()
        {
            var direction = Game1.Random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    röra = new Vector2(1, 1);
                    break;
                case 1:
                    röra = new Vector2(1, -1);
                    break;
                case 2:
                    röra = new Vector2(-1, -1);
                    break;
                case 3:
                    röra = new Vector2(-1, 1);
                    break;
            }

            Position = (Vector2)Position;
            hastighet = (float)speed;
            tid = 0;
            spelande = false;
        }
    }
 }

    

