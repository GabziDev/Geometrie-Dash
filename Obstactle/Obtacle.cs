using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Obstactle
{
    public abstract class Obtacle
    {
        public Rectangle Rect;

        public Obtacle(float x, float y, float w, float h)
        {
            Rect = new Rectangle(x, y, w, h);
        }

        public abstract void Draw();

        public Rectangle GetRect()
        {
            return new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }
    }
}
