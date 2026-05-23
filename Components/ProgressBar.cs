using Raylib_cs;

namespace test_raylibs.Components
{
    internal class ProgressBar
    {
        public ProgressBar() { }

        public void Draw(float pourcentage)
        {
            int maxSize = Constants.SCREEN_WIDTH - 400;

            //bordure
            Raylib.DrawRectangle((int)(Constants.SCREEN_HEIGHT * 0.25), (int)(Constants.SCREEN_HEIGHT * 0.05), maxSize + 4, 20, Color.Black);

            //sous bar
            Raylib.DrawRectangle((int)(Constants.SCREEN_HEIGHT * 0.25) + 2, (int)(Constants.SCREEN_HEIGHT * 0.05) + 2, maxSize, 16, Color.Brown);

            //porcentage
            int progressWidth = (int)(maxSize * (pourcentage / 100f));
            Raylib.DrawRectangle((int)(Constants.SCREEN_HEIGHT * 0.25) + 2, (int)(Constants.SCREEN_HEIGHT * 0.05) + 2, progressWidth, 16, Color.Red);

            Raylib.DrawText(Math.Round(pourcentage) + "%", Constants.SCREEN_HEIGHT - 100, (int)(Constants.SCREEN_HEIGHT * 0.05) + 50, 40, Color.Black);
        }
    }
}