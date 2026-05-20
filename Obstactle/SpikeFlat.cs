using Raylib_cs;
using System.Numerics;

namespace test_raylibs.Obstactle
{
    public class SpikeFlat : Obstacle
    {
        private Rectangle _hitbox;

        public SpikeFlat(int x, int y) : base(x, y, 80, 40)
        {
            Rect = new Rectangle(x, y, 80, 40); 

            float hbWidth = 16f;
            float hbHeight = 18f;

            _hitbox = new Rectangle(
                Rect.X + (Rect.Width / 2f) - (hbWidth / 4f),
                Rect.Y + (Rect.Height / 2f) - (hbHeight / 4f),
                hbWidth,
                hbHeight
            );
        }

        public Rectangle GetHitbox()
        {
            return _hitbox;
        }

        public override void Draw()
        {
            Vector2 pos1 = new Vector2(Rect.X, Rect.Y + Rect.Height);
            Vector2 pos2 = new Vector2(Rect.X + Rect.Width / 2f, Rect.Y);
            Vector2 pos3 = new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height);
            Raylib.DrawTriangle(pos3, pos2, pos1, Color.Black);

            if (Program.debug)
            {
                Raylib.DrawRectangleRec(_hitbox, new Color(255, 0, 0, 120));
                Raylib.DrawRectangleLinesEx(_hitbox, 2, Color.Red);
            }
        }
    }
}