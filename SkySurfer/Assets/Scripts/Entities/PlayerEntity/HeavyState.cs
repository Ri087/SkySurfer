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

            PlayerStateManager.GetInstance().GetPlayer().SetPLayeryBounds(player);


            SettingsManager.GetIntances().GetWindow().Draw(player);
        }

        public override void Exit()
        {
            PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetClassicState());
            PlayerStateManager.GetInstance().GetStates().Peek().Exit();
            SettingsManager.GetIntances().GetWindow().KeyPressed -= Jump;
        }

        public override void HandleInput()
        {

        }

        public override void Init()
        {
            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(15); // Not a powerup state
            PlayerStateManager.GetInstance().GetPlayer().SetHp(3); // 2 HP max
            PlayerStateManager.GetInstance().GetPlayer().SetAttackSpeed(5); // 5 Attack speed
            PlayerStateManager.GetInstance().GetPlayer().SetLastAttack(0); // Reset attack timer (formula 1/AS)
            LaserStateManager.GetInstance().Clear();
            SettingsManager.GetIntances().GetWindow().KeyPressed += Jump;
        }

        public override void Update(float deltaTime, float velocity)
        {
            if (PlayerStateManager.GetInstance().GetPlayer().GetPositionY() >= PlayerStateManager.GetInstance().GetPlayer()._minHeightPosition)
            {
                PlayerStateManager.GetInstance().GetPlayer().SetJump(2);
            }

            PlayerStateManager.GetInstance().GetPlayer().SetPositionY(PlayerStateManager.GetInstance().GetPlayer().GetPositionY() + deltaTime / 3.5f);

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
            Exit();
            GameStateManager.GetInstance().GetStates().Peek().Exit();
            GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetLooseMenuGameState());
        }

        private void Jump(Object? sender, KeyEventArgs e)
        {
            Console.WriteLine("nope");
            if (e.Code != SettingsManager.GetIntances().GetJumpKey()) return;
            Console.WriteLine(PlayerStateManager.GetInstance().GetPlayer().GetJump());
            if (PlayerStateManager.GetInstance().GetPlayer().GetJump() <= 0) return;
            PlayerStateManager.GetInstance().GetPlayer().SetJump(PlayerStateManager.GetInstance().GetPlayer().GetJump() - 1);
            PlayerStateManager.GetInstance().GetPlayer().SetPositionY(PlayerStateManager.GetInstance().GetPlayer().GetPositionY() - 0.30f);
            Console.WriteLine("done");
        }
    }
}
