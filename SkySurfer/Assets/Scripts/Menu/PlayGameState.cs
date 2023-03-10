using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SkySurfer.Assets.Scripts.Entities;
using SkySurfer.Assets.Scripts.Entities.EnemyEntity;
using SkySurfer.Assets.Scripts.Entities.LaserEntity;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
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
        private Font font = new("../../../Assets/Fonts/Balbek-Personal.otf");

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

            // Score of the player
            ScorePrint(Math.Floor(PlayerStateManager.GetInstance().GetPlayer().GetScore()).ToString(),font);

            // Player of the game
            PlayerStateManager.GetInstance().GetStates().Peek().Draw();

            // Lasers of the game
            LaserStateManager.GetInstance().DrawLasers();

            // Enemies of the game
            EnemyStateManager.GetInstance().DrawEnemies();

            // Player Shoot of the game
            ShootStateManager.GetInstance().DrawShoot();

            // Power Up of the game
            PowerUpStateManager.GetInstance().DrawPowerUp();
        }

        public override void Exit()
        {
            EnemyStateManager.GetInstance().Clear();
            LaserStateManager.GetInstance().Clear();
            PowerUpStateManager.GetInstance().Clear();
            ShootStateManager.GetInstance().Clear();
            SettingsManager.GetIntances().GetWindow().KeyPressed -= PauseMenu;

            _velocity = 1;
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            // Init Player Score
            PlayerStateManager.GetInstance().GetStates().Peek().Init();

            SettingsManager.GetIntances().GetWindow().KeyPressed += PauseMenu;

        }

        public override void Update(float deltaTime)
        {
            if (_velocity < 4f)
            {
                _velocity += deltaTime / 30;
            }
            PlayerStateManager.GetInstance().GetStates().Peek().Update(deltaTime, _velocity);
            LaserStateManager.GetInstance().UpdateLasers(deltaTime, _velocity);
            EnemyStateManager.GetInstance().UpdateEnemies(deltaTime, _velocity);
            ShootStateManager.GetInstance().UpdateShoot(deltaTime, _velocity);
            PowerUpStateManager.GetInstance().UpdatePowerUp(deltaTime, _velocity);
            PlayerStateManager.GetInstance().GetPlayer().SetScore(PlayerStateManager.GetInstance().GetPlayer().GetScore() + deltaTime * 10);
        }
        private void ScorePrint(string text, Font font)
        {
            Text windowText = new(text, font);
            windowText.FillColor = Color.Black;
            windowText.Position = new Vector2f(0f, 0.1f * SettingsManager.GetIntances().GetWindow().Size.X);
            SettingsManager.GetIntances().GetWindow().Draw(windowText);
        }
        public void Pause()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed -= PauseMenu;
            GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetPauseMenuGameState());
        }


        private void PauseMenu(Object? sender, KeyEventArgs e)
        {
            if (e.Code != SettingsManager.GetIntances().GetMenuBackKey())
            {
                return;
            }
            Pause();
        }
    }
}
