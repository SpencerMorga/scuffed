using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwu
{
    public class Shaq : Animation
    {
        Dictionary<ShaqEnums.actuallyshaq, List<Frame>> animation2;
        ShaqEnums.actuallyshaq actuallyshaqStates;
        ShaqEnums.actuallyshaq currentframestate2
        {
            get
            {
                return actuallyshaqStates;
            }
            set
            {
                if (actuallyshaqStates != value)
                {
                    actuallyshaqStates = value;
                    currentframestate2 = 0;
                }
            }
        }
        public Shaq(Texture2D image, Vector2 position, Color color, List<Frame> frames)
            : base(image, position, color, frames)
        {
            List<Frame> idleA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 2, 23, 45), new Vector2()),
                new Frame(new Rectangle(29, 1, 23, 46), new Vector2()),
                new Frame(new Rectangle(57, 1, 24, 46), new Vector2()),
                new Frame(new Rectangle(86, 1, 24, 46), new Vector2()),
                new Frame(new Rectangle(115, 2, 24, 45), new Vector2()),
                new Frame(new Rectangle(144, 2, 24, 46), new Vector2()),
                new Frame(new Rectangle(173, 1, 24, 46), new Vector2()),
                new Frame(new Rectangle(202, 1, 23, 47), new Vector2()),
            };
            animation2 = new Dictionary<ShaqEnums.actuallyshaq, List<Frame>>();
            animation2.Add(ShaqEnums.actuallyshaq.aIdle, idleA);

            List<Frame> jumpA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 256, 25, 45), new Vector2()),
                new Frame(new Rectangle(31, 253, 24, 47), new Vector2()),
                new Frame(new Rectangle(60, 253, 24, 41), new Vector2()),
                new Frame(new Rectangle(89, 253, 26, 35), new Vector2()),
                new Frame(new Rectangle(120, 253, 17, 43), new Vector2()),
                new Frame(new Rectangle(142, 253, 21, 47), new Vector2()),
                new Frame(new Rectangle(168, 264, 25, 37), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aJump, jumpA);
            //omae wa mou shindeiru
            List<Frame> blockA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 1066, 17, 45), new Vector2()),
                new Frame(new Rectangle(23, 1068, 17, 43), new Vector2()),
                new Frame(new Rectangle(45, 1066, 17, 45), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aBlock, blockA);
            //omae wa mou shindeiru
            List<Frame> crouchA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 206, 22, 42), new Vector2()),
                new Frame(new Rectangle(28, 206, 22, 42), new Vector2()),
                new Frame(new Rectangle(55, 206, 23, 42), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aCrouch, crouchA);
            
            List<Frame> crouchblockA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 1116, 22, 30), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aCrouchBlock, crouchblockA);
           
            List<Frame> crouchpunchA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 459, 30, 25), new Vector2()),
                new Frame(new Rectangle(36, 459, 39, 25), new Vector2()),
                new Frame(new Rectangle(80, 459, 30, 35), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aCrouchPunch, crouchpunchA);
            //rawr x3 nuzzles pounces on you UwU you so warm
            List<Frame> punchA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 358, 24, 46), new Vector2()),
                new Frame(new Rectangle(30, 358, 36, 45), new Vector2()),
                new Frame(new Rectangle(71, 359, 27, 45), new Vector2()),
                new Frame(new Rectangle(103, 359, 24, 45), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aPunch, punchA);
            
            List<Frame> kickA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 555, 24, 45), new Vector2()),
                new Frame(new Rectangle(30, 552, 40, 48), new Vector2()),
                new Frame(new Rectangle(75, 557, 28, 43), new Vector2()),
                new Frame(new Rectangle(108, 554, 27, 46), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aKick, kickA);
            
            List<Frame> jumpkickA = new List<Frame>()
            {
                new Frame(new Rectangle(1, 722, 35, 31), new Vector2()),
            };
            animation2.Add(ShaqEnums.actuallyshaq.aJumpKick, jumpkickA);
            //rawr x3 nuzzles pounces on you UwU you so warm
            List<Frame> crouchkickA = new List<Frame>()
            {
                new Frame(new Rectangle(43,  657, 43, 24), new Vector2()),
            };            
        }

        public void Update(GameTime gTime, KeyboardState ks)
        {
            frames = animation2[currentframestate2];

            if (currentframestate2 == ShaqEnums.actuallyshaq.aBlock)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.S))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aBlock;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.C))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouch;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouchBlock)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.V))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchBlock;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouchKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.B))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchKick;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aCrouchPunch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.X))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aCrouchPunch;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aPunch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.D))
            {               
                    currentframestate2 = ShaqEnums.actuallyshaq.aPunch;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.A))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aKick;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aJump)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.W))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aJump;
            }
            //anachronistic capitalism
            if (currentframestate2 == ShaqEnums.actuallyshaq.aJumpKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = ShaqEnums.actuallyshaq.aIdle;
                }
            }
            if (ks.IsKeyDown(Keys.E))
            {
                currentframestate2 = ShaqEnums.actuallyshaq.aJumpKick;
            }
        }
    }
}
