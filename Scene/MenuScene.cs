using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using test_raylibs.Composant;

namespace test_raylibs.Scene
{
    public class MenuScene
    {
        Button btn = new Button(360, 540, Color.Brown, "aaa");

        public string Update(float dt)
        {
            if (btn.IsClicked()) return "LevelDebug";
            return "Menu";
        }

        public void Draw(float dt)
        {
            Raylib.DrawText("Géometrie dash", 1920 / 4, 1080 / 4, 40, Color.Black);

            
            btn.Draw();
        }
    }
}
