using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu
{
    class PlayGameState : GameBaseState
    {
        
        private RenderWindow? window;
        public override void Cleanup()
        {

        }

        public override void Draw(RenderWindow window)
        {

        }

        public override void Exit()
        {

        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            this.window = GameStateManager.GetInstance().GetWindow();

            Console.WriteLine("Play game init");
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
