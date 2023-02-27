using SFML.Graphics;
using SFML.System;
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
            PlayerStateManager.GetInstance().GetClassicState().Exit();
            PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetClassicState());
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(15); // Not a powerup state
            EnemyStateManager.GetInstance().Clear(); // Remove every enemy
        }

        public override void Update(float deltaTime, float velocity)
        {
            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(PlayerStateManager.GetInstance().GetPlayer().GetPowerUpTime() - deltaTime);
            if (PlayerStateManager.GetInstance().GetPlayer().GetPowerUpTime() <= 0)
            {
                PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetClassicState());
            }
            if (!CheckCollision()) return;
            GameStateManager.GetInstance().GetStates().Peek().Exit();
            GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetLooseMenuGameState()); 
        }
    }
}
