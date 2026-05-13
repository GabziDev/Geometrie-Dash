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
            float gravity = -30;

            Velocity.Y += gravity;
            Position.Y -= Velocity.Y * dt;

            Position.X += 3;

            int groundY = 730;


            if (Position.Y >= groundY)
            {
                Position.Y = groundY;
                Velocity.Y = 0;
                isGrounded = true;
            }
            

            if (Raylib.IsKeyDown(KeyboardKey.Space) && isGrounded)
            {
                Velocity.Y = 650;
            }
        }

        public void Death()
        {
            Position = new Vector2(100, 730);
           Program.attemps++;
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 80, 80, Color.Red);
            Raylib.DrawRectangle((int)Position.X + 8, (int)Position.Y + 2, 70, 70, Color.Blue);
        }
    }
}