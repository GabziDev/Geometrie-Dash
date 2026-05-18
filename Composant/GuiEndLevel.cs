using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Composant
{
    public class GuiEndLevel
    {

        public void Draw()
        {
            int modalWidth = Program.SCREEN_WITDH / 2;
            int modalHeight = Program.SCREEN_HEIGHT / 2;

            int modalX = (Program.SCREEN_WITDH - modalWidth) / 2;
            int modalY = (Program.SCREEN_HEIGHT - modalHeight) / 2;

            Raylib.DrawRectangle(modalX, modalY, modalWidth, modalHeight, Color.Green);
            Raylib.DrawText("Level Completed", modalX + modalX / 2, modalY + modalY / 2, 40,Color.Black);
        }

    }
}
