using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs.Obstactle
{
    internal class SpikeFlat : Block
    {
        public SpikeFlat(float x, float y) : base(x, y, 80, 80)
        {
            Rect = new Rectangle(x, y + 40, 80, 40); 
        }

        public override void Draw(int camera)
        {
            Vector2 pos1 = new Vector2(Rect.X + 80 - camera, Rect.Y + 40); 
            Vector2 pos2 = new Vector2(Rect.X + 40 - camera, Rect.Y);    
            Vector2 pos3 = new Vector2(Rect.X - camera, Rect.Y + 40);    

            Raylib.DrawTriangle(pos1, pos2, pos3, Color.Blue);

            //hitbox
            Raylib.DrawRectangle(Convert.ToInt32(Rect.X) - camera + 20, Convert.ToInt32(Rect.Y) - 40, 20, 20, Color.Red);
        }
    }
}
