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
        static float w = Program.SCREEN_WIDTH;
        static float h = Program.SCREEN_HEIGHT;

        Button btnSkin = new Button(Convert.ToInt32(w * 1f / 6f), (int)h /2, Color.Brown, "aaa");
        Button btnPlay = new Button(Convert.ToInt32(w * 1f / 2f), (int)h / 2, Color.Brown, "aaa");
        Button btnSetting = new Button(Convert.ToInt32(w * 5f / 6f), (int)h / 2, Color.Brown, "aaa");

        public string Update()
        {
            if (btnPlay.IsClicked())
            { 
                return "LevelDebug"; 
            }
            else if (btnSkin.IsClicked())
            {
                return "Shop";
            }
            else if (btnSetting.IsClicked())
            {
                return "Menu";
            }
            return null;
        }

        public void Draw()
        {
            Raylib.DrawText("Géometrie dash", (int)w/2 , 1080 / 4, 40, Color.Black);

            btnPlay.Draw();
            btnSetting.Draw();
            btnSkin.Draw();
        }
    }
}