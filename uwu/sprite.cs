using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwu
{
    public class sprite
    {
        Texture2D image;
        Vector2 position;
        Color color;
        Rectangle sourceRectangle;

        public sprite(Texture2D image, Vector2 position, Color color)
        {
            this.image = image;
            this.position = position;
            this.color = color;
        }

        public void Draw (SpriteBatch spritebatch)
        {
            spritebatch.Draw(image, position, sourceRectangle, color);
        }
        


    }
}
