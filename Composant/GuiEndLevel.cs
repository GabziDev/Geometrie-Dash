using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Composant
{
    public class GuiEndLevel
    {

        public Button btnReplay = new Button(Program.SCREEN_WIDTH /2, Program.SCREEN_HEIGHT /2,Color.Blue, "menu");
        public Button btnMenu = new Button(Program.SCREEN_WIDTH / 2 + 100, Program.SCREEN_HEIGHT / 2, Color.Blue, "replay");

        public string Update()
        {
            if (btnReplay.IsClicked())
            {
                return btnReplay.link;
            }
            else if (btnMenu.IsClicked())
            {
                return btnMenu.link;
            }
            return null;
        }

        public void Draw()
        {
            int modalWidth = Program.SCREEN_WIDTH / 2;
            int modalHeight = Program.SCREEN_HEIGHT / 2;

            int modalX = (Program.SCREEN_WIDTH - modalWidth) / 2;
            int modalY = (Program.SCREEN_HEIGHT - modalHeight) / 2;

            Raylib.DrawRectangle(modalX -2, modalY - 2, modalWidth + 4, modalHeight + 4, Color.Black);
            Raylib.DrawRectangle(modalX, modalY, modalWidth, modalHeight, Color.Green);
            Raylib.DrawText("Level Completed", modalX + modalX / 2, modalY + modalY / 2, 40,Color.Black);

            btnReplay.Draw();
        }

    }
}
