using Raylib_cs;
using System.Numerics;
using System.Text.Json;
using test_raylibs.Model;
using test_raylibs.Obstactle;
using test_raylibs.Tool;
using test_raylibs.Composant;
using test_raylibs.Managers;
using test_raylibs.Entities;

namespace test_raylibs.Levels
{
    /*
     * tu t iech dessus ? ta structure pue le zeub 
     * Fait un LevelManager et idi nakhuy 
     */
    public class Level
    {
        public List<Obstacle> Blocks = new List<Obstacle>();

        public string currentLevel = GameManager.Instance.CurrentLevel;

        StartStats startStats = new StartStats();
        GuiEndLevel guiEndLevel = new GuiEndLevel();

        public float levelLength;
        public float pourcentage = 0;


        //charge les object du nivaux
        public void Load(string level)
        {
            Blocks.Clear();
            pourcentage = 0;

            string text = File.ReadAllText(@"./Data/" + level + ".json");

            LevelData levelData = JsonSerializer.Deserialize<LevelData>(text) ?? new LevelData();

            /**
             * Fix de gros enculer haya bismillah
             */
            if (!string.IsNullOrEmpty(levelData.BgColor))
                GameManager.Instance.BgColor = Raylib.GetColor(Convert.ToUInt32(levelData.BgColor.Length == 6 ? levelData.BgColor + "FF" : levelData.BgColor, 16));

            foreach (var block in levelData.Data.Blocks)
            {
                switch (block.Type)
                {
                    case "Spike": Blocks.Add(new Spike(block.X, block.Y)); break;
                    case "SquareBlock": Blocks.Add(new SquareBlock(block.X, block.Y)); break;
                    case "SpikeFlat": Blocks.Add(new SpikeFlat(block.X, block.Y)); break;
                    case "Ground": Blocks.Add(new Ground(block.X, block.Y)); break;
                    case "JumpOrbes": Blocks.Add(new JumpOrbes(block.X, block.Y)); break;
                    case "JumpPad": Blocks.Add(new JumpPad(block.X, block.Y)); break;
                    case "EndLevel": Blocks.Add(new EndLevel(block.X, block.Y));
                        levelLength = block.X -80;
                        break;
                    default:
                        throw new Exception("Erreur : Format de nivaux invalide");
                }
            }
        }

        public void Update(Player player, ref Camera2D cam)
        {
            if (player.Position.X >= levelLength - Constants.SCREEN_WIDTH / 2)
            {
                cam.Target = new Vector2(levelLength - Constants.SCREEN_WIDTH / 2, cam.Target.Y);
            }
            else
            {
                cam.Target = new Vector2(player.Position.X, 630);
            }

            foreach (var block in Blocks)
            {
                if (block is Spike spike)
                {
                    if (Raylib.CheckCollisionRecs(player.GetDeathZone(), spike.GetHitbox()))
                    {
                        player.Death();
                    }
                    continue;
                }

                if (block is SpikeFlat spikeFlat)
                {
                    if (Raylib.CheckCollisionRecs(player.GetDeathZone(), spikeFlat.GetHitbox()))
                    {
                        player.Death();
                    }
                    continue;
                }

                if (block is JumpPad jumpPad)
                {
                    if (Raylib.CheckCollisionRecs(player.GetRect(), jumpPad.GetRect()))
                    {
                        player.Velocity.Y = 700;
                    }
                    continue;
                }

                if (block is EndLevel endLevel)
                {
                    if (Raylib.CheckCollisionRecs(player.GetDeathZone(), endLevel.GetRect()))
                    {
                        player.LevelCompleted();
                    }
                    continue;
                }

                if (block is not JumpOrbes jumpOrbes)
                {
                    if (Raylib.CheckCollisionRecs(player.GetDeathZone(), block.GetRect()))
                    {
                        player.Death();
                    }
                }

                Rectangle blockRect = block.GetRect();

                if (Raylib.CheckCollisionRecs(player.GetRect(), blockRect))
                {
                    if (block is JumpOrbes)
                    {
                        player.isGrounded = true;
                    }
                    else
                    {
                        if (player.Velocity.Y < 0)
                        {
                            player.Position.Y = blockRect.Y - player.GetRect().Height;

                            player.Velocity.Y = 0;

                            player.isGrounded = true;
                        }
                    }
                }

                pourcentage = GetLevelPourcentage(player);
            }
        }

        public float GetPourcentage()
        {
            return pourcentage;
        }

        public float GetLevelPourcentage(Player player)
        {
            float raw = (player.Position.X / levelLength) * 100f;
            return Math.Clamp(raw, 0f, 100f);
        }

        public void Draw()
        {
            startStats.Draw();

            foreach (var block in Blocks)
            {
                block.Draw();
            }

            if (GetPourcentage() >= 100)
            {
                guiEndLevel.Draw();
            }
        }
    }
}