using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using test_raylibs;

namespace test_raylibs.Tool
{
    internal class ProgressBar
    {
        public ProgressBar() { }

        public void Draw(float pourcentage)
        {
            int maxSize = Program.SCREEN_WIDTH - 400;


            //bordure
            Raylib.DrawRectangle((int)(Program.SCREEN_HEIGHT * 0.25), (int)(Program.SCREEN_HEIGHT * 0.05), maxSize + 4, 20, Color.Black);

            //sous bar
            Raylib.DrawRectangle((int)(Program.SCREEN_HEIGHT * 0.25) + 2, (int)(Program.SCREEN_HEIGHT * 0.05) + 2, maxSize, 16, Color.Brown);


            //porcentage
            int progressWidth = (int)(maxSize * (pourcentage / 100f));
            Raylib.DrawRectangle((int)(Program.SCREEN_HEIGHT * 0.25) + 2, (int)(Program.SCREEN_HEIGHT * 0.05) + 2, progressWidth, 16, Color.Red);

            Raylib.DrawText(pourcentage + "%", Program.SCREEN_HEIGHT - 100, (int)(Program.SCREEN_HEIGHT * 0.05) + 50, 40, Color.Black);
        }
    }
}