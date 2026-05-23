using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Obstactle
{
    public class SquareBlock : Obstacle
    {
        public SquareBlock(int x, int y) : base(x, y, 80, 80) { }

        public override void Draw()
        {
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 80, 80, Color.White);
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 78, 78, Color.Black);
        }
    }
}
