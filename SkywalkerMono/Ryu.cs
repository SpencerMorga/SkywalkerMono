
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saiyuki_VS_Skywalker
{
    public class Ryu : MovingAnimation
    {
        Dictionary<SaiyukiEnums.SaiyukiFrames, List<Frame>> animation2;
        SaiyukiEnums.SaiyukiFrames saiyukistates;
        SaiyukiEnums.SaiyukiFrames currentframestate2
        {
            get
            {
                return saiyukistates;
            }
            set
            {
                if (saiyukistates != value)
                {
                    saiyukistates = value;
                    currentframeIndex = 0;
                }

            }

        }
        Vector2 initialvelocity;
        Vector2 velocity;
        public Vector2 Velocity { get { return velocity; } }
        bool isJumping = false;
        float gravity = 0.05f;
        public int health = 400;
        public bool punch;
        public bool kick;
        public bool jumppunch;
        public bool jumpkick;
        public bool block = false;
        bool Pastfloor
        {
            get { return position.Y + frames[currentframeIndex].frame.Height > Game1.Viewport2.Height - 16; }
        }

        public Ryu(Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base(image, position, speed, color, frames)
        {
            initialvelocity = speed;

            List<Frame> stand = new List<Frame>()
            {
                new Frame(new Rectangle(1, 40, 24, 60), new Vector2()),
                new Frame(new Rectangle(1, 40, 24, 60), new Vector2()),
                new Frame(new Rectangle(30, 39, 23, 61), new Vector2()),
                new Frame(new Rectangle(30, 39, 23, 61), new Vector2()),
                new Frame(new Rectangle(57, 38, 23, 62), new Vector2()),
                new Frame(new Rectangle(57, 38, 23, 62), new Vector2()),
            };
            animation2 = new Dictionary<SaiyukiEnums.SaiyukiFrames, List<Frame>>();
            animation2.Add(SaiyukiEnums.SaiyukiFrames.Stand, stand);
            List<Frame> punch = new List<Frame>()
            {
                new Frame(new Rectangle(302, 40, 28, 60), new Vector2()),
                new Frame(new Rectangle(302, 40, 28, 60), new Vector2()),
                new Frame(new Rectangle(335, 40, 26, 60), new Vector2()),
                new Frame(new Rectangle(335, 40, 26, 60), new Vector2()),
                new Frame(new Rectangle(364, 40, 44, 60), new Vector2()),
                new Frame(new Rectangle(364, 40, 44, 60), new Vector2()),
            };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.Punch, punch);
            List<Frame> kick = new List<Frame>()
            {
                new Frame(new Rectangle(515, 40, 28, 60), new Vector2()),
                new Frame(new Rectangle(515, 40, 28, 60), new Vector2()),
                new Frame(new Rectangle(546, 40, 31, 60), new Vector2()),
                new Frame(new Rectangle(546, 40, 31, 60), new Vector2()),
                new Frame(new Rectangle(578, 40, 45, 60), new Vector2()),
                new Frame(new Rectangle(578, 40, 45, 60), new Vector2()),
            };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.Kick, kick);
            List<Frame> forward = new List<Frame>()
            {
                new Frame(new Rectangle(1, 143, 25, 60), new Vector2()),
                new Frame(new Rectangle(55, 143, 27, 60), new Vector2()),
                new Frame(new Rectangle(85, 143, 29, 60), new Vector2()),
                new Frame(new Rectangle(118, 143, 23, 60), new Vector2()),
            };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.WalkForward, forward);
            List<Frame> backward = new List<Frame>()
            {
                new Frame(new Rectangle(156, 144, 28, 60), new Vector2()),
                new Frame(new Rectangle(187, 144, 27, 59), new Vector2()),
                new Frame(new Rectangle(217, 143, 28, 61), new Vector2()),
                new Frame(new Rectangle(248, 142, 28, 62), new Vector2()),
                new Frame(new Rectangle(277, 143, 27, 60), new Vector2()),
            };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.WalkBackwards, backward);
            /*
            List<Frame > crouch = new List<Frame>()
            {
                new Frame(new Rectangle(319, 153, 25, 60), new Vector2()),
                new Frame(new Rectangle(346, 144, 27, 60), new Vector2()),
                new Frame(new Rectangle(377, 144, 25, 60), new Vector2()),
                new Frame(new Rectangle(406, 144, 24, 60), new Vector2()),
            };
                
            animation2.Add(SaiyukiEnums.SaiyukiFrames.Crouch, crouch);
            */
            List <Frame>  jump= new List<Frame>()
            {
                new Frame(new Rectangle(1, 244, 24, 63), new Vector2()),
                new Frame(new Rectangle(1, 244, 24, 63), new Vector2()),
                new Frame(new Rectangle(1, 244, 24, 63), new Vector2()),
                new Frame(new Rectangle(1, 244, 24, 63), new Vector2()),
                new Frame(new Rectangle(27, 247, 23, 60), new Vector2()),
                new Frame(new Rectangle(27, 247, 23, 60), new Vector2()),
                new Frame(new Rectangle(27, 247, 23, 60), new Vector2()),
                new Frame(new Rectangle(52, 254, 26, 53), new Vector2()),
                new Frame(new Rectangle(52, 254, 26, 53), new Vector2()),
             };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.Jump, jump);

            List<Frame > jumppunch = new List<Frame>()
            {

                new Frame(new Rectangle(319, 259, 40, 41), new Vector2()),
                new Frame(new Rectangle(319, 259, 40, 41), new Vector2()),
                new Frame(new Rectangle(319, 259, 40, 41), new Vector2()),
                new Frame(new Rectangle(319, 259, 40, 41), new Vector2()),
            };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.JumpPunch, jumppunch);
            List<Frame > jumpkick = new List<Frame>()
            {

                new Frame(new Rectangle(971 ,254, 50, 42), new Vector2()),
                new Frame(new Rectangle(971 ,254, 50, 42), new Vector2()),
                new Frame(new Rectangle(971 ,254, 50, 42), new Vector2()),
                new Frame(new Rectangle(971 ,254, 50, 42), new Vector2()),
            };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.JumpKick, jumpkick);

            List<Frame> block = new List<Frame>()
            {
                new Frame(new Rectangle(2, 460, 29, 59), new Vector2()),
            };
            animation2.Add(SaiyukiEnums.SaiyukiFrames.Block, block);

            
        }

        public void Update(GameTime gtime, KeyboardState ks)
        {
            frames = animation2[currentframestate2];

            if (punch)
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.Punch;
            }
            if (kick)
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.Kick;
            }
            if (jumppunch)
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.JumpPunch;
            }
            if (jumpkick)
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.JumpKick;
            }
            if (block) currentframestate2 = SaiyukiEnums.SaiyukiFrames.Block;
            if (isJumping)
            {
                velocity.Y -= gravity;
                position.Y -= velocity.Y;
                if (Pastfloor)
                {
                    isJumping = false;
                }

            }
         
            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.JumpPunch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad9))
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.JumpPunch;
                jumppunch = true;
            }

            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.Jump)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad8) && !isJumping)
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.Jump;
                velocity = initialvelocity;
                isJumping = true;
                punch = false;
                kick = false;
                jumpkick = false;
                jumppunch = false;
                block = false;
            }

            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.JumpKick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad7))
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.JumpKick;
                jumpkick = true;

            }
            //////////////////////////////////////////////////////////////////
            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.Punch)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad5))
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.Punch;
                punch = true;
            }
            
            //////////////////////////////////////////////////////////////////
            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.Kick)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad0))
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.Kick;
                kick = true;
            }
            //////////////////////////////////////////////////////////////////
            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.WalkForward)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad6))
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.WalkForward;
                position.X += speed.X*2;
                punch = false;
                kick = false;
                jumppunch = false;
                jumpkick = false;
                block = false;
            }
            
            //////////////////////////////////////////////////////////////////
            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.WalkBackwards)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad4))
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.WalkBackwards;
                position.X -= speed.X*2;
                punch = false;
                kick = false;
                jumppunch = false;
                jumpkick = false;
                block = false;
            }
            //////////////////////////////////////////////////////////////////
            if (currentframestate2 == SaiyukiEnums.SaiyukiFrames.Block)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentframestate2 = SaiyukiEnums.SaiyukiFrames.Stand;
                }
            }
            if (ks.IsKeyDown(Keys.NumPad2))
            {
                currentframestate2 = SaiyukiEnums.SaiyukiFrames.Block;
                block = true;
            }


            base.Update(gtime);
        }
    }
}

