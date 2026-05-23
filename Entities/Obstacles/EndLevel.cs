using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Obstactle
{
    public class EndLevel : Obstacle
    {
        public EndLevel(int x, int y) : base(x, y, 80, 8000) { }

        public override void Draw()
        {
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 8000, 8000, Color.Red);
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 2, 8000, Color.Black);
        }
    }
}