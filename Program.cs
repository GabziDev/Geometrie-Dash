using Raylib_cs;
using System.Numerics;
using test_raylibs;
using test_raylibs.Composant;
using test_raylibs.Obstactle;
using test_raylibs.Scene;
using test_raylibs.Tool;

class Program
{
    private static Player player;
    public static int attemps;

    public const int SCREEN_WITDH = 1920;
    public const int SCREEN_HEIGHT = 1080;

    static void Main()
    {
        //jouaueur
        player = new Player();
        player.Position = new Vector2(100, 460);

        //test camera
        Camera2D cam = new Camera2D();
        cam.Target = new Vector2(player.Position.X, player.Position.Y);
        cam.Offset = new Vector2(SCREEN_WITDH / 2f, SCREEN_HEIGHT / 2f);
        cam.Zoom = 1f;

        //init

        int display = Raylib.GetCurrentMonitor();
        
        StartStats startStat = new StartStats();
        Debug debug = new Debug();

        //int screenWitdh = Raylib.GetMonitorWidth(display);
        //int screenHeight = Raylib.GetMonitorHeight(display);

        attemps = 0;

        Scene scene = Scene.Menu;
        MenuScene menuScene = new MenuScene();

        Raylib.InitWindow(SCREEN_WITDH, SCREEN_HEIGHT, "Géometrie dash");
        Raylib.SetTargetFPS(60);


        //init level items
        List<Obtacle> blocks = new List<Obtacle>()
        {

            new Spike(900, 730),
            new SquareBlock(500, 730),
            new SquareBlock(580, 730),
            new SquareBlock(580, 650),
            new SpikeFlat(980, 730),
            new Ground(0, 810)
        };


        //loop
        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                cam.Rotation--;
            }

            if (scene == Scene.Menu)
            {
                string result = menuScene.Update(dt);
                if (result == "LevelDebug") scene = Scene.LevelDebug;
            }

            if (scene != Scene.Menu)
            {
                player.Update(dt);
                cam.Target = player.Position;
            }

            player.isGrounded = false;


            foreach (var block in blocks)
            {
                if (Raylib.CheckCollisionRecs(player.GetRect(), block.GetRect()))
                {
                    Console.WriteLine("Cllisomn");
                }

                if (Raylib.CheckCollisionRecs(player.GetDeathZone(), block.GetRect()))
                {
                    Death();
                }

                //detection de spik
                if (Raylib.CheckCollisionRecs(player.GetDeathZone(), block.GetRect()))
                {
                    Death();
                }

                Rectangle blockRect = block.GetRect();

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

            //DRAW
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);


            switch (scene)
            {
                case Scene.Menu: 
                    menuScene.Draw(dt);
                    break;
                case Scene.LevelDebug:
                    startStat.Draw();
                    if (Raylib.IsKeyDown(KeyboardKey.Q))
                    {
                        debug.Draw();
                    }

                    Raylib.BeginMode2D(cam);
                    foreach (var block in blocks)
                    {
                        block.Draw();
                    }
                    player.Draw();
                    Raylib.EndMode2D();
                    break;
            }

            //DrawGround();
            cam.Target = player.Position;

            Raylib.EndDrawing();
        }


        // ----- Element ----- //

        /*
        //sol
        void DrawGround()
        {
            int groundY = SCREEN_HEIGHT * 3 / 4;

            Raylib.DrawRectangle(0, groundY, 100, 300, Color.Red);
            Raylib.DrawRectangle(0, groundY, 100, 4, Color.Black);
        }

        Raylib.CloseWindow();
        */
    }

    enum Scene
    {
        Menu,
        LevelDebug,
        Level_1
    }

    static void Death()
    {
        player.Position = new Vector2(100, 730);
        attemps++;
    }
}