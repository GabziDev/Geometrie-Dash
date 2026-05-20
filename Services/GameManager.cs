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

            Console.WriteLine("Attemp : " + Program.attemps);
            Console.WriteLine("Jump : " + Program.jump);

            player.attemps += Program.attemps;
            player.jump += Program.jump;

            var options = new JsonSerializerOptions { WriteIndented = true };

            File.WriteAllText(@"./Data/Player.json", JsonSerializer.Serialize(player, options));

            Program.attemps = 0;
            Program.jump = 0;

            Console.WriteLine("Game saved");
        }

        public static void QuitGame()
        {
            Console.WriteLine("leave");
            shouldQuit = true;
        }
    }
}
