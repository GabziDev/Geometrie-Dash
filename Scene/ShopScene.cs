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

namespace test_raylibs.Scene
{
    public class ShopScene : IScene
    {
        static float w = Program.SCREEN_WIDTH;
        static float h = Program.SCREEN_HEIGHT;

        static int totalJump;
        static int totalAttemps;

        Button skinBlue = new Button((int)(w * 3f / 4f), (int)(h * 2f / 5f), Color.Brown, "shop", "");

        public ShopScene()
        {
            LoadStats();
        }

        public void Update(float dt)
        {

        }

        public static void LoadStats()
        {
            string json = File.ReadAllText(@"./Data/Player.json");
            PlayerData player = JsonSerializer.Deserialize<PlayerData>(json);

            totalJump = player.jump;
            totalAttemps = player.attemps;

            Console.WriteLine("Statss");
        }

        public void Draw()
        {
            string title = "Shop";
            int titleW = Raylib.MeasureText(title, 40);
            Raylib.DrawText(title, (Program.SCREEN_WIDTH - titleW) / 2, Program.SCREEN_HEIGHT / 4, 40, Color.Black);

            string txt = "Votre personnage actuel";
            int jumpW = Raylib.MeasureText(txt, 20);
            Raylib.DrawText(txt, (Program.SCREEN_WIDTH - jumpW) / 2, Program.SCREEN_HEIGHT / 2, 20, Color.Black);

            skinBlue.Draw();

        }
    }
}