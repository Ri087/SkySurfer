using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu
{
    public abstract class GameBaseState
    {
        //private  RenderWindow window;
        public abstract void Init(RenderWindow window);
        public abstract void Exit();
        public abstract void Cleanup();
        public abstract void Update(float deltaTime);
        public abstract void Draw(RenderWindow window);
        public abstract void HandleInput();
    }
}
