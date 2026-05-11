using System;
using System.Collections.Generic;
using System.Text;
using test_raylibs.Obstactle;

namespace test_raylibs.Levels
{
    public class Level
    {
        public string Name { get; set; }
        public List<Obtacle> Obtacle { get; set; }

        public Level(string name, List<Obtacle> obtacle)
        {
            Name = name;
            Obtacle = obtacle;
        }
    }
}
