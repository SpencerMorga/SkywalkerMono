using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saiyuki_VS_Skywalker
{
    class Labels
    {
        public Color color;
        public Vector2 position;
        public SpriteFont font;
        public string text;
        public Labels(Color color, Vector2 position, SpriteFont font, string text)
        {
            this.font = font;
            this.color = color;
            this.position = position;
            this.text = text;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(font, text, position, color);
        }
    }
}
