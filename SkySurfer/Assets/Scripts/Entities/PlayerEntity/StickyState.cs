using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SkySurfer.Assets.Scripts.Entities.EnemyEntity;
using SkySurfer.Assets.Scripts.Entities.LaserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    class StickyState : PlayerBaseState
    {
        private float _flyingSpeed;
        private readonly float _flyingSpeedMax = 0.5f;
        private bool _flying;
        public override bool CheckCollision()
        {
            foreach (LaserBaseState laser in LaserStateManager.GetInstance().GetLasers())
            {
                if (PlayerStateManager.GetInstance().GetPlayer().GetPlayerBounds().Intersects(laser.GetLaserHitBox()))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Cleanup()
        {

        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            // Player of the game
            RectangleShape player = new(new Vector2f(windowX * 0.06f, windowY * 0.1f));
            player.FillColor = Color.Green;
            player.Position = new(windowX * 0.1f, windowY * PlayerStateManager.GetInstance().GetPlayer().GetPositionY());
            
            SettingsManager.GetIntances().GetWindow().Draw(player);
        }

        public override void Exit()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed -= ChangingGravity;
            PlayerStateManager.GetInstance().GetClassicState().Exit();
            PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetClassicState());
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(15); // Seconds before transforming back
            EnemyStateManager.GetInstance().Clear(); // Remove every enemy
            LaserStateManager.GetInstance().Clear();
            _flyingSpeed = 0f;
            _flying = false;
        }

        public override void Update(float deltaTime, float velocity)
        {
            // Event
            AddEventGravity();

            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(PlayerStateManager.GetInstance().GetPlayer().GetPowerUpTime() - deltaTime);
            if (PlayerStateManager.GetInstance().GetPlayer().GetPowerUpTime() <= 0)
            {
                PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetClassicState());
            }

            PlayerStateManager.GetInstance().GetPlayer().SetPositionY(PlayerStateManager.GetInstance().GetPlayer().GetPositionY() + deltaTime / 1.5f * PlayerStateManager.GetInstance().GetPlayer().GetGravity());

            if (!CheckCollision()) return;
            Exit();
            GameStateManager.GetInstance().GetStates().Peek().Exit();
            GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetLooseMenuGameState()); 
        }

        private void AddEventGravity()
        {
            if (PlayerStateManager.GetInstance().GetPlayer().GetPositionY() == PlayerStateManager.GetInstance().GetPlayer()._maxHeightPosition || PlayerStateManager.GetInstance().GetPlayer().GetPositionY() == PlayerStateManager.GetInstance().GetPlayer()._minHeightPosition)
            {
                SettingsManager.GetIntances().GetWindow().KeyPressed += ChangingGravity;
            } else
            {
                SettingsManager.GetIntances().GetWindow().KeyPressed -= ChangingGravity;
            }

        }

        private void ChangingGravity(Object? sender, KeyEventArgs e)
        {
            if (e.Code != SettingsManager.GetIntances().GetJumpKey()) return;
            PlayerStateManager.GetInstance().GetPlayer().SetGravity(PlayerStateManager.GetInstance().GetPlayer().GetGravity() * -1);
            SettingsManager.GetIntances().GetWindow().KeyPressed -= ChangingGravity;
        }
    }
}
