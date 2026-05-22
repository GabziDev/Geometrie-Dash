using Raylib_cs;
using test_raylibs.Managers;

namespace test_raylibs.Obstactle
{
    public class JumpOrbes : Obstacle
    {
        public JumpOrbes(int x, int y) : base(x, y, 80, 80) { 

        }

        public override void Draw()
        {
            Raylib.DrawCircle((int)Rect.X, (int)Rect.Y, 20, Color.Yellow);
            Raylib.DrawCircle((int)Rect.X, (int)Rect.Y, 15, GameManager.Instance.BgColor);
            Raylib.DrawCircle((int)Rect.X, (int)Rect.Y, 10, Color.Yellow);
        }
    }
}