using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using test_raylibs.Composant;

namespace test_raylibs.Scene
{
    public class StatsScene
    {
        static float w = Program.SCREEN_WIDTH;
        static float h = Program.SCREEN_HEIGHT;

        public void Draw()
        {
            Raylib.DrawText("Statistiques", (int)w/2 , 1080 / 4, 40, Color.Black);

        }
    }
}