using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Template.bilder
{
    class Bollen
    {
        private float tid = 0f;
        private Vector2 positionen = null;
        public float? speed;
        public bool spelande;

        public poäng poäng;
        public int SpeedIncrementSpan = 10;

        public Bollen(Texture2D texture)
        {
            speed = 3f;
        }

        public override void Update(List<Bilder> sprites, GameTime gameTime)
        {
            if (positionen == null)
            {
                positionen = Position;
                speed = hastighet;

                Restart();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                spelande = true;
            return;

            if (!spelande)
                return;



            tid += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (tid > SpeedIncrementSpan)
            {
                speed++;
                tid = 0;
            }
            foreach(var sprite in Bilder)
            {
                if (sprite == this)
                    continue;

                if (this.Velocity.X > 0 && this.rörvänster(sprite))
                    this.Velocity.X = -this.Velocity.X;
                if (this.Velocity.X < 0 && this.rörhöger(sprite))
                    this.Velocity.X = -this.Velocity.X;
                if (this.Velocity.Y < 0 && this.rörtoppen(sprite))
                    this.Velocity.Y = -this.Velocity.Y;
                if (this.Velocity.Y < 0 && this.rörbotten(sprite))
                    this.Velocity.Y = -this.Velocity.Y;
            }

            if(positionen.Y <= 0)
        }



        public void Restart()
        {
            var direction = Game1.Random.Next(0, 4);

            switch (direction)
            {
                case 0;
                    Velocity = new Vector2(1, 1);
                    break;
                case 1;
                    Velocity = new Vector2(1, 1);
                    break;
                case 2;
                    Velocity = new Vector2(1, 1);
                    break;
                case 3;
                    Velocity = new Vector2(1, 1);
                    break;
            }

            Position = (Vector2)positionen;
            speed = (float)Positionen;
            tid = 0;
            spelande = false;
        }

            }
        }

    }

