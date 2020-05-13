using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class poäng // klass för poängsystemet
    {
        public int Poäng1;
        public int Poäng2;

        private SpriteFont font1;
        public poäng(SpriteFont font)
        {
            font1 = font; //Fonten för poängen
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font1, Poäng1.ToString(), new Vector2(320, 70), Color.Black); //poäng för spelare 1, position 
            spriteBatch.DrawString(font1, Poäng2.ToString(), new Vector2(430, 70), Color.Black);//poäng för spelare 2, position 
            spara(Poäng1, Poäng2);
            
        }

        private void spara(int Poäng1, int Poäng2)
        {
            StreamWriter sw = new StreamWriter("Textfil.txt");
            sw.WriteLine(Poäng1);
            sw.WriteLine(Poäng2);
            sw.Close();
        }
    }
}
