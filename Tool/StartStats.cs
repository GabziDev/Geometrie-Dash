using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using test_raylibs;

namespace test_raylibs.Tool
{
    internal class StartStats
    {
        public StartStats() { }

        public void Draw()
        {
            Raylib.DrawText("Géometrie dash", 200, 400, 40, Color.Black);
            Raylib.DrawText("Attemps : " + Program.attemps, 200, 450, 20, Color.Black);
        }
    }
}