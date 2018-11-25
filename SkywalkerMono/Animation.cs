using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saiyuki_VS_Skywalker
{
    public class Animation : Sprite
    {
        TimeSpan elaspedtime;
        public TimeSpan waitingtime;
        public List<Frame> frames;
        public int currentframeIndex = 0;

        public Animation(Texture2D image, Vector2 position, Color color, List<Frame> frames)
            : base(image, position, color)
        {
            this.image = image;
            this.position = position;
            this.color = color;
            this.frames = frames;
            waitingtime = TimeSpan.FromMilliseconds(90);
        }

        public virtual void Update(GameTime gtime)
        {
            elaspedtime += gtime.ElapsedGameTime;

            if (elaspedtime > waitingtime)
            {
                currentframeIndex++;
                if (currentframeIndex >= frames.Count)
                {
                    currentframeIndex = 0;
                }
                elaspedtime = TimeSpan.Zero;
            }
            sourceRectangle = frames[currentframeIndex].frame;
            Origin = frames[currentframeIndex].origin;
        }
    }
}
