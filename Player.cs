using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs
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
            return new Rectangle (Position.X, Position.Y, Seize, Seize);
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
            }
        }

        public void LevelCompleted()
        {
            moveSpeed = 0;
            levelCompleted = true;
            isGrounded = false;
        }

        public void Death()
        {
           Position = new Vector2(100, 730);
           Program.attemps++;
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 80, 80, Color.Blue);
            Raylib.DrawRectangle((int)Position.X + 8, (int)Position.Y + 2, 70, 70, Color.Blue);
        }
    }
}