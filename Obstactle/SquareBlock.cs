using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Obstactle
{
    internal class SquareBlock : Block
    {
        public SquareBlock(float x, float y) : base(x, y, 80, 80) { }

        public override void Draw(int camera)
        {
            Raylib.DrawRectangle((int)Rect.X - camera, (int)Rect.Y, 80, 80, Color.White);
            Raylib.DrawRectangle((int)Rect.X - camera, (int)Rect.Y, 78, 78, Color.Black);
        }
    }
}
