using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs.Obstactle
{
    public class Spike : Obtacle
    {
        public Spike(float x, float y) : base(x, y, 80, 80) 
        {
            Rect = new Rectangle(x +30, y + 10, 20, 20);
        }

        public override void Draw()
        {
            Vector2 pos1 = new Vector2(Rect.X + 80, Rect.Y + 80);
            Vector2 pos2 = new Vector2(Rect.X + 40, Rect.Y);
            Vector2 pos3 = new Vector2(Rect.X, Rect.Y + 80);

            Raylib.DrawTriangle(pos1, pos2, pos3, Color.Blue);

            //spik hit box
            Raylib.DrawRectangle(Convert.ToInt32(Rect.X) + 30, Convert.ToInt32(Rect.Y), 20, 20, Color.Red);
        }
    }
}