using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;
using test_raylibs.Model;
using test_raylibs.Obstactle;
using test_raylibs.Tool;
using test_raylibs.Composant;

namespace test_raylibs.Levels
{
    public class Level
    {
        public List<Obstacle> Blocks = new List<Obstacle>();

        public string currentLevel = Program.currentLevel;

        StartStats startStats = new StartStats();
        GuiEndLevel guiEndLevel = new GuiEndLevel();

        public float levelLenght;
        public float pourcentage = 0;


        //charge les object du nivaux
        public void Load(string level)
        {
            string text = File.ReadAllText(@"./Data/" + level + ".json");
            

            var levelData = JsonSerializer.Deserialize<LevelData>(text);
            string stringColor = levelData.bgColor;
            Program.bgColor = Raylib.GetColor(Convert.ToUInt32(stringColor, 16));

            foreach (var block in levelData.data.blocks)
            {
                switch (block.type)
                {
                    case "Spike": Blocks.Add(new Spike(block.x, block.y)); break;
                    case "SquareBlock": Blocks.Add(new SquareBlock(block.x, block.y)); break;
                    case "SpikeFlat": Blocks.Add(new SpikeFlat(block.x, block.y)); break;
                    case "Ground": Blocks.Add(new Ground(block.x, block.y)); break;
                    case "EndLevel": Blocks.Add(new EndLevel(block.x, block.y));
                        levelLenght = block.x -80;
                        break;
                }
            }
        }

        public void Update(Player player)
        {
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

                //finishLevel
                if (block is EndLevel endLevel)
                {
                    if (Raylib.CheckCollisionRecs(player.GetDeathZone(), endLevel.GetRect()))
                    {
                        player.LevelCompleted();
                    }
                    continue;
                }

                if (Raylib.CheckCollisionRecs(player.GetDeathZone(), block.GetRect()))
                {
                    player.Death();
                }


                Rectangle blockRect = block.GetRect();

                if (Raylib.CheckCollisionRecs(player.GetRect(), blockRect))
                {
                    if (player.Velocity.Y < 0)
                    {
                        player.Position.Y = blockRect.Y - player.GetRect().Height;

                        player.Velocity.Y = 0;

                        player.isGrounded = true;
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
            float raw = (player.Position.X / levelLenght) * 100f;
            return Math.Clamp(raw, 0f, 100f);
        }

        //dessine
        public void Draw()
        {
            startStats.Draw();

            foreach (var block in Blocks)
            {
                block.Draw();
            }

            if (pourcentage >= 100)
            {
                Console.WriteLine("Plus de 100");
                guiEndLevel.Draw();
            }
        }
    }
}