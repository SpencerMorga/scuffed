using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uwu
{
    public class Enemy : Animation
    {
        Dictionary<EnemyEnums.ShaqFrames, List<Frame>> animation;
        EnemyEnums.ShaqFrames shaqstates;
        EnemyEnums.ShaqFrames currentframestate
        {
            get
            {
                return shaqstates;       
            }
            set
            {
                if (shaqstates != value)
                {
                    shaqstates = value;
                    currentframestate = 0;
                }
            }
        }
        
        public Enemy(Texture2D image, Vector2 position, Color color, List<Frame> frames)
            : base (image, position, color, frames)
        {
            
            List<Frame> idle = new List<Frame>()
            {
                new Frame(new Rectangle(328, 1, 32, 38), new Vector2()),
                new Frame(new Rectangle(291, 2, 32, 37), new Vector2()),
                new Frame(new Rectangle(256, 2, 30, 37), new Vector2()),
                new Frame(new Rectangle(221, 1, 30, 38), new Vector2()),
            };
            animation = new Dictionary<EnemyEnums.ShaqFrames, List<Frame>>();
            animation.Add(EnemyEnums.ShaqFrames.Idle, idle);

            List<Frame> jump = new List<Frame>()
            {
                new Frame(new Rectangle(331, 220, 29, 39), new Vector2()),
                new Frame(new Rectangle(301, 209, 25, 41), new Vector2()),
                new Frame(new Rectangle(271, 209, 25, 36), new Vector2()),
                new Frame(new Rectangle(235, 209, 21, 29), new Vector2()),
                new Frame(new Rectangle(200, 209, 30, 35), new Vector2()),
                new Frame(new Rectangle(163, 211, 32, 39), new Vector2()),
                new Frame(new Rectangle(129, 220, 29, 30), new Vector2()),
            };
            animation.Add(EnemyEnums.ShaqFrames.Jump, jump);

            List<Frame> block = new List<Frame>()
            {
                new Frame(new Rectangle(330, 850, 30, 37), new Vector2()),
                new Frame(new Rectangle(302, 847, 23, 40), new Vector2()),
                new Frame(new Rectangle(267, 850, 30, 37), new Vector2()),
            };
            animation.Add(EnemyEnums.ShaqFrames.Block, block);

            List<Frame> crouch = new List<Frame>()
            {
                new Frame(new Rectangle(331, 174, 29, 30), new Vector2()),
                new Frame(new Rectangle(299, 174, 27, 30), new Vector2()),
                new Frame(new Rectangle(331, 220, 29, 30), new Vector2()),
            };
            animation.Add(EnemyEnums.ShaqFrames.Crouch, crouch);

            List<Frame> crouchblock = new List<Frame>()
            {
                new Frame(new Rectangle(336, 892, 24, 23), new Vector2()),
                new Frame(new Rectangle(306, 892, 25, 23), new Vector2()),
                new Frame(new Rectangle(277, 892, 24, 23), new Vector2()),
            };
            animation.Add(EnemyEnums.ShaqFrames.Crouch_Block, crouchblock);

            List<Frame> crouchpunch = new List<Frame>()
            {
                new Frame(new Rectangle(331, 395, 29, 23), new Vector2()),
                new Frame(new Rectangle(281, 395, 45, 23), new Vector2()),
                new Frame(new Rectangle(247, 395, 29, 23), new Vector2()),
            };
            animation.Add(EnemyEnums.ShaqFrames.Crouch_Punch, crouchpunch);

            List<Frame> punch = new List<Frame>()
            {
                new Frame(new Rectangle(330, 300, 30, 37), new Vector2()),
                new Frame(new Rectangle(278, 305, 47, 32), new Vector2()),
                new Frame(new Rectangle(241, 305, 33, 32), new Vector2()),
            };/* rawr XD *nuzzles* UwU *pounces on you* OwO so warm */
            animation.Add(EnemyEnums.ShaqFrames.Punch, punch);

            List<Frame> kick = new List<Frame>()
            {
                new Frame(new Rectangle(328, 495, 32, 37), new Vector2()),
                new Frame(new Rectangle(298, 495, 25, 37), new Vector2()),
                new Frame(new Rectangle(255, 492, 38, 40), new Vector2()),
                new Frame(new Rectangle(225, 492, 25, 40), new Vector2()),
                new Frame(new Rectangle(195, 495, 25, 37), new Vector2()),
            };
            animation.Add(EnemyEnums.ShaqFrames.Kick, kick);

            List<Frame> crouchkick = new List<Frame>()
            { 
                new Frame(new Rectangle(329, 612, 31, 25), new Vector2()),
                new Frame(new Rectangle(276, 613, 48, 24), new Vector2()),
                new Frame(new Rectangle(240, 613, 31, 24), new Vector2()),
                new Frame(new Rectangle(210, 612, 25, 25), new Vector2()),
            };
            animation.Add(EnemyEnums.ShaqFrames.CrouchKick, crouchkick);
        }

            
    }
}
