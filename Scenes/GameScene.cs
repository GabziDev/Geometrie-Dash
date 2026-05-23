using Raylib_cs;
using System.Numerics;
using test_raylibs.Components;
using test_raylibs.Composant;
using test_raylibs.Managers;
using test_raylibs.Services;
using test_raylibs.Tool;

namespace test_raylibs.Scene
{
    public class GameScene : IScene
    {
        private GuiEndLevel guiEndLevel = new GuiEndLevel();
        private ProgressBar progressBar = new ProgressBar();
        private Debug debug = new Debug();
        private Camera2D cam = new Camera2D();

        public string levelName;

        public GameScene(string levelName)
        {
            this.levelName = levelName;
            GameManager.Instance.Level.Load(levelName);

            GameManager.Instance.Player.StartLevel();

            cam.Target = new Vector2(GameManager.Instance.Player.Position.X, GameManager.Instance.Player.Position.Y - 150);
            cam.Offset = new Vector2(Constants.SCREEN_WIDTH / 3f, Constants.SCREEN_HEIGHT / 2f);
            cam.Zoom = 1f;
        }

        public void Update(float dt)
        {
            GameManager.Instance.Player.isGrounded = false;
            GameManager.Instance.Level.Update(GameManager.Instance.Player, ref cam);
            GameManager.Instance.Player.Update(dt);

            if (GameManager.Instance.Level.GetPourcentage() >= 100)
            {
                string? result = guiEndLevel.Update();
                if (result == "menu")
                {
                    SceneManager.SetScene(new MenuScene());
                }
                else if (result != null)
                {
                    SceneManager.SetScene(new GameScene(levelName));
                }
            }
        }

        public void Draw()
        {
            if (Raylib.IsKeyDown(KeyboardKey.Q))
            {
                debug.Draw();
            }

            Raylib.BeginMode2D(cam);
            GameManager.Instance.Level.Draw();
            GameManager.Instance.Player.Draw();
            Raylib.EndMode2D();

            progressBar.Draw(GameManager.Instance.Level.GetPourcentage());

            if (GameManager.Instance.Level.GetPourcentage() >= 100)
            {
                guiEndLevel.Draw();
            }
        }
    }
}