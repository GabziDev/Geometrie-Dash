using Raylib_cs;
using System.Numerics;
using System.Text.Json;
using test_raylibs;
using test_raylibs.Composant;
using test_raylibs.Enum;
using test_raylibs.Levels;
using test_raylibs.Model;
using test_raylibs.Scene;
using test_raylibs.Services;
using test_raylibs.Tool;

class Program
{
    public static int attemps;
    public static string currentLevel = "menu";
    public static Color bgColor = Color.White;

    public const int SCREEN_WITDH = 1920;
    public const int SCREEN_HEIGHT = 1080;

    public static bool debug = true;
    public static bool inGame = false;

    public static bool running = true;

    static void Main()
    {

        //joueur
        Player player = new Player();
        player.Position = new Vector2(000, 730);
        
        //camera
        Camera2D cam = new Camera2D();
        cam.Target = new Vector2(player.Position.X, player.Position.Y - 150);
        cam.Offset = new Vector2(SCREEN_WITDH / 3f, SCREEN_HEIGHT / 2f);
        cam.Zoom = 1f;

        //level 
        Level level = new Level();
        Debug debug = new Debug();
        ProgressBar progressBar = new ProgressBar();

        Scene scene = Scene.Menu;
        MenuScene menuScene = new MenuScene();

        //temp
        GuiEndLevel guiEndLevel = new GuiEndLevel();

        //load windows
        Raylib.InitWindow(SCREEN_WITDH, SCREEN_HEIGHT, "Géometrie dash");
        Raylib.SetExitKey(KeyboardKey.Null);
        Raylib.SetTargetFPS(120);

        // -- BOUCLE -- //
        while (Program.running)
        {
            float dt = Raylib.GetFrameTime();

            //logique du menu
            if (scene == Scene.Menu)
            {
                string result = menuScene.Update();

                if (result != null)
                {
                    player.Position = new Vector2(000, 730);
                    level.Load(result);
                    scene = Enum.Parse<Scene>(result);
                    player.StartLevel();
                }
            }
            else
            {
                player.Update(dt);
                cam.Target.X = player.Position.X;
            }

            if (level.GetPourcentage() >= 100)
            {

                string result = guiEndLevel.Update();


                if (result != null)
                {
                    if (result == "menu")
                    {
                        scene = Scene.Menu;
                    }
                    else
                    {
                        Console.WriteLine("Restart");
                        player.StartLevel();
                        level.Load(result);
                        scene = Enum.Parse<Scene>(result);
                    }
                }
            }

            player.isGrounded = false;

            //SAVE
            if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                Console.WriteLine("Saving...");
                GameManager.SaveGame();
                GameManager.QuitGame();
            }

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
                level.Draw();
                player.Draw();
                level.Update(player);
                Raylib.EndMode2D();
                progressBar.Draw(level.GetPourcentage());

                if (level.GetPourcentage() >= 100)
                {
                    guiEndLevel.Draw();
                    guiEndLevel.Update();
                }
            }

            Raylib.EndDrawing();

            if (GameManager.shouldQuit || Raylib.WindowShouldClose())
            {
                Program.running = false;
            }
        }
    }
}
