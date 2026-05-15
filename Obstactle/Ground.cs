using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs.Obstactle
{
    internal class Ground : Obtacle
    {
        public Ground(int x, int y) : base(x, y, 10000, 800) { }

        public override void Draw()
        {
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 10000, 800, Color.White);
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 10000, 800, Color.Black);
        }
    }
}
