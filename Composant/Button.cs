using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace test_raylibs.Composant
{
    public class Button
    {
        public int x;
        public int y;
        public Color color;
        public string link;
        //

        static int screenWitdh = 1920;
        static int screenHeight = 1080;

        Rectangle playButton = new Rectangle(360, screenHeight / 2, 80, 80);

        public bool IsClicked()
        {
            Vector2 mouse = Raylib.GetMousePosition();
            Rectangle rect = new Rectangle(x, y, 80, 80);

            return Raylib.CheckCollisionPointRec(mouse, rect)
                && Raylib.IsMouseButtonPressed(MouseButton.Left);
        }

        public Button(int x, int y, Color color, string link)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.link = link;
        }


        public void Draw()
        {
            Raylib.DrawRectangle(x, y, 80, 80, Color.Red);
            Raylib.DrawRectangleRec(playButton, color);


            Raylib.DrawTriangle(
                new Vector2(playButton.X + 20, playButton.Y + 20),
                new Vector2(playButton.X + 20, playButton.Y + 60),
                new Vector2(playButton.X + 60, playButton.Y + 40),
                Color.Blue
            );

            
        }
    }
}
