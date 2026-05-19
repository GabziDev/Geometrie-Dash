using System;
using System.Collections.Generic;
using System.Text;

namespace test_raylibs.Interface
{
    public interface IScene
    {
        void Update(float dt);
        void Draw();
    }
}