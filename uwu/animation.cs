using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwu
{
    public class Animation : Sprite
    {
        TimeSpan elaspedTime;
        public TimeSpan waitingtime;
        public List<Frame> frames;


        public int currentframeIndex = 0;
        
            public Animation(Texture2D image, Vector2 position, Color color, List<Frame> frames)
                : base(image, position, color)
            {
                this.frames = frames;
                waitingtime = TimeSpan.FromMilliseconds(90);
            }
            
        public void Update (GameTime gTime)
        {
            elaspedTime += gTime.ElapsedGameTime;
            if (elaspedTime > waitingtime)
            {
                currentframeIndex++;
                if (currentframeIndex >= frames.Count)
                {
                    currentframeIndex = 0;
                }
                elaspedTime = TimeSpan.Zero;
            }
            sourceRectangle = frames[currentframeIndex].frame;
            origin = frames[currentframeIndex].origin;
        }
    }
}
