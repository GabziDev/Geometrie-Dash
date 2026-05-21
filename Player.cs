using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
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
            return new Rectangle (Position.X , Position.Y, Seize, Seize);
        }

        public Rectangle GetDisplay()
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
                Program.jump++;
            }
        }

        public void LevelCompleted()
        {
            moveSpeed = 0;
            levelCompleted = true;
            isGrounded = false;
            var xp = Position.X * 0.001;
            Program.xp += (int)xp;
            Program.inGame = false;
        }

        public void StartLevel()
        {
            Position = new Vector2(000, 730);
            moveSpeed = 250;
            levelCompleted = false;
            isGrounded = true;
        }

        public void Death()
        {
            var xp = Position.X * 0.001;
            Program.xp += (int)xp;
            Program.attemps++;
            Position = new Vector2(0, 730);
        }

        public void Draw()
        {
           Raylib.DrawRectangleRec(GetDisplay(), Color.Blue);
        }
    }
}