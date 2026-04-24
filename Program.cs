using Raylib_cs;
using System.Numerics;
using test_raylibs;
using test_raylibs.Obstactle;

class Program
{
    static void Main()
    {
        //init
        Raylib.InitWindow(800, 600, "Géometrie dash");
        Raylib.SetTargetFPS(60);

        float playerX = 100;
        float playerY = 460;
        

        int camera = 0;
        int attemps = 0;

        int screenWitdh = Raylib.GetScreenWidth();                     
        int screenHeight = Raylib.GetScreenHeight();

        Scene scene = Scene.Menu;

        Player player = new Player();
        player.Position = new Vector2(100, 460);

        //init level items
        List<Block> blocks = new List<Block>()
        {
            new Block(500, 460),
            new Block(540, 460),
            new Block(540, 420)
        };

        //btn play
        Rectangle playButton = new Rectangle(360, screenHeight / 2, 80, 80);
        bool hover;

        //loop
        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            //UPDATE
            camera += 5;
            player.Update(dt);

            foreach (var block in blocks)
            {
                if (Raylib.CheckCollisionRecs(player.GetRect(), block.GetRect(camera)))
                {
                    Console.WriteLine("Cllisomn");
                    player.Position = new Vector2(100, 400);
                }

                if (Raylib.CheckCollisionRecs(player.GetDeathZone(), block.GetRect(camera)))
                {
                    Console.WriteLine("Mort");
                    //tuer le joueur
                    attemps ++;
                    player.Position = new Vector2(100, 460);
                    camera = 0;
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

            // boutons décoratifs (optionnel)
            Raylib.DrawRectangle(260, screenHeight / 2, 80, 80, Color.Blue);
            Raylib.DrawRectangle(360, screenHeight / 2, 80, 80, Color.Blue);
            Raylib.DrawRectangle(460, screenHeight / 2, 80, 80, Color.Blue);

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

            Raylib.DrawRectangle(500 - camera, 460, 40, 40, Color.Blue);
            Raylib.DrawRectangle(540 - camera, 460, 40, 40, Color.Blue);
            Raylib.DrawRectangle(540 - camera, 420, 40, 40, Color.Blue);
        }


        // ----- Element ----- //

        //sol
        void DrawGround()
        {
            int groundY = screenHeight - 100;

            Raylib.DrawRectangle(0, groundY, screenWitdh, 100, Color.Red);
            Raylib.DrawRectangle(0, groundY, screenWitdh, 4, Color.Black);
        }


        //prefabs
        void drawCube(int x, int y, Color c)
        {
            Raylib.DrawRectangle(x, y, 40, 40, Color.Black);
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