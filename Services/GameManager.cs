using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using test_raylibs.Model;

namespace test_raylibs.Services
{
    public static class GameManager
    {
        public static bool shouldQuit = false;
        public static void SaveGame()
        {
            string json = File.ReadAllText(@"./Data/Player.json");
            PlayerData player = JsonSerializer.Deserialize<PlayerData>(json);

            player.attemps += Program.attemps;


            var options = new JsonSerializerOptions { WriteIndented = true };

            File.WriteAllText(@"./Data/Player.json", JsonSerializer.Serialize(player, options));

            Console.WriteLine("Game saved");
        }

        public static void QuitGame()
        {
            Console.WriteLine("leave");
            shouldQuit = true;
        }
    }
}
