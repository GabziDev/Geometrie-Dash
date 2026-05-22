using Raylib_cs;
using test_raylibs.Scene;
using test_raylibs.Managers;
using test_raylibs.Services;

namespace test_raylibs
{
    public class Game
    {
        public void Run()
        {
            Raylib.InitWindow(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.TITLE);
            Raylib.SetExitKey(KeyboardKey.Null);
            Raylib.SetTargetFPS(120);

            SceneManager.SetScene(new MenuScene());

            while (!ShouldQuit())
            {
                float dt = Raylib.GetFrameTime();

                HandleInput();
                SceneManager.Update(dt);

                //Draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(GameManager.Instance.BgColor);
                SceneManager.Draw();
                Raylib.EndDrawing();
            }
        }

        private static void HandleInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                GameManager.Instance.SaveGame();
                GameManager.Instance.QuitGame();
            }
        }

        private static bool ShouldQuit()
        {
            return !GameManager.Instance.Running || 
                    GameManager.Instance.ShouldQuit || 
                    Raylib.WindowShouldClose();
        }
    }
}
