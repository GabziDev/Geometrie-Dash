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
        Button btnSkin = new Button(360, 540, Color.Brown, "aaa");
        Button btnPlay = new Button(600, 540, Color.Brown, "aaa");
        Button btnSetting = new Button(840, 540, Color.Brown, "aaa");

        public string Update(float dt)
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
            return "Menu";
        }

        public void Draw(float dt)
        {
            Raylib.DrawText("Géometrie dash", 960 , 1080 / 4, 40, Color.Black);

            
            btnPlay.Draw();
            btnSetting.Draw();
            btnSkin.Draw();
        }
    }
}