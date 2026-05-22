using Raylib_cs;
using System.Numerics;
using test_raylibs.Managers;

namespace test_raylibs.Entities
{
    public class Player
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public bool isGrounded = false;

        public float Seize = 80;

        float gravity = -1800f;
        float moveSpeed = 250;

        public bool levelCompleted = false;

        public Rectangle GetRect()
        {
            return new Rectangle (Position.X , Position.Y, Seize, Seize);
        }

        public Rectangle GetDeathZone()
        {
            return new Rectangle(Position.X + 8, Position.Y + 2, 70, 70);
        }

        public void Update(float dt)
        {
            Velocity.Y += gravity * dt;
            Position.Y -= Velocity.Y * dt;

            Position.X += moveSpeed * dt;

            int groundY = 730;

            if (Position.Y >= groundY)
            {
                Position.Y = groundY;
                Velocity.Y = 0;
                isGrounded = true;
            }
            
            if (Raylib.IsKeyDown(KeyboardKey.Space) && isGrounded && !levelCompleted)
            {
                Velocity.Y = 700;
                GameManager.Instance.Jump++;
            }
        }

        public void LevelCompleted()
        {
            moveSpeed = 0;
            levelCompleted = true;
            isGrounded = false;
            var xp = Position.X * 0.001;
            GameManager.Instance.Xp += (int)xp;
        }

        public void StartLevel()
        {
            Console.WriteLine(GameManager.Instance.BgColor);
            Position = new Vector2(000, 730);
            moveSpeed = 250;
            levelCompleted = false;
            isGrounded = true;
        }

        public void Death()
        {
            var xp = Position.X * 0.001;
            GameManager.Instance.Xp += (int)xp;
            GameManager.Instance.Attempts++;
            Position = new Vector2(0, 730);
        }

        public void Draw()
        {
           Raylib.DrawRectangleRec(GetRect(), Color.Red);
        }
    }
}