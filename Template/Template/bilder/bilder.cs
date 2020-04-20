using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.rörelse;

namespace Template.bilder
{
    class Bilder
    {
        protected Texture2D bild;

        public Vector2 Position;
        public Vector2 röra;
        public float hastighet;
        public input input;

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, bild.Width, bild.Height);
            }
        }

        public Bilder(Texture2D texture)
        {
            bild = texture;
        }

        public virtual void Update(GameTime gameTime, List<Bilder> bilders)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bild, Position, Color.White);
        }

        #region Kollision
        protected bool rörvänster(Bilder sprite)
        {
            return this.rectangle.Right + this.röra.X > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Left &&
              this.rectangle.Bottom > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Bottom;
        }

        protected bool rörhöger(Bilder sprite)
        {
            return this.rectangle.Left + this.röra.X < sprite.rectangle.Right &&
              this.rectangle.Right > sprite.rectangle.Right &&
              this.rectangle.Bottom > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Bottom;
        }

        protected bool rörtoppen(Bilder sprite)
        {
            return this.rectangle.Bottom + this.röra.Y > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Top &&
              this.rectangle.Right > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Right;
        }

        protected bool rörbotten(Bilder sprite)
        {
            return this.rectangle.Top + this.röra.Y < sprite.rectangle.Bottom &&
              this.rectangle.Bottom > sprite.rectangle.Bottom &&
              this.rectangle.Right > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Right;
        }
        #endregion
    }
}
