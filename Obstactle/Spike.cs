using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs.Obstactle
{
    internal class Spike : Block
    {
        public Spike(float x, float y) : base(x, y, 80, 80) 
        {
            Rect = new Rectangle(x +20, y, 20, 20);
        }

        public override void Draw(int camera)
        {
            Vector2 pos1 = new Vector2(Rect.X + 80 - camera, Rect.Y + 80); // bas droite
            Vector2 pos2 = new Vector2(Rect.X + 40 - camera, Rect.Y);       // sommet
            Vector2 pos3 = new Vector2(Rect.X - camera, Rect.Y + 80);       // bas gauche

            Raylib.DrawTriangle(pos1, pos2, pos3, Color.Blue);

            //spik hit box
            Raylib.DrawRectangle(Convert.ToInt32(Rect.X) -camera + 20, Convert.ToInt32(Rect.Y), 20, 20, Color.Red);
        }
    }
}
