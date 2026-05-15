using Raylib_cs;
using System.Numerics;
using test_raylibs;
using test_raylibs.Levels;
using test_raylibs.Scene;
using test_raylibs.Tool;
using test_raylibs.Enum;

class Program
{
    public static int attemps;
    public static string currentLevel = "menu";
    public static Color bgColor = Color.White;

    public const int SCREEN_WITDH = 1920;
    public const int SCREEN_HEIGHT = 1080;

    static void Main()
    {
        int frame = 0;

        //joueur
        Player player = new Player();
        player.Position = new Vector2(100, 730);
        
        //camera
        Camera2D cam = new Camera2D();
        cam.Target = new Vector2(player.Position.X, player.Position.Y);
        cam.Offset = new Vector2(SCREEN_WITDH / 3f, SCREEN_HEIGHT / 2f);
        cam.Zoom = 1f;

        //level 
        Level level = new Level();
        Debug debug = new Debug();

        Scene scene = Scene.Menu;
        MenuScene menuScene = new MenuScene();

        //load windows
        Raylib.InitWindow(SCREEN_WITDH, SCREEN_HEIGHT, "Géometrie dash");
        Raylib.SetTargetFPS(60);

        // -- BOUCLE -- //
        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();

            //logique du menu
            if (scene == Scene.Menu)
            {
                string result = menuScene.Update();

                if (result != null)
                {
                    level.Load(result);
                    scene = Enum.Parse<Scene>(result);
                }
            }
            else
            {
                player.Update(dt);
                cam.Target = player.Position;
            }

            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                cam.Rotation--;
            }

            player.isGrounded = false;


            //DRAW
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Program.bgColor);


            if (scene == Scene.Menu)
            {
                menuScene.Draw();
            }
            else
            {
                if (Raylib.IsKeyDown(KeyboardKey.Q))
                {
                    debug.Draw();
                }

                Raylib.BeginMode2D(cam);
                player.Draw();
                level.Update(player);
                level.Draw();
                Raylib.EndMode2D();
            }

            cam.Target = player.Position;

            Raylib.EndDrawing();
        }
    }
}