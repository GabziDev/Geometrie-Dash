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
    public static int attemps = 1;
    public static int jump;

    public static string currentLevel = "menu";
    public static Color bgColor = Color.White;

    public const int SCREEN_WIDTH = 1920;
    public const int SCREEN_HEIGHT = 1080;

    public static bool debug = true;
    public static bool inGame = false;

    public static bool running = true;

    public static Player player = new Player();
    public static Level level = new Level();

    static void Main()
    {
        player.Position = new Vector2(000, 730);
        
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "Géometrie dash");
        Raylib.SetExitKey(KeyboardKey.Null);
        Raylib.SetTargetFPS(120);

        SceneManager.SetScene(new MenuScene());

        while (Program.running)
        {
            float dt = Raylib.GetFrameTime();

            SceneManager.Update(dt);

           //Save
            if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                Console.WriteLine("Saving...");
                GameManager.SaveGame();
                GameManager.QuitGame();
            }

            //Draw
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Program.bgColor);
            SceneManager.Draw();
            Raylib.EndDrawing();

            if (GameManager.shouldQuit || Raylib.WindowShouldClose())
            {
                Program.running = false;
            }
        }
    }
}