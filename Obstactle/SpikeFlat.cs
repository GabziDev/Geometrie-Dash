using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs.Obstactle
{
    public class SpikeFlat : Obstacle
    {
        public SpikeFlat(int x, int y) : base(x, y, 80, 80)
        {
            Rect = new Rectangle(x, y + 40, 80, 40); 
        }

        public override void Draw()
        {
            Vector2 pos1 = new Vector2(Rect.X + 80, Rect.Y + 40); 
            Vector2 pos2 = new Vector2(Rect.X + 40, Rect.Y);    
            Vector2 pos3 = new Vector2(Rect.X, Rect.Y + 40);    

            Raylib.DrawTriangle(pos1, pos2, pos3, Color.Blue);

            //hitbox
            Raylib.DrawRectangle(Convert.ToInt32(Rect.X) + 20, Convert.ToInt32(Rect.Y) - 40, 20, 20, Color.Red);
        }
    }
}
