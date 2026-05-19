// Button.cs
using Raylib_cs;
using System.Numerics;

namespace test_raylibs.Composant
{
    public class Button
    {
        public int x;
        public int y;
        public Color color;
        public string link;
        public string label;
        public const int btnWidth = 140;
        public const int btnHeight = 45;
        public const int btnFontSize = 22;

        public Button(int x, int y, Color color, string link, string label)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.link = link;
            this.label = label;
        }

        public bool IsClicked()
        {
            Vector2 mouse = Raylib.GetMousePosition();
            Rectangle rect = new Rectangle(x - btnWidth / 2, y - btnHeight / 2, btnWidth, btnHeight);

            return Raylib.CheckCollisionPointRec(mouse, rect)
                && Raylib.IsMouseButtonPressed(MouseButton.Left);
        }

        public void Draw()
        {
            int bx = x - btnWidth / 2;
            int by = y - btnHeight / 2;

            Raylib.DrawRectangle(bx, by, btnWidth, btnHeight, color);

            int textW = Raylib.MeasureText(label, btnFontSize);
            int textX = bx + (btnWidth - textW) / 2;
            int textY = by + (btnHeight - btnFontSize) / 2;

            Raylib.DrawText(label, textX, textY, btnFontSize, Color.White);
        }
    }
}