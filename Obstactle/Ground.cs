using Raylib_cs;
using test_raylibs.Managers;

namespace test_raylibs.Obstactle
{
    internal class Ground : Obstacle
    {
        public Ground(int x, int y) : base(x, y, 10000, 800) { }

        public override void Draw()
        {
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 10000, 800, GameManager.Instance.BgColor);
            Raylib.DrawRectangle((int)Rect.X, (int)Rect.Y, 10000, 800, Color.Black);
        }
    }
}
