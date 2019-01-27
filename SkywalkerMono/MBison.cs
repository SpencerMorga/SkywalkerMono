using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;

namespace Saiyuki_VS_Skywalker
{
    public class MBison : MovingAnimation
    {
        Dictionary<MBisonEnums.MBisonFrames, List<Frame>> animation5;
        MBisonEnums.MBisonFrames mbisonstates;
        MBisonEnums.MBisonFrames currentframestate5
        {
            get { return mbisonstates; }
            set { if (mbisonstates != value) { mbisonstates = value; currentframeIndex = 0; } }
        }
        Vector2 initialvelocity;
        Vector2 velocity;
        public Vector2 Velocity { get { return velocity; } }
        bool isJumping = false;
        float gravity = 0.05f;
        public bool punch;
        public bool hardpunch;
        public bool kick;
        public bool spinkick;
        public bool psychothingy;
        public int health = 170;
        public bool block;
        public bool hithigh;
        public bool crouch;
        public bool crouchhit;
        
        bool Pastfloor
        {
            get { return position.Y + frames[currentframeIndex].frame.Height > Game1.Viewport3.Height - 14; }
        }
        private Vector2 BottomLeft(int width, int height)
        {
            return new Vector2(0, height);
        }
        public MBison (Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base (image, position, speed, color, frames)
        {
            initialvelocity = speed;

            List<Frame> stand = new List<Frame>()
            {
                new Frame(new Rectangle(2, 21, 46, 64), new Vector2()),
                new Frame(new Rectangle(2, 21, 46, 64), new Vector2()),
                new Frame(new Rectangle(50, 22, 47, 64), new Vector2()),
                new Frame(new Rectangle(50, 22, 47, 64), new Vector2()),
                new Frame(new Rectangle(100, 24, 46, 64), new Vector2()),
                new Frame(new Rectangle(100, 24, 46, 64), new Vector2()),
                new Frame(new Rectangle(148, 22, 47, 64), new Vector2()),
                new Frame(new Rectangle(148, 22, 47, 64), new Vector2()),
            };
            animation5 = new Dictionary<MBisonEnums.MBisonFrames, List<Frame>>();
            animation5.Add(MBisonEnums.MBisonFrames.Stand, stand);
            

            List<Frame> punch = new List<Frame>()
            {
                new Frame(new Rectangle(237, 24, 43, 64), new Vector2()),
                new Frame(new Rectangle(237, 24, 43, 64), new Vector2()),
                new Frame(new Rectangle(287, 24, 56, 64), new Vector2()),
                new Frame(new Rectangle(287, 24, 56, 64), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.Punch, punch);

            List<Frame> hardpunch = new List<Frame>()
            {
           new Frame(new Rectangle(420, 28, 35, 64), new Vector2()),
           new Frame(new Rectangle(420, 28, 35, 64), new Vector2()),
          new Frame(new Rectangle(420, 28, 35, 64), new Vector2()),
           new Frame(new Rectangle(420, 28, 35, 64), new Vector2()),
           new Frame(new Rectangle(456, 33, 46, 64), new Vector2()),
           new Frame(new Rectangle(456, 33, 46, 64), new Vector2()),
           new Frame(new Rectangle(456, 33, 46, 64), new Vector2()),

            };
            animation5.Add(MBisonEnums.MBisonFrames.HardPunch, hardpunch);

            List<Frame> kick = new List<Frame>()
            {
                new Frame(new Rectangle(583, 21, 40, 64), new Vector2()),
                new Frame(new Rectangle(583, 21, 40, 64), new Vector2()),
                new Frame(new Rectangle(625, 21, 56, 64), new Vector2()),
                new Frame(new Rectangle(625, 21, 56, 64), new Vector2()),
                new Frame(new Rectangle(625, 21, 56, 64), new Vector2()),
                new Frame(new Rectangle(625, 21, 56, 64), new Vector2()),
                new Frame(new Rectangle(625, 21, 56, 64), new Vector2()),
                new Frame(new Rectangle(625, 21, 56, 64), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.Kick, kick);

            List<Frame> forward = new List<Frame>()
            {
                new Frame(new Rectangle(1, 126, 37, 68), new Vector2()),
                new Frame(new Rectangle(1, 126, 37, 68), new Vector2()),
                new Frame(new Rectangle(38, 125, 30, 69), new Vector2()),
                new Frame(new Rectangle(38, 125, 30, 69), new Vector2()),
                new Frame(new Rectangle(71, 126, 37, 68), new Vector2()),
                new Frame(new Rectangle(71, 126, 37, 68), new Vector2()),
                new Frame(new Rectangle(109, 125, 30, 69), new Vector2()),
                new Frame(new Rectangle(109, 125, 30, 69), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.Forward, forward);
            List<Frame> backward = new List<Frame>()
            {
                new Frame(new Rectangle(109, 125, 30, 69), new Vector2()),          
                new Frame(new Rectangle(109, 125, 30, 69), new Vector2()),
                new Frame(new Rectangle(71, 126, 37, 68), new Vector2()),
                new Frame(new Rectangle(71, 126, 37, 68), new Vector2()),
                new Frame(new Rectangle(38, 125, 30, 69), new Vector2()),
                new Frame(new Rectangle(38, 125, 30, 69), new Vector2()),
                new Frame(new Rectangle(1, 126, 37, 68), new Vector2()),
                new Frame(new Rectangle(1, 126, 37, 68), new Vector2()),

            };
            animation5.Add(MBisonEnums.MBisonFrames.Backward, backward);

            List<Frame> jump = new List<Frame>()
            {
            
                new Frame(new Rectangle(1, 233, 32, 68), new Vector2()),
                new Frame(new Rectangle(1, 233, 32, 68), new Vector2()),
                new Frame(new Rectangle(1, 233, 32, 68), new Vector2()),
                new Frame(new Rectangle(1, 233, 32, 68), new Vector2()),
                new Frame(new Rectangle(1, 233, 32, 68), new Vector2()),
                new Frame(new Rectangle(1, 233, 32, 68), new Vector2()),

                new Frame(new Rectangle(37, 234, 39, 61), new Vector2()),
                new Frame(new Rectangle(37, 234, 39, 61), new Vector2()),
                new Frame(new Rectangle(37, 234, 39, 61), new Vector2()),
                new Frame(new Rectangle(37, 234, 39, 61), new Vector2()),
                new Frame(new Rectangle(37, 234, 39, 61), new Vector2()),
                new Frame(new Rectangle(37, 234, 39, 61), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(79, 234, 51, 47), new Vector2()),

            };
            animation5.Add(MBisonEnums.MBisonFrames.Jump, jump);

            List<Frame> jumppunch = new List<Frame>()
            {
                new Frame(new Rectangle(172, 234, 51, 47), new Vector2()),
                new Frame(new Rectangle(228, 239, 48, 38), new Vector2()),
                new Frame(new Rectangle(277, 230, 66, 48), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.JumpPunch, jumppunch);

            List<Frame> jumpkick = new List<Frame>()
            {
                new Frame(new Rectangle(386, 226, 40, 64), new Vector2()),
                new Frame(new Rectangle(386, 226, 40, 64), new Vector2()),
                new Frame(new Rectangle(386, 226, 40, 64), new Vector2()),
                new Frame(new Rectangle(386, 226, 40, 64), new Vector2()),
                new Frame(new Rectangle(386, 226, 40, 64), new Vector2()),
                new Frame(new Rectangle(386, 226, 40, 64), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.JumpKick, jumpkick);

            List<Frame> flipkick = new List<Frame>()
            {
                new Frame(new Rectangle(501, 238, 46, 43), new Vector2()),
                new Frame(new Rectangle(548, 229, 37, 52), new Vector2()),
                new Frame(new Rectangle(587, 238, 60, 42), new Vector2()),
                new Frame(new Rectangle(647, 226, 56, 55), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
                new Frame(new Rectangle(430, 230, 60, 44), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.FlipKick, flipkick);

            List<Frame> PsychoThingy = new List<Frame>()
            {
              //  new Frame(new Rectangle(233, 461, 66, 48), new Vector2()),
                new Frame(new Rectangle(301, 463, 66, 28), new Vector2()),
                new Frame(new Rectangle(301, 463, 66, 28), new Vector2()),
                new Frame(new Rectangle(434, 464, 64, 28), new Vector2()),
                new Frame(new Rectangle(434, 464, 64, 28), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.PsychoThingy, PsychoThingy);

            List<Frame> Block = new List<Frame>()
            {
                new Frame(new Rectangle(1, 451, 43, 59), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.Block, Block);

            List<Frame> Crouch = new List<Frame>()
            {
                //new Frame(new Rectangle(152, 124, 44, 40), new Vector2()),
                new Frame(new Rectangle(199, 124, 45, 70), new Vector2()),
                new Frame(new Rectangle(199, 124, 45, 70), new Vector2()),
                new Frame(new Rectangle(199, 124, 45, 70), new Vector2()),
                new Frame(new Rectangle(199, 124, 45, 70), new Vector2()),
                new Frame(new Rectangle(199, 124, 45, 70), new Vector2()),
                new Frame(new Rectangle(199, 124, 45, 70), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.Crouch, Crouch);

            List<Frame> CrouchHit = new List<Frame>()
            {
                new Frame(new Rectangle(304, 360, 45, 51), new Vector2()),
                new Frame(new Rectangle(351,353, 44, 58), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.CrouchHit, CrouchHit);

            List<Frame> HitHigh = new List<Frame>()
            {
                new Frame(new Rectangle(3, 348, 44, 63), new Vector2()),
                new Frame(new Rectangle(49, 347, 44, 64), new Vector2()),
                new Frame(new Rectangle(95, 348, 37, 63), new Vector2()),
            };
            animation5.Add(MBisonEnums.MBisonFrames.HitHigh, HitHigh);
                
        }
        public void Update(GameTime gtime, KeyboardState ks)
        {
            frames = animation5[currentframestate5];
            if (punch)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Punch;
            }
            if (hardpunch)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.HardPunch;
            }
            if (kick)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Kick;
            }
            if (spinkick)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.FlipKick;
            }
            if (psychothingy)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.PsychoThingy;
            }
            if (block)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Block;
            }
            if (crouch)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Crouch;
            }
            
            if (hithigh)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.HitHigh;
            }
            if (crouchhit)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.CrouchHit;
            }
            
            if (isJumping)
            {
                velocity.Y -= gravity;
                position.Y -= velocity.Y;
                if (Pastfloor)
                {
                    isJumping = false;
                }
            }

            if (currentframestate5 == MBisonEnums.MBisonFrames.Jump)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.I) && !isJumping)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Jump;
                isJumping = true;
                velocity = initialvelocity;
                punch = false;
                kick = false;
                hardpunch = false;
                spinkick = false;
                psychothingy = false;
                block = false;
                crouch = false;
            }
            if (currentframestate5 == MBisonEnums.MBisonFrames.JumpPunch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.P))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.JumpPunch;;
            }
            
            if (currentframestate5 == MBisonEnums.MBisonFrames.JumpKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.Y) && !isJumping)
            {
                currentframestate5 = MBisonEnums.MBisonFrames.JumpKick;
                isJumping = true;
                velocity = initialvelocity;
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.Punch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.K))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Punch;
                punch = true;
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.HardPunch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.O))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.HardPunch;
                hardpunch = true;
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.Kick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.U))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Kick;
                kick = true;
            }
            ////////////////////////////////////////////////////////////////////
      
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.FlipKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.D9))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.FlipKick;
                position.X += speed.X;
                spinkick = true;
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.PsychoThingy)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.D8))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.PsychoThingy;
                position.X += speed.X * 3;
                psychothingy = true;
                
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.Forward)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.L))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Forward;
                position.X += speed.X;
                punch = false;
                kick = false;
                hardpunch = false;
                spinkick = false;
                psychothingy = false;
                block = false;
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.Backward)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.J))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Backward;
                position.X -= speed.X;
                punch = false;
                kick = false;
                hardpunch = false;
                spinkick = false;
                psychothingy = false;
                block = false;
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.Block)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.H))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Block;
                block = true;
            }
            ////////////////////////////////////////////////////////////////////
            if (currentframestate5 == MBisonEnums.MBisonFrames.Crouch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate5 = MBisonEnums.MBisonFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.OemComma))
            {
                currentframestate5 = MBisonEnums.MBisonFrames.Crouch;
            }
            base.Update(gtime);
        }

    }
}
