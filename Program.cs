using Raylib_cs;
using System.Numerics;

class Program
{
    static void Main()
    {
        //init
        Raylib.InitWindow(800, 600, "Géometrie dash");
        Raylib.SetTargetFPS(60);

        int playerX = 460;
        int playerY = 100;

        int camera = 0;
        int attemps = 0;

        int screenWitdh = Raylib.GetScreenWidth();                     
        int screenHeight = Raylib.GetScreenHeight();


        Console.WriteLine("The windows do " + screenHeight + " + " + screenHeight);

        //loop
        while (!Raylib.WindowShouldClose())
        {
            camera += 5;

            // Update (logique)
            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                playerY += 10;
            }

            // Draw (affichage)
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.DrawText("Géometrie dash", screenWitdh /2 - camera, screenHeight / 4, 40, Color.Black);
            Raylib.DrawText("Attemps : " + attemps, screenWitdh / 2 - camera, screenHeight / 4 + 50, 20, Color.Black);

            //dessiner des element
            DrawGround();
            drawPlayer(playerY, playerX);
            drawLevel1(camera);

            Raylib.EndDrawing();
        }
        
        // ----- Element ----- //

        //sol
        void DrawGround()
        {
            int groundY = screenHeight - 100;

            Raylib.DrawRectangle(0, groundY, screenWitdh, 100, Color.Red);
            Raylib.DrawRectangle(0, groundY, screenWitdh, 4, Color.Black);
        }

        //player
        void drawPlayer(int x, int y)
        {
            Raylib.DrawRectangle(x, y, 40, 40, Color.Blue);
        }

        //level
        void drawLevel1(int camera)
        {
            Raylib.DrawRectangle(500 - camera, 460, 40, 40, Color.Blue);
            Raylib.DrawRectangle(540 - camera, 460, 40, 40, Color.Blue);
            Raylib.DrawRectangle(540 - camera, 420, 40, 40, Color.Blue);
        }

        //prefabs
        void drawCube(int x, int y, Color c)
        {
            Raylib.DrawRectangle(x, y, 40, 40, c);
        }
            





        Raylib.CloseWindow();
    }
}