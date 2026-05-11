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
        }
    }
}
