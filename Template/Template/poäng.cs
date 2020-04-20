using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class poäng
    {
        public int Poäng1;
        public int Poäng2;

        private SpriteFont fontet;
        public poäng(SpriteFont font)
        {
            fontet = font;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(fontet, Poäng1.ToString(), new Vector2(320, 70), Color.Black);
            spriteBatch.DrawString(fontet, Poäng2.ToString(), new Vector2(430, 70), Color.Black);
        }
        
    }
}
