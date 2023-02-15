using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu
{
    internal class LooseMenuGameState : GameBaseState
    {

        private RenderWindow? window;

        public override void Cleanup()
        {
            //throw new NotImplementedException();
        }

        public override void Draw(RenderWindow window)
        {
            //throw new NotImplementedException();
        }

        public override void Exit()
        {
            //throw new NotImplementedException();
        }

        public override void HandleInput()
        {
            //throw new NotImplementedException();
        }

        public override void Init()
        {
            this.window = GameStateManager.GetInstance().GetWindow();
            //throw new NotImplementedException();
        }

        public override void Update(float deltaTime)
        {
            //  throw new NotImplementedException();
        }
    }
}
