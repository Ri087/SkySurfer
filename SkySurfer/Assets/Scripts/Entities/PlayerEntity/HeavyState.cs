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
    class HeavyState : PlayerBaseState
    {
        public override bool CheckCollision()
        {
            foreach (EnemyBaseState enemy in EnemyStateManager.GetInstance().GetEnemies())
            {
                if (PlayerStateManager.GetInstance().GetPlayer().GetPlayerBounds().Intersects(enemy.GetShootHitBox()))
                {
                    return true;
                }
            }
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
            player.FillColor = Color.Red;
            player.Position = new(windowX * 0.1f, windowY * PlayerStateManager.GetInstance().GetPlayer().GetPositionY());
            SettingsManager.GetIntances().GetWindow().Draw(player);
        }

        public override void Exit()
        {
            PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetClassicState());
            PlayerStateManager.GetInstance().GetStates().Peek().Exit();
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(15); // Not a powerup state
            PlayerStateManager.GetInstance().GetPlayer().SetHp(2); // 2 HP max
            PlayerStateManager.GetInstance().GetPlayer().SetAttackSpeed(5); // 5 Attack speed
            PlayerStateManager.GetInstance().GetPlayer().SetLastAttack(0); // Reset attack timer (formula 1/AS)
            PlayerStateManager.GetInstance().GetPlayer().SetGravity(0); // Reset gravity
        }

        public override void Update(float deltaTime, float velocity)
        {
            PlayerStateManager.GetInstance().GetPlayer().SetLastAttack(PlayerStateManager.GetInstance().GetPlayer().GetLastAttack() + deltaTime);
            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(PlayerStateManager.GetInstance().GetPlayer().GetPowerUpTime() - deltaTime);
            if (PlayerStateManager.GetInstance().GetPlayer().GetPowerUpTime() <= 0)
            {
                PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetClassicState());
            }

            PlayerStateManager.GetInstance().GetPlayer().SetInvulnerableTime(PlayerStateManager.GetInstance().GetPlayer().GetInvulnerableTime() - deltaTime);

            // Check if player is invulnerable, get collision, has enough hp to survive
            if (PlayerStateManager.GetInstance().GetPlayer().GetInvulnerableTime() > 0) return;
            if (!CheckCollision()) return;
            PlayerStateManager.GetInstance().GetPlayer().SetHp(PlayerStateManager.GetInstance().GetPlayer().GetHp() - 1);
            PlayerStateManager.GetInstance().GetPlayer().SetInvulnerableTime(2);
            if (PlayerStateManager.GetInstance().GetPlayer().GetHp() > 0) return;
            GameStateManager.GetInstance().GetStates().Peek().Exit();
            GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetLooseMenuGameState());
        }
    }
}
