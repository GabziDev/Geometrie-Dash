using Raylib_cs;

namespace test_raylibs.Obstactle
{
    public class JumpPad : Obstacle
    {
        public JumpPad(int x, int y) : base(x, y, 80, 80) { 

        }

        public override void Draw()
        {
            Raylib.DrawCircle((int)Rect.X, (int)Rect.Y +80, 20, Color.Yellow);
        }
    }
}