using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;
using test_raylibs.Composant;
using test_raylibs.Interface;
using test_raylibs.Model;
using test_raylibs.Obstactle;
using test_raylibs.Services;

namespace test_raylibs.Scene
{
    public class StatsScene : IScene
    {
        static float w = Program.SCREEN_WIDTH;
        static float h = Program.SCREEN_HEIGHT;

        Button btnBack = new Button((int)(w * 2f / 4f), (int)(h * 2f / 3f), Color.Brown, "menu", "Retour");

        static int totalJump;
        static int totalAttemps;
        static int totalxp;

        public StatsScene()
        {
            GameManager.SaveGame();
            LoadStats();
        }

        public void Update(float dt)
        {
            if (btnBack.IsClicked())
            {
                SceneManager.SetScene(new MenuScene());
            }
        }

        public static void LoadStats()
        {
            string json = File.ReadAllText(@"./Data/Player.json");
            PlayerData player = JsonSerializer.Deserialize<PlayerData>(json);

            totalJump = player.jump;
            totalAttemps = player.attemps;
            totalxp = player.xp;
        }

        public void Draw()
        {
            string title = "Statistiques";
            int titleW = Raylib.MeasureText(title, 40);
            Raylib.DrawText(title, (Program.SCREEN_WIDTH - titleW) / 2, Program.SCREEN_HEIGHT / 4, 40, Color.Black);

            string jump = "Total de jump : " + totalJump;
            int jumpW = Raylib.MeasureText(jump, 20);
            Raylib.DrawText(jump, (Program.SCREEN_WIDTH - jumpW) / 2, Program.SCREEN_HEIGHT / 2, 20, Color.Black);

            string attemp = "Total d'essais : " + totalAttemps;
            int attempW = Raylib.MeasureText(attemp, 20);
            Raylib.DrawText(attemp, (Program.SCREEN_WIDTH - attempW) / 2, Program.SCREEN_HEIGHT / 2 - 40, 20, Color.Black);

            string xp = "Xp : " + totalxp;
            int xpW = Raylib.MeasureText(xp, 20);
            Raylib.DrawText(xp, (Program.SCREEN_WIDTH - xpW) / 2, Program.SCREEN_HEIGHT / 2 - 80, 20, Color.Black);

            btnBack.Draw();
        }
    }
}