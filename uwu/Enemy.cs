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
                    currentframeIndex = 0;
                }
            }
        }
        public bool bjump = false;
        public bool bblock = false;
        public bool bcrouch = false;
        public bool bcrouchblock = false;
        public bool bcrouchpunch = false;
        public bool bcrouchkick = false;
        public bool bpunch = false;
        public bool bkick = false;
        public bool bjumpkick = false;
        public int health = 480;

        private Vector2 BottomRight(int width, int height)
        {
            return new Vector2(width, height);
        }

        public Enemy(Texture2D image, Vector2 position, Color color, List<Frame> frames)
            : base (image, position, color, frames)
        {
            
            List<Frame> idle = new List<Frame>()
            {
                new Frame(new Rectangle(328, 1, 32, 38), BottomRight(32, 38)),
            };
            animation = new Dictionary<EnemyEnums.ShaqFrames, List<Frame>>();
            animation.Add(EnemyEnums.ShaqFrames.Idle, idle);
            
            List<Frame> jump = new List<Frame>()
            {
                new Frame(new Rectangle(331, 220, 29, 39), BottomRight(29, 39)),
                new Frame(new Rectangle(301, 209, 25, 41), BottomRight(25, 41)),
                new Frame(new Rectangle(271, 209, 25, 36), BottomRight(25, 36)),
                new Frame(new Rectangle(235, 209, 21, 29), BottomRight(21, 29)),
                new Frame(new Rectangle(200, 209, 30, 35), BottomRight(30, 35)),
                new Frame(new Rectangle(163, 211, 32, 39), BottomRight(32, 39)),
                new Frame(new Rectangle(129, 220, 29, 30), BottomRight(29, 30)),
            };
            animation.Add(EnemyEnums.ShaqFrames.Jump, jump);

            List<Frame> block = new List<Frame>()
            {
                new Frame(new Rectangle(330, 850, 30, 37), BottomRight(30, 37)),
                new Frame(new Rectangle(302, 847, 23, 40), BottomRight(23, 40)),
                new Frame(new Rectangle(302, 847, 23, 40), BottomRight(23, 40)),
                new Frame(new Rectangle(302, 847, 23, 40), BottomRight(23, 40)),
                new Frame(new Rectangle(302, 847, 23, 40), BottomRight(23, 40)),
                new Frame(new Rectangle(302, 847, 23, 40), BottomRight(23, 40)),
                new Frame(new Rectangle(302, 847, 23, 40), BottomRight(23, 40)),
                new Frame(new Rectangle(267, 850, 30, 37), BottomRight(30, 37)),
            };
            animation.Add(EnemyEnums.ShaqFrames.Block, block);

            List<Frame> crouch = new List<Frame>()
            {
                new Frame(new Rectangle(331, 174, 29, 30), BottomRight(29, 30)),
                new Frame(new Rectangle(299, 174, 27, 30), BottomRight(27, 30)),
                new Frame(new Rectangle(299, 174, 27, 30), BottomRight(27, 30)),
                new Frame(new Rectangle(299, 174, 27, 30), BottomRight(27, 30)),
                new Frame(new Rectangle(299, 174, 27, 30), BottomRight(27, 30)),
                new Frame(new Rectangle(299, 174, 27, 30), BottomRight(27, 30)),
                new Frame(new Rectangle(299, 174, 27, 30), BottomRight(27, 30)),
                //new Frame(new Rectangle(331, 220, 29, 30), BottomRight(29, 30)),
            };
            animation.Add(EnemyEnums.ShaqFrames.Crouch, crouch);

            List<Frame> crouchblock = new List<Frame>()
            {
                new Frame(new Rectangle(336, 892, 24, 23), BottomRight(24, 23)),
                 new Frame(new Rectangle(306, 892, 25, 23), BottomRight(25, 23)),
                 new Frame(new Rectangle(306, 892, 25, 23), BottomRight(25, 23)),
                 new Frame(new Rectangle(306, 892, 25, 23), BottomRight(25, 23)),
                 new Frame(new Rectangle(306, 892, 25, 23), BottomRight(25, 23)),
                new Frame(new Rectangle(306, 892, 25, 23), BottomRight(25, 23)),
                new Frame(new Rectangle(277, 892, 24, 23), BottomRight(24, 23)),
            };
            animation.Add(EnemyEnums.ShaqFrames.Crouch_Block, crouchblock);

            List<Frame> crouchpunch = new List<Frame>()
            {
                new Frame(new Rectangle(331, 395, 29, 23), BottomRight(29, 23)),
                new Frame(new Rectangle(281, 395, 45, 23), BottomRight(45, 23)),
                 new Frame(new Rectangle(281, 395, 45, 23), BottomRight(45, 23)),
                new Frame(new Rectangle(247, 395, 29, 23), BottomRight(29, 23)),
            };
            animation.Add(EnemyEnums.ShaqFrames.Crouch_Punch, crouchpunch);

            List<Frame> punch = new List<Frame>()
            {
                new Frame(new Rectangle(330, 300, 30, 37), BottomRight(30, 37)),
                new Frame(new Rectangle(278, 305, 47, 32), BottomRight(47, 32)),
                new Frame(new Rectangle(241, 305, 33, 32), BottomRight(33, 32)),
            };
            animation.Add(EnemyEnums.ShaqFrames.Punch, punch);

            List<Frame> kick = new List<Frame>()
            {
                new Frame(new Rectangle(328, 495, 32, 37), BottomRight(32, 37)),
                new Frame(new Rectangle(298, 495, 25, 37), BottomRight(25, 37)),
                new Frame(new Rectangle(255, 492, 38, 40), BottomRight(38, 40)),
                new Frame(new Rectangle(225, 492, 25, 40), BottomRight(25, 40)),
                new Frame(new Rectangle(195, 495, 25, 37), BottomRight(25, 37)),
            };
            animation.Add(EnemyEnums.ShaqFrames.Kick, kick);

            List<Frame> crouchkick = new List<Frame>()
            { 
                new Frame(new Rectangle(329, 612, 31, 25), BottomRight(31, 25)),
                new Frame(new Rectangle(276, 613, 48, 24), BottomRight(48, 24)),
                 new Frame(new Rectangle(276, 613, 48, 24), BottomRight(48, 24)),
                new Frame(new Rectangle(240, 613, 31, 24), BottomRight(31, 24)),
                new Frame(new Rectangle(210, 612, 25, 25), BottomRight(25, 25)),
            };
            animation.Add(EnemyEnums.ShaqFrames.CrouchKick, crouchkick);
        }

        public void Update(GameTime gtime, KeyboardState ks)
        {
            frames = animation[currentframestate];

            if (bjump)
            {
                currentframestate = EnemyEnums.ShaqFrames.Jump;
            }
            if (bblock)
            {
                currentframestate = EnemyEnums.ShaqFrames.Block;
            }
            if (bcrouch)
            {
                currentframestate = EnemyEnums.ShaqFrames.Crouch;
            }
            if (bcrouchblock)
            {
                currentframestate = EnemyEnums.ShaqFrames.Crouch_Block;
            }
            if (bcrouchkick)
            {
                currentframestate = EnemyEnums.ShaqFrames.Crouch_Punch;
            }
            if (bcrouchpunch)
            {
                currentframestate = EnemyEnums.ShaqFrames.Crouch_Punch;
            }
            if (bkick)
            {
                currentframestate = EnemyEnums.ShaqFrames.Kick;
            }
            if (bpunch)
            {
                currentframestate = EnemyEnums.ShaqFrames.Punch;
            }
            if (bjumpkick)
            {
                currentframestate = EnemyEnums.ShaqFrames.JumpKick;
            }

            if (currentframestate == EnemyEnums.ShaqFrames.Block)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.RightShift))
            {
                currentframestate = EnemyEnums.ShaqFrames.Block;
                bblock = true;
                bcrouch = false;
                bcrouchblock = false;
                bcrouchkick = false;
                bcrouchpunch = false;
                bjump = false;
                bjumpkick = false;
                bkick = false;
                bpunch = false;
            }
            //capitalistic anachronism
            if (currentframestate == EnemyEnums.ShaqFrames.Crouch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad5))
            {
                currentframestate = EnemyEnums.ShaqFrames.Crouch;
                bblock = false;
                bcrouch = true;
                bcrouchblock = false;
                bcrouchkick = false;
                bcrouchpunch = false;
                bjump = false;
                bjumpkick = false;
                bkick = false;
                bpunch = false;
            }
            //anachronistic capitalism
            if (currentframestate == EnemyEnums.ShaqFrames.CrouchKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad2))
            {
                currentframestate = EnemyEnums.ShaqFrames.CrouchKick;
                bblock = false;
                bcrouch = false;
                bcrouchblock = false;
                bcrouchkick = true;
                bcrouchpunch = false;
                bjump = false;
                bjumpkick = false;
                bkick = false;
                bpunch = false;
            }
            ////////////////////////////////////////////////////////////////
            if (currentframestate == EnemyEnums.ShaqFrames.Crouch_Block)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad3))
            {
                currentframestate = EnemyEnums.ShaqFrames.Crouch_Block;
                bblock = false;
                bcrouch = false;
                bcrouchblock = true;
                bcrouchkick = false;
                bcrouchpunch = false;
                bjump = false;
                bjumpkick = false;
                bkick = false;
                bpunch = false;

            }
            ////////////////////////////////////////////////////////////////
            if (currentframestate == EnemyEnums.ShaqFrames.Crouch_Punch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad1))
            {
                currentframestate = EnemyEnums.ShaqFrames.Crouch_Punch;
                bblock = false;
                bcrouch = false;
                bcrouchblock = false;
                bcrouchkick = false;
                bcrouchpunch = true;
                bjump = false;
                bjumpkick = false;
                bkick = false;
                bpunch = false;
            }
            ////////////////////////////////////////////////////////////////
            if (currentframestate == EnemyEnums.ShaqFrames.Jump)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad8))
            {
                currentframestate = EnemyEnums.ShaqFrames.Jump;
                bblock = false;
                bcrouch = false;
                bcrouchblock = false;
                bcrouchkick = false;
                bcrouchpunch = false;
                bjump = true;
                bjumpkick = false;
                bkick = false;
                bpunch = false;
            }
            ////////////////////////////////////////////////////////////////
            if (currentframestate == EnemyEnums.ShaqFrames.JumpKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad7))
            {
                currentframestate = EnemyEnums.ShaqFrames.JumpKick;
                bblock = false;
                bcrouch = false;
                bcrouchblock = false;
                bcrouchkick = false;
                bcrouchpunch = false;
                bjump = false;
                bjumpkick = true;
                bkick = false;
                bpunch = false;
            }
            ////////////////////////////////////////////////////////////////
            if (currentframestate == EnemyEnums.ShaqFrames.Kick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad6))
            {
                currentframestate = EnemyEnums.ShaqFrames.Kick;
                bblock = false;
                bcrouch = false;
                bcrouchblock = false;
                bcrouchkick = false;
                bcrouchpunch = false;
                bjump = false;
                bjumpkick = false;
                bkick = true;
                bpunch = false;
            }
            ////////////////////////////////////////////////////////////////
            if (currentframestate == EnemyEnums.ShaqFrames.Punch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate = EnemyEnums.ShaqFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad4))
            {
                currentframestate = EnemyEnums.ShaqFrames.Punch;
                bblock = false;
                bcrouch = false;
                bcrouchblock = false;
                bcrouchkick = false;
                bcrouchpunch = false;
                bjump = false;
                bjumpkick = false;
                bkick = false;
                bpunch = true;
            }
            base.Update(gtime);
        }
    }    
}
