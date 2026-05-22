using Raylib_cs;
using System.Numerics;
using System.Text.Json;
using test_raylibs.Entities;
using test_raylibs.Levels;
using test_raylibs.Model;

namespace test_raylibs.Managers
{
    public class GameManager
    {
        private static GameManager? _instance;
        public static GameManager Instance 
        {
            get
            {
                if (_instance == null) _instance = new();
                return _instance;
            }
        }

        public int Attempts { get; set; } = 1;
        public int Jump { get; set; }
        public int Xp { get; set; }
        public string CurrentLevel { get; set; } = "menu";
        public Color BgColor { get; set; } = Color.White;
        public bool Debug { get; set; } = true;
        public bool Running { get; private set; } = true;
        public bool ShouldQuit { get; private set; } = false;
        public Player Player { get; private set; }
        public Level Level {  get; private set; }

        private GameManager()
        {
            _instance = this;
            Player = new() { Position = new Vector2(0, 730) };
            Level = new();
        }

        public void SaveGame()
        {
            if (!File.Exists(Constants.PLAYER_SAVE_FILE_PATH))
            {
                Console.WriteLine("Save file introuvable");
                return;
            }
            try
            {
                string json = File.ReadAllText(Constants.PLAYER_SAVE_FILE_PATH);
                PlayerData player = JsonSerializer.Deserialize<PlayerData>(json) ?? new PlayerData();

                player.Attempts += Attempts;
                player.Jump += Jump;
                player.Xp += Xp;

                JsonSerializerOptions options = new() { WriteIndented = true };
                File.WriteAllText(Constants.PLAYER_SAVE_FILE_PATH, JsonSerializer.Serialize(player, options));

                ResetSessionStats();

                Console.WriteLine("Game saved nigga");
            } catch (Exception e)
            {
                Console.WriteLine($"Save failed {e.Message}");
            }
        }

        public void QuitGame()
        {
            Console.WriteLine("leave");
            ShouldQuit = true;
            Running = false;
        }

        private void ResetSessionStats()
        {
            Attempts = 0;
            Jump = 0;
        }
    }
}
