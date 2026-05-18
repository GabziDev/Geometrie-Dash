using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using test_raylibs;

namespace test_raylibs.Tool
{
    internal class Debug
    {
        public void Draw()
        {
            Raylib.DrawText("FPS : " + Raylib.GetFPS(), 50, 50, 40, Color.Black);
            Raylib.DrawText("Résolution : " + Program.SCREEN_WIDTH + " x " + Program.SCREEN_HEIGHT, 50, 100, 20, Color.Black);
        }
    }
}