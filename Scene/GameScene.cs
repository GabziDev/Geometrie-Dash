using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using test_raylibs.Composant;
using test_raylibs.Interface;
using test_raylibs.Levels;
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
            Program.level.Load(levelName);

            Program.player.StartLevel();

            cam.Target = new Vector2(Program.player.Position.X, Program.player.Position.Y - 150);
            cam.Offset = new Vector2(Program.SCREEN_WIDTH / 3f, Program.SCREEN_HEIGHT / 2f);
            cam.Zoom = 1f;
        }

        public void Update(float dt)
        {
            Program.player.isGrounded = false;
            Program.level.Update(Program.player, ref cam);
            Program.player.Update(dt);

            if (Program.level.GetPourcentage() >= 100)
            {
                string result = guiEndLevel.Update();
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
            Program.level.Draw();
            Program.player.Draw();
            Raylib.EndMode2D();

            progressBar.Draw(Program.level.GetPourcentage());

            if (Program.level.GetPourcentage() >= 100)
            {
                guiEndLevel.Draw();
            }
        }
    }
}