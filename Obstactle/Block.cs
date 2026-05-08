using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Obstactle
{
    internal abstract class Block
    {
        public Rectangle Rect;

        public Block(float x, float y, float w, float h)
        {
            Rect = new Rectangle(x, y, w, h);
        }

        public abstract void Draw(int camera);

        public Rectangle GetRect(int camera)
        {
            return new Rectangle(Rect.X - camera, Rect.Y, Rect.Width, Rect.Height);
        }
    }
}
