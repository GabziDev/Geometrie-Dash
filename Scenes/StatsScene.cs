using Raylib_cs;
using System.Text.Json;
using test_raylibs.Composant;
using test_raylibs.Managers;
using test_raylibs.Model;
using test_raylibs.Services;

namespace test_raylibs.Scene
{
    public class StatsScene : IScene
    {
        Button btnBack = new Button((int)(Constants.SCREEN_WIDTH * 2f / 4f), (int)(Constants.SCREEN_HEIGHT * 2f / 3f), Color.Brown, "menu", "Retour");

        static int totalJump;
        static int totalAttemps;
        static int totalxp;

        public StatsScene()
        {
            GameManager.Instance.SaveGame();
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
            string json = File.ReadAllText(Constants.PLAYER_SAVE_FILE_PATH);
            PlayerData? player = JsonSerializer.Deserialize<PlayerData>(json);

            if (player != null)
            {
                totalJump = player.Jump;
                totalAttemps = player.Attempts;
                totalxp = player.Xp;
            }
        }

        public void Draw()
        {
            string title = "Statistiques";
            int titleW = Raylib.MeasureText(title, 40);
            Raylib.DrawText(title, (Constants.SCREEN_WIDTH - titleW) / 2, Constants.SCREEN_HEIGHT / 4, 40, Color.Black);

            string jump = "Total de jump : " + totalJump;
            int jumpW = Raylib.MeasureText(jump, 20);
            Raylib.DrawText(jump, (Constants.SCREEN_WIDTH - jumpW) / 2, Constants.SCREEN_HEIGHT / 2, 20, Color.Black);

            string attemp = "Total d'essais : " + totalAttemps;
            int attempW = Raylib.MeasureText(attemp, 20);
            Raylib.DrawText(attemp, (Constants.SCREEN_WIDTH - attempW) / 2, Constants.SCREEN_HEIGHT / 2 - 40, 20, Color.Black);

            string xp = "Xp : " + totalxp;
            int xpW = Raylib.MeasureText(xp, 20);
            Raylib.DrawText(xp, (Constants.SCREEN_WIDTH - xpW) / 2, Constants.SCREEN_HEIGHT / 2 - 80, 20, Color.Black);

            btnBack.Draw();
        }
    }
}