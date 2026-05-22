using Raylib_cs;

namespace test_raylibs.Tool
{
    internal class Debug
    {
        public void Draw()
        {
            Raylib.DrawText("FPS : " + Raylib.GetFPS(), 50, 50, 40, Color.Black);
            Raylib.DrawText("Résolution : " + Constants.SCREEN_WIDTH + " x " + Constants.SCREEN_HEIGHT, 50, 100, 20, Color.Black);
        }
    }
}