using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwu
{
    public class animation : sprite
    {
        TimeSpan elaspedTime;
        public TimeSpan waitingtime;
        public List<Rectangle> frames;
        public int currentframeIndex = 0;
        
            public animation(Texture2D image, Vector2 position, Color color, List<Rectangle> frames)
                : base(image, position, color)
            {
                this.frames = frames;
                waitingtime = TimeSpan.FromMilliseconds(90);
            }
            
        public void Update (GameTime gTime)
        {
            elaspedTime += gTime.ElapsedGameTime;
        }
    }
}
