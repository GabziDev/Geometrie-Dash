using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs
{
    internal class Player
    {
        public Vector2 Position;
        public Vector2 Velocity;
        bool isGrounded = false;

        public float Seize = 40;

        public Rectangle GetRect()
        {
            return new Rectangle (Position.X, Position.Y, Seize, Seize);
        }

        public void Update(float dt)
        {
            float groundY = 460;
            float gravity = -9.81f * 30;

            Velocity.Y += gravity * dt;
            Position.Y -= Velocity.Y * dt;

            if (Position.Y >= groundY)
            {
                Position.Y = groundY;
                Velocity.Y = 0;
                isGrounded = false;
            }
            else
            {
                isGrounded = true;
            }

            if (Raylib.IsKeyDown(KeyboardKey.Space) && !isGrounded)
            {
                Velocity.Y = 200;
            }
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 40, 40, Color.Blue);
        }
    }
}