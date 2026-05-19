using System;
using System.Collections.Generic;
using System.Text;
using test_raylibs.Interface;

namespace test_raylibs.Services
{
    public static class SceneManager
    {
        private static IScene _current;

        public static void SetScene(IScene scene) => _current = scene;
        public static void Update(float dt) => _current.Update(dt);
        public static void Draw() => _current.Draw();
    }
}
