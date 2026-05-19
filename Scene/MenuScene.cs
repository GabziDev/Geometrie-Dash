using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
using test_raylibs.Composant;

namespace test_raylibs.Scene
{
    public class MenuScene
    {
        static float w = Program.SCREEN_WIDTH;
        static float h = Program.SCREEN_HEIGHT;

        Button btnSetting = new Button((int)(w * 1f / 5f), (int)(h / 2f), Color.Brown, "Setting", "Setting");
        Button btnShop = new Button((int)(w * 2f / 5f), (int)(h / 2f), Color.Brown, "Shop", "Shop");
        Button btnPlay = new Button((int)(w * 3f / 5f), (int)(h / 2f), Color.Brown, "LevelDebug", "Play");
        Button btnStats = new Button((int)(w * 4f / 5f), (int)(h / 2f), Color.Brown, "Stats", "Stats");

        public string Update()
        {
            if (btnPlay.IsClicked())
            { 
                return btnPlay.link; 
            }
            else if (btnShop.IsClicked())
            {
                return btnShop.link;
            }
            else if (btnSetting.IsClicked())
            {
                return btnSetting.link;
            }
            else if (btnStats.IsClicked())
            {
                return btnStats.link;
            }
            return null;
        }

        public void Draw()
        {
            string title = "Géometrie dash";
            int titleW = Raylib.MeasureText(title, 40);
            Raylib.DrawText(title, (Program.SCREEN_WIDTH - titleW) / 2, Program.SCREEN_HEIGHT / 4, 40, Color.Black);

            btnPlay.Draw();
            btnSetting.Draw();
            btnShop.Draw();
            btnStats.Draw();
        }
    }
}