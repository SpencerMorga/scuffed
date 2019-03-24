using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwu
{
    public class Sprite
    {
        public Texture2D image;
        public Vector2 position;
        public Color color;
        public Vector2 origin;
        public Rectangle sourceRectangle;
        public Rectangle destRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 500, 500);
            }
        }
        public Sprite(Texture2D image, Vector2 position, Color color)
        {
            this.image = image;
            this.position = position;
            this.color = color;
        }

        public void Draw (SpriteBatch spritebatch)
        {

            //spritebatch.Draw(image, position, sourceRectangle, color);

            

            spritebatch.Draw(image, position, sourceRectangle, color, 0, origin, Vector2.One, SpriteEffects.None, 0);
        }
        public void Draw (SpriteBatch spritebatch, Texture2D pixel)
        {
            spritebatch.Draw(image, position, sourceRectangle, color, 0, origin, Vector2.One, SpriteEffects.None, 0);
            spritebatch.Draw(pixel, new Rectangle((int)(origin.X + position.X), (int)(origin.Y + position.Y), 2, 2), Color.Transparent);
        }
        


    }
}
