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
        public override void Cleanup()
        {

        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            // Roof of the game
            RectangleShape roof = new(new Vector2f(windowX, windowY * containerLength));
            roof.FillColor = roofColor;
            SettingsManager.GetIntances().GetWindow().Draw(roof);

            // Floor of the game
            RectangleShape floor = new(new Vector2f(windowX, windowY * containerLength));
            floor.Position = new(0, windowY * (1 - containerLength));
            floor.FillColor = floorColor;
            SettingsManager.GetIntances().GetWindow().Draw(floor);

            // Background of the game
            RectangleShape background = new(new Vector2f(windowX, windowY * (1 - (2 * containerLength))));
            background.Position = new(0, windowY * containerLength);
            background.FillColor = backgroundColor;
            SettingsManager.GetIntances().GetWindow().Draw(background);

            // Player of the game
            PlayerStateManager.GetInstance().GetStates().Peek().Draw();

            // Lasers of the game
            LaserStateManager.GetInstance().DrawLasers();
        }

        public override void Exit()
        {

        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            Console.WriteLine("Play game init");
        }

        public override void Update(float deltaTime)
        {
            _velocity += deltaTime / 45;
            if (_velocity > 5)
            {
                _velocity = 5;
            }
            PlayerStateManager.GetInstance().GetStates().Peek().Update(deltaTime, _velocity);
            LaserStateManager.GetInstance().UpdateLasers(deltaTime, _velocity);
        }
    }
}
