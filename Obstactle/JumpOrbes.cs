using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Obstactle
{
    public class JumpOrbes : Obstacle
    {
        public JumpOrbes(int x, int y) : base(x, y, 80, 80) { 

        }

        public Rectangle GetRect()
        {
            return new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }

        public override void Draw()
        {
            Raylib.DrawCircle((int)Rect.X, (int)Rect.Y, 20, Color.Yellow);
            Raylib.DrawCircle((int)Rect.X, (int)Rect.Y, 15, Program.bgColor);
            Raylib.DrawCircle((int)Rect.X, (int)Rect.Y, 10, Color.Yellow);
        }
    }
}