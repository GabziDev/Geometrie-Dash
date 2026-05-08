using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs.Obstactle
{
    internal class Spike : Block
    {
        public Spike(float x, float y) : base(x, y, 80, 80) { }

        public override void Draw(int camera)
        {
            Vector2 pos1 = new Vector2(Rect.X - camera, Rect.Y + 80);
            Vector2 pos2 = new Vector2(Rect.X + 40 - camera, Rect.Y);
            Vector2 pos3 = new Vector2(Rect.X + 80 - camera, Rect.Y + 80);

            Raylib.DrawTriangle(pos1, pos2, pos3, Color.Red);
        }
    }
}
