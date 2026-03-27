using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Obstactle
{
    internal class Block
    {
        public Rectangle Rect;

        public Block(float x, float y)
        {
            Rect = new Rectangle((int)x, (int)y, 40, 40);
        }

        public void Draw(int camera)
        {
            Raylib.DrawRectangle((int)Rect.X - camera, (int)Rect.Y + 2, 40, 40, Color.White);
            Raylib.DrawRectangle((int)Rect.X - camera, (int)Rect.Y+2, 38, 38, Color.Black);
            Raylib.DrawRectangleGradientV((int)Rect.X - camera, (int)Rect.Y, 38, 38, Color.Black, Color.Magenta);
        }

        public Rectangle GetRect(int camera)
        {
            return new Rectangle(Rect.X - camera, Rect.Y, Rect.Width, Rect.Height);
        }
    }
}
