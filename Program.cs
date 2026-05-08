using Raylib_cs;
using System.Numerics;
using test_raylibs;
using test_raylibs.Obstactle;

class Program
{
    static void Main()
    {
        //init

        int display = Raylib.GetCurrentMonitor();

        //int screenWitdh = Raylib.GetMonitorWidth(display);
        //int screenHeight = Raylib.GetMonitorHeight(display);

        int screenWitdh = 1920;
        int screenHeight = 1080;


        Raylib.InitWindow(screenWitdh, screenHeight, "Géometrie dash");
        Console.WriteLine("L'écran fais " + screenWitdh + " X " + screenHeight);
        Raylib.SetTargetFPS(60);

        float playerX = 100;
        float playerY = 460;
        
        int camera = 0;
        int attemps = 0;

        Scene scene = Scene.Menu;

        Player player = new Player();
        player.Position = new Vector2(100, 460);

        //init level items
        List<Block> blocks = new List<Block>()
        {
            new SquareBlock(500, 730),
            new SquareBlock(580, 730),
            new SquareBlock(580, 650),
            new Spike(900, 730)
        };

        //btn play
        Rectangle playButton = new Rectangle(360, screenHeight / 2, 80, 80);
        bool hover;

        //loop
        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            //UPDATE
            if (scene != Scene.Menu)
            {
                camera += 5;
                player.Update(dt);
            }

            player.isGrounded = false;


            foreach (var block in blocks)
            {
                if (Raylib.CheckCollisionRecs(player.GetRect(), block.GetRect(camera)))
                {
                    Console.WriteLine("Cllisomn");
                    //  player.Position = new Vector2(100, 730);
                }

                if (Raylib.CheckCollisionRecs(player.GetDeathZone(), block.GetRect(camera)))
                {
                    Console.WriteLine("Mort");
                    attemps++;
                    player.Position = new Vector2(100, 730);
                    camera = 0;
                }

                Rectangle blockRect = block.GetRect(camera);

                if (Raylib.CheckCollisionRecs(player.GetRect(), blockRect))
                {
                    if (player.Velocity.Y < 0)
                    {
                        player.Position.Y = blockRect.Y - player.GetRect().Height;

                        player.Velocity.Y = 0;

                        player.isGrounded = true;
                    }
                }
            }

            //logic menu
            Vector2 mouse = Raylib.GetMousePosition();

            hover = Raylib.CheckCollisionPointRec(mouse, playButton);

            if (hover && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                scene = Scene.LevelDebug;
            }


            //DRAW
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            switch (scene)
            {
                case Scene.Menu:
                    DrawSceneMenu();
                    break;
                case Scene.LevelDebug:
                    DrawnLevelDebug(camera);
                    foreach (var block in blocks)
                    {
                        block.Draw(camera);
                    }
                    player.Draw();
                    break;
            }

            DrawGround();

            Raylib.EndDrawing();
        }

        // ----- Scene ----- //

        //menu
        void DrawSceneMenu()
        {
            Raylib.DrawText("Géometrie dash", screenWitdh / 4, screenHeight / 4, 40, Color.Black);

            int y = screenHeight / 2;

            // 3 boutons centrés "à la main"
            Raylib.DrawRectangle(360, y, 80, 80, Color.Blue);
            Raylib.DrawRectangle(600, y, 80, 80, Color.Blue);
            Raylib.DrawRectangle(840, y, 80, 80, Color.Blue);

            // bouton play
            Color color = Color.Blue;

            Raylib.DrawRectangleRec(playButton, color);

            Raylib.DrawTriangle(
                new Vector2(playButton.X + 20, playButton.Y + 20),
                new Vector2(playButton.X + 20, playButton.Y + 60),
                new Vector2(playButton.X + 60, playButton.Y + 40),
                Color.White
            );
        }

        void DrawnLevelDebug(int camera)
        {
            Raylib.DrawText("Géometrie dash", screenWitdh / 2 - camera, screenHeight / 4, 40, Color.Black);
            Raylib.DrawText("Attemps : " + attemps, screenWitdh / 2 - camera, screenHeight / 4 + 50, 20, Color.Black);
        }


        // ----- Element ----- //

        //sol
        void DrawGround()
        {
            int groundY = screenHeight * 3 / 4;

            Raylib.DrawRectangle(0, groundY, screenWitdh, 300, Color.Red);
            Raylib.DrawRectangle(0, groundY, screenWitdh, 4, Color.Black);
        }

        Raylib.CloseWindow();
    }

    enum Scene
    {
        Menu,
        LevelDebug,
        Level_1
    }
}


