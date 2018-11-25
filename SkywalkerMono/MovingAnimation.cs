using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saiyuki_VS_Skywalker
{
    public class MovingAnimation : Animation
    {
        public Vector2 speed;

        public MovingAnimation (Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base (image, position, color, frames)
        {
            this.speed = speed;
            this.frames = frames;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
