// GuiEndLevel.cs
using Raylib_cs;
using System;

namespace test_raylibs.Composant
{
    public class GuiEndLevel
    {
        private int modalWidth = Constants.SCREEN_WIDTH / 2;
        private int modalHeight = Constants.SCREEN_HEIGHT / 2;
        private int modalX => (Constants.SCREEN_WIDTH - modalWidth) / 2;
        private int modalY => (Constants.SCREEN_HEIGHT - modalHeight) / 2;

        public Button btnMenu = new Button(Constants.SCREEN_WIDTH / 2 - 90, Constants.SCREEN_HEIGHT / 2 + 40, Color.DarkBlue, "menu", "Menu");
        public Button btnReplay = new Button(Constants.SCREEN_WIDTH / 2 + 90, Constants.SCREEN_HEIGHT / 2 + 40, Color.DarkGreen, "Level_1", "Rejouer");

        public string? Update()
        {
            if (btnReplay.IsClicked()) return btnReplay.link;
            if (btnMenu.IsClicked()) return btnMenu.link;
            return null;
        }

        public void Draw()
        {
            Raylib.DrawRectangle(modalX - 2, modalY - 2, modalWidth + 4, modalHeight + 4, Color.Black);
            Raylib.DrawRectangle(modalX, modalY, modalWidth, modalHeight, Color.Green);

            string title = "Level Completed!";
            int fontSize = 40;
            int titleW = Raylib.MeasureText(title, fontSize);
            Raylib.DrawText(title, modalX + (modalWidth - titleW) / 2, modalY + 40, fontSize, Color.Black);

            btnMenu.Draw();
            btnReplay.Draw();
        }
    }
}