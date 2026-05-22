using Raylib_cs;
using test_raylibs.Composant;
using test_raylibs.Services;

namespace test_raylibs.Scene
{
    public class MenuScene : IScene
    {
        Button btnPlayLevel1 = new Button((int)(Constants.SCREEN_WIDTH * 1f / 4f), (int)(Constants.SCREEN_HEIGHT * 2f / 5f), Color.Brown, "Level_1", "Level 1");
        Button btnPlayLevel2 = new Button((int)(Constants.SCREEN_WIDTH * 2f / 4f), (int)(Constants.SCREEN_HEIGHT * 2f / 5f), Color.Brown, "Level_2", "Level 2");
        Button btnPlayLevel3 = new Button((int)(Constants.SCREEN_WIDTH * 3f / 4f), (int)(Constants.SCREEN_HEIGHT * 2f / 5f), Color.Brown, "Level_3", "Level 3");

        Button btnStats = new Button((int)(Constants.SCREEN_WIDTH * 2f / 4f), (int)(Constants.SCREEN_HEIGHT * 3f / 5f), Color.Brown, "Stats", "Stats");

        public void Update(float dt)
        {
            if (btnPlayLevel1.IsClicked())
            {
                SceneManager.SetScene(new GameScene(btnPlayLevel1.link));
            }
            else if (btnPlayLevel2.IsClicked())
            {
                SceneManager.SetScene(new GameScene(btnPlayLevel2.link));
            }
            else if (btnPlayLevel3.IsClicked())
            {
                SceneManager.SetScene(new GameScene(btnPlayLevel3.link));
            }
            else if (btnStats.IsClicked())
            {
                SceneManager.SetScene(new StatsScene());
            }
        }

        public void Draw()
        {
            string title = "Géometrie dash";
            int titleW = Raylib.MeasureText(title, 60);
            Raylib.DrawText(title, (Constants.SCREEN_WIDTH - titleW) / 2, Constants.SCREEN_HEIGHT / 4, 60, Color.Black);

            string p = "Géometrie Dash - freezix - 2026";
            int pW = Raylib.MeasureText(p, 25);
            Raylib.DrawText(p, (Constants.SCREEN_WIDTH - pW) / 2, Constants.SCREEN_HEIGHT / 2 + 300, 25, Color.Black);

            btnPlayLevel1.Draw();
            btnPlayLevel2.Draw();
            btnPlayLevel3.Draw();
            btnStats.Draw();
        }
    }
}