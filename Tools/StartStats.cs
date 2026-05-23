using Raylib_cs;
using test_raylibs.Managers;

namespace test_raylibs.Tool
{
    internal class StartStats
    {
        public void Draw()
        {
            Raylib.DrawText("Géometrie dash", 200, 400, 40, Color.Black);
            Raylib.DrawText("Attemps : " + GameManager.Instance.Attempts, 200, 450, 20, Color.Black);
        }
    }
}