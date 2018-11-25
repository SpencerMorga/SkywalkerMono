using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saiyuki_VS_Skywalker
{
    public class SkywalkerStuff : MovingAnimation
    {
        Dictionary<SkywalkerEnums.SkyFrames, List<Frame>> animations;
        SkywalkerEnums.SkyFrames SkywalkerStates;
        SkywalkerEnums.SkyFrames currentFrameState
        {
            get
            {
                return SkywalkerStates;
            }
            set
            {
                if (SkywalkerStates != value)
                {
                    SkywalkerStates = value;
                    currentframeIndex = 0;
                }
            }
        }

        Vector2 initialvelocity;
        public Vector2 Velocity { get { return velocity; } }
        Vector2 velocity;
        bool isJumping = false;
        float gravity = 0.03f;

        //int pfloor;
        bool PastFloor
        {
            get { return position.Y + frames[currentframeIndex].frame.Height > Game1.Viewport.Height; }
        }
        
        private Vector2 BottomCenter(int width, int height)
        {
            return new Vector2(width / 2, height);
        }

        private Vector2 Center(int width, int height)
        {
            return new Vector2(width / 2, height / 2);
        }
        private Vector2 BottomLeft(int width, int height)
        {
            return new Vector2(0, height);
        }
        public SkywalkerStuff(Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base(image, position, speed, color, frames)
        {
            initialvelocity = speed;
            //center origin
            //bottom center
            List<Frame> RunRight = new List<Frame>()
            {
                new Frame(new Rectangle(202, 40, 18, 32), BottomLeft(18, 32)),
                new Frame(new Rectangle(242, 40, 20, 31), BottomLeft(20, 31)),
                new Frame(new Rectangle(285, 40, 12, 32), BottomLeft(12, 32)),
                new Frame(new Rectangle(324, 40, 14, 32), BottomLeft(14, 32)),
                new Frame(new Rectangle(361, 41, 21, 30), BottomLeft(21, 30)),
                new Frame(new Rectangle(202, 80, 19, 32), BottomLeft(19, 32)),
                new Frame(new Rectangle(244, 80, 14, 31), BottomLeft(14, 31)),
                new Frame(new Rectangle(284, 80, 15, 31), BottomLeft(15, 31)),
                new Frame(new Rectangle(321, 81, 20, 30), BottomLeft(20, 30)),
            };
            animations = new Dictionary<SkywalkerEnums.SkyFrames, List<Frame>>();
            animations.Add(SkywalkerEnums.SkyFrames.RunRight, RunRight);

            List<Frame> RunLeft = new List<Frame>()
            {
                new Frame(new Rectangle(162, 40, 18, 32),BottomLeft(18, 32)),
                new Frame(new Rectangle(121, 40, 19, 31),BottomLeft(19, 31)),
                new Frame(new Rectangle(85, 40, 12, 32), BottomLeft(12, 32)),
                new Frame(new Rectangle(44, 40, 14, 32), BottomLeft(14, 32)),
                new Frame(new Rectangle(0, 41, 21, 30),  BottomLeft(21, 30)),
                new Frame(new Rectangle(161, 80, 19, 32),BottomLeft(19, 32)),
                new Frame(new Rectangle(124, 80, 14, 31),BottomLeft(14, 31)),
                new Frame(new Rectangle(83, 80, 15, 31), BottomLeft(15, 31)),
                new Frame(new Rectangle(41, 81, 20, 30), BottomLeft(20, 30)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.RunLeft, RunLeft);

            List<Frame> DownSlice = new List<Frame>()
            {
                new Frame(new Rectangle(204, 274, 15, 43), BottomLeft(15, 43)),
                new Frame(new Rectangle(242, 274, 19, 44), BottomLeft(19, 44)),
                new Frame(new Rectangle(276, 275, 30, 41), BottomLeft(30, 41)),
                new Frame(new Rectangle(312, 277, 38, 38), BottomLeft(38, 38)),
                new Frame(new Rectangle(235, 320, 33, 32), BottomLeft(33, 32)),
                new Frame(new Rectangle(194, 320, 35, 32), BottomLeft(35, 32)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.DownSlice, DownSlice);

            List<Frame> UpSlice = new List<Frame>()
            {
                new Frame(new Rectangle(202, 240, 18, 31), BottomLeft(18, 31)),
                new Frame(new Rectangle(235, 241, 32, 30), BottomLeft(32, 30)),
                new Frame(new Rectangle(275, 241, 32, 30), BottomLeft(32, 30)),
                new Frame(new Rectangle(312, 277, 38, 38), BottomLeft(38, 38)),
                new Frame(new Rectangle(276, 275, 30, 41), BottomLeft(30, 41)),
                new Frame(new Rectangle(242, 274, 19, 44), BottomLeft(19, 44)),
                new Frame(new Rectangle(204, 274, 15, 43), BottomLeft(15, 43)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.UpSlice, UpSlice);

            List<Frame> Starting = new List<Frame>()
            {
                new Frame(new Rectangle(204, 200, 15, 32), new Vector2()),
                new Frame(new Rectangle(243, 200, 17, 32), new Vector2()),
                new Frame(new Rectangle(282, 198, 18, 35), new Vector2()),
                new Frame(new Rectangle(321, 186, 21, 39), new Vector2()),
            };
            animations.Add(SkywalkerEnums.SkyFrames.Starting, Starting);


            List<Frame> IdleRight = new List<Frame>()
            {
                new Frame(new Rectangle(321, 196, 21, 39), BottomLeft(21, 39)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.IdleRight, IdleRight);

            List<Frame> IdleLeft = new List<Frame>()
            {
                new Frame(new Rectangle(40, 196, 21, 39), BottomLeft(21, 39)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.IdleLeft, IdleLeft);

            List<Frame> Block = new List<Frame>()
            {
                new Frame(new Rectangle(204, 274, 15, 43), BottomLeft(15, 43)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.Block, Block);
            List<Frame> DownSliceLeft = new List<Frame>()
            {
                new Frame(new Rectangle(163, 274, 15, 43), BottomLeft(15, 43)),
                new Frame(new Rectangle(121, 274, 19, 44), BottomLeft(19, 44)),
                new Frame(new Rectangle(76, 275, 30, 41), BottomLeft(30, 41)),
                new Frame(new Rectangle(32, 277, 38, 38), BottomLeft(38, 38)),
                new Frame(new Rectangle(114, 320, 33, 32), BottomLeft(33, 32)),
                new Frame(new Rectangle(153, 320, 35, 32), BottomLeft(35, 32)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.DownSliceLeft, DownSliceLeft);

            List<Frame> UpSliceLeft = new List<Frame>()
            {
                new Frame(new Rectangle(162, 240, 18, 31), BottomLeft(18, 31)),
                new Frame(new Rectangle(115, 241, 32, 30), BottomLeft(32, 30)),
                new Frame(new Rectangle(75, 241, 32, 30), BottomLeft(32, 30)),
                new Frame(new Rectangle(32, 277, 38, 38), BottomLeft(38, 38)),
                new Frame(new Rectangle(76, 275, 30, 41), BottomLeft(30, 41)),
                new Frame(new Rectangle(121, 274, 19, 44), BottomLeft(19, 44)),
                new Frame(new Rectangle(163, 274, 15, 43), BottomLeft(15, 43)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.UpSliceLeft, UpSliceLeft);

            List<Frame> BlockLeft = new List<Frame>()
            {
                new Frame(new Rectangle(163, 274, 15, 43), BottomLeft(15, 43)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.BlockLeft, BlockLeft);

            List<Frame> JumpRight = new List<Frame>()
            {
                new Frame(new Rectangle(200, 121, 23, 30), BottomLeft(23, 30)),
                new Frame(new Rectangle(200, 121, 23, 30), BottomLeft(23, 30)),
                new Frame(new Rectangle(200, 121, 23, 30), BottomLeft(23, 30)),
                new Frame(new Rectangle(246, 122, 11, 27), BottomLeft(11, 27)),
                new Frame(new Rectangle(285, 121, 13, 29), BottomLeft(13, 29)),
                new Frame(new Rectangle(285, 121, 13, 29), BottomLeft(13, 29)),
                new Frame(new Rectangle(321, 121, 21, 31), BottomLeft(21, 31)),
                new Frame(new Rectangle(321, 121, 21, 31), BottomLeft(21, 31)),
                new Frame(new Rectangle(321, 121, 21, 31), BottomLeft(21, 31)),
                new Frame(new Rectangle(321, 121, 21, 31), BottomLeft(21, 31)),
                new Frame(new Rectangle(321, 121, 21, 31), BottomLeft(21, 31)),
                new Frame(new Rectangle(321, 121, 21, 31), BottomLeft(21, 31)),
                new Frame(new Rectangle(321, 121, 21, 31), BottomLeft(21, 31)),
                new Frame(new Rectangle(364, 121, 14, 29), BottomLeft(14, 29)),
                new Frame(new Rectangle(364, 121, 14, 29), BottomLeft(14, 29)),
                new Frame(new Rectangle(364, 121, 14, 29), BottomLeft(14, 29)),
                new Frame(new Rectangle(364, 121, 14, 29), BottomLeft(14, 29)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.JumpRight, JumpRight);

            List<Frame> JumpLeft = new List<Frame>()
            {
                new Frame(new Rectangle(159, 121, 23, 30), BottomLeft(23, 30)),
                new Frame(new Rectangle(159, 121, 23, 30), BottomLeft(23, 30)),
                new Frame(new Rectangle(159, 121, 23, 30), BottomLeft(23, 30)),
                new Frame(new Rectangle(125, 122, 11, 27), BottomLeft(11, 27)),
                new Frame(new Rectangle(84, 121, 13, 29), BottomLeft(13, 29)),
                new Frame(new Rectangle(84, 121, 13, 29), BottomLeft(13, 29)),
                new Frame(new Rectangle(40, 120, 21, 32), BottomLeft(21, 32)),
                 new Frame(new Rectangle(40, 120, 21, 32), BottomLeft(21, 32)),
                  new Frame(new Rectangle(40, 120, 21, 32), BottomLeft(21, 32)),
                  new Frame(new Rectangle(40, 120, 21, 32), BottomLeft(21, 32)),
                  new Frame(new Rectangle(40, 120, 21, 32), BottomLeft(21, 32)),
                  new Frame(new Rectangle(40, 120, 21, 32), BottomLeft(21, 32)),
                  new Frame(new Rectangle(40, 120, 21, 32), BottomLeft(21, 32)),
                new Frame(new Rectangle(4, 121, 14, 29), BottomLeft(14, 29)),
                new Frame(new Rectangle(4, 121, 14, 29), BottomLeft(14, 29)),
                new Frame(new Rectangle(4, 121, 14, 29), BottomLeft(14, 29)),
                new Frame(new Rectangle(4, 121, 14, 29), BottomLeft(14, 29)),
            };
            animations.Add(SkywalkerEnums.SkyFrames.JumpLeft, JumpLeft);
        }

        public void Update(GameTime gTime, KeyboardState hi)
        {
            frames = animations[currentFrameState];

            if (isJumping)
            {
                velocity.Y -= gravity;
                position.Y -= velocity.Y;

                //pass floor STOP JUMPING
                if (PastFloor)
                {
                    isJumping = false;
                }
            }
            if (currentFrameState == SkywalkerEnums.SkyFrames.JumpRight)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleRight;
                }
            }
            if (hi.IsKeyDown(Keys.E) && !isJumping)
            {
                currentFrameState = SkywalkerEnums.SkyFrames.JumpRight;
                velocity = initialvelocity;
                isJumping = true;
            }

            if (currentFrameState == SkywalkerEnums.SkyFrames.JumpLeft)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleLeft;
                }
            }
            if (hi.IsKeyDown(Keys.W) && !isJumping)
            {
                currentFrameState = SkywalkerEnums.SkyFrames.JumpLeft;
                velocity = initialvelocity;
                isJumping = true;
            }

           
            /////////////////////////////////////////////////////////////1

            if (currentFrameState == SkywalkerEnums.SkyFrames.RunRight)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleRight;
                }
            }
            if (hi.IsKeyDown(Keys.D))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.RunRight;
                position.X += speed.X;
            }

            /////////////////////////////////////////////////////////////2

            if (currentFrameState == SkywalkerEnums.SkyFrames.RunLeft)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleLeft;
                }
            }
            if (hi.IsKeyDown(Keys.A))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.RunLeft;
                position.X -= speed.X;
            }

            /////////////////////////////////////////////////////////////3

            if (currentFrameState == SkywalkerEnums.SkyFrames.UpSlice)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleRight;
                }
            }
            if (hi.IsKeyDown(Keys.U))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.UpSlice;
            }

            /////////////////////////////////////////////////////////////4

            if (currentFrameState == SkywalkerEnums.SkyFrames.DownSlice)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleRight;
                }
            }
            if (hi.IsKeyDown(Keys.Y))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.DownSlice;
            }

            /////////////////////////////////////////////////////////////5

            if (currentFrameState == SkywalkerEnums.SkyFrames.Block)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleRight;
                }
            }
            if (hi.IsKeyDown(Keys.V))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.Block;
            }

            /////////////////////////////////////////////////////////////6

            if (currentFrameState == SkywalkerEnums.SkyFrames.DownSliceLeft)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleLeft;
                }
            }
            if (hi.IsKeyDown(Keys.T))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.DownSliceLeft;
            }

            /////////////////////////////////////////////////////////////7

            if (currentFrameState == SkywalkerEnums.SkyFrames.UpSliceLeft)
            {
                if (currentframeIndex + 1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleLeft;
                }
            }
            if (hi.IsKeyDown(Keys.R))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.UpSliceLeft;
            }

            /////////////////////////////////////////////////////////////8

            if (currentFrameState == SkywalkerEnums.SkyFrames.BlockLeft)
            {
                if (currentframeIndex +1 >= frames.Count)
                {
                    currentFrameState = SkywalkerEnums.SkyFrames.IdleLeft;
                }
            }
            if (hi.IsKeyDown(Keys.C))
            {
                currentFrameState = SkywalkerEnums.SkyFrames.BlockLeft;
            }
            /////////////////////////////////////////////////////////////9
            



            base.Update(gTime);
         


        }
    }
}
