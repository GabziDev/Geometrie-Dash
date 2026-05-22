using Raylib_cs;
using System;
using System.Numerics;

namespace test_raylibs.Obstactle
{
    public class Spike : Obstacle
    {
        private Rectangle _hitbox;

        public Spike(int x, int y) : base(x, y, 80, 80)
        {
            Rect = new Rectangle(x, y, 80, 80);

            float hbWidth = 16f;
            float hbHeight = 35f;

            _hitbox = new Rectangle(
                Rect.X + (Rect.Width / 2f) - (hbWidth / 4f),
                Rect.Y + (Rect.Height / 2f) - (hbHeight / 4f),
                hbWidth,
                hbHeight
            );
        }

        public bool CheckCollision(Rectangle playerRect)
        {
            return Raylib.CheckCollisionRecs(playerRect, _hitbox);
        }

        public Rectangle GetHitbox()
        {
            return _hitbox;
        }

        public override void Draw()
        {
            // visuel du spike
            Vector2 pos1 = new Vector2(Rect.X, Rect.Y + Rect.Height);
            Vector2 pos2 = new Vector2(Rect.X + Rect.Width / 2f, Rect.Y);
            Vector2 pos3 = new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height);
            Raylib.DrawTriangle(pos3, pos2, pos1, Color.Black);
            Raylib.DrawLine((int)pos1.X, (int)pos1.Y, (int)pos2.X, (int)pos2.Y, Color.Red);

            // hitbox debug
            if (Program.debug)
            {
                Raylib.DrawRectangleRec(_hitbox, new Color(255, 0, 0, 120));
            }
            
        }
    }
}