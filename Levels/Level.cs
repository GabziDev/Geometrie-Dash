using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;
using test_raylibs.Obstactle;
using test_raylibs.Model;

namespace test_raylibs.Levels
{
    public class Level
    {
        public List<Obtacle> Blocks = new List<Obtacle>();

        public string currentLevel = Program.currentLevel;

        //charge les object du nivaux
        public void Load(string level)
        {
            string text = File.ReadAllText(@"./Data/" + level + ".json");
            Console.WriteLine(text);

            var levelData = JsonSerializer.Deserialize<LevelData>(text);

            foreach (var block in levelData.data.blocks)
            {
                switch (block.type)
                {
                    case "Spike": Blocks.Add(new Spike(block.x, block.y)); break;
                    case "SquareBlock": Blocks.Add(new SquareBlock(block.x, block.y)); break;
                    case "SpikeFlat": Blocks.Add(new SpikeFlat(block.x, block.y)); break;
                    case "Ground": Blocks.Add(new Ground(block.x, block.y)); break;
                }
            }
            
        }

        //logic
        public void Update(Player player)
        {
            foreach (var block in Blocks)
            {
                if (Raylib.CheckCollisionRecs(player.GetRect(), block.GetRect()))
                {
                    Console.WriteLine("Cllisomn");
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
            }
        }

        //dessine
        public void Draw()
        {
            
            foreach (var block in Blocks)
            {
                block.Draw();
            }
        }
    }
}
