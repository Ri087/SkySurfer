using SFML.Graphics;
using SFML.System;
using SkySurfer.Assets.Scripts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Menu
{
    class PlayGameState : GameBaseState
    {
        // Play game manager
        private float _velocity = 1;

        // Roof and floor
        private float containerLength = 0.1f;
        private Color roofColor = Color.Green;
        private Color floorColor = Color.Blue;

        // Background
        private Color backgroundColor = Color.White;

        RenderWindow window;
        public override void Cleanup()
        {

        }

        public override void Draw(RenderWindow window)
        {
            float windowX = window.Size.X;
            float windowY = window.Size.Y;

            // Roof of the game
            RectangleShape roof = new(new Vector2f(windowX, windowY * containerLength));
            roof.FillColor = roofColor;
            window.Draw(roof);

            // Floor of the game
            RectangleShape floor = new(new Vector2f(windowX, windowY * containerLength));
            floor.Position = new(0, windowY * (1 - containerLength));
            floor.FillColor = floorColor;
            window.Draw(floor);

            // Background of the game
            RectangleShape background = new(new Vector2f(windowX, windowY * (1 - (2 * containerLength))));
            background.Position = new(0, windowY * containerLength);
            background.FillColor = backgroundColor;
            window.Draw(background);

            // Player of the game
            PlayerStateManager.GetInstance().GetStates().Peek().Draw(window);
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
            _velocity += deltaTime / 90;
            PlayerStateManager.GetInstance().GetStates().Peek().Update(deltaTime, _velocity);
        }
    }
}
