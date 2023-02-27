using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SkySurfer.Assets.Scripts.Entities.EnemyEntity;
using SkySurfer.Assets.Scripts.Entities.LaserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    class ClassicState : PlayerBaseState
    {
        private float _flyingSpeed;
        private readonly float _flyingSpeedMax = 0.5f;
        private bool _flying;
        public override void Cleanup()
        {

        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            RectangleShape player = new(new Vector2f(windowX * 0.06f, windowY * 0.1f));

            player.Position = new Vector2f(windowX * 0.1f, windowY * PlayerStateManager.GetInstance().GetPlayer().GetPositionY());
            player.FillColor = Color.Black;

            PlayerStateManager.GetInstance().GetPlayer().SetPLayeryBounds(player);

            SettingsManager.GetIntances().GetWindow().Draw(player);

        }

        public override void Exit()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed -= Shoot;
            SettingsManager.GetIntances().GetWindow().KeyPressed -= Flying;
            SettingsManager.GetIntances().GetWindow().KeyReleased -= NotFlying;
        }
        public override void HandleInput()
        {

        }

        public override void Init()
        {
            Console.Write("hello world");
            // Event
            SettingsManager.GetIntances().GetWindow().KeyPressed += Shoot;
            SettingsManager.GetIntances().GetWindow().KeyPressed += Flying;

            // player stats
            PlayerStateManager.GetInstance().GetPlayer().SetPowerUpTime(0); // Not a powerup state
            PlayerStateManager.GetInstance().GetPlayer().SetHp(1); // 1 HP max
            PlayerStateManager.GetInstance().GetPlayer().SetJump(0); // 0 means that he can fly
            PlayerStateManager.GetInstance().GetPlayer().SetAttackSpeed(2.5f); // 1 Attack speed
            PlayerStateManager.GetInstance().GetPlayer().SetLastAttack(0); // Reset attack timer
            PlayerStateManager.GetInstance().GetPlayer().SetInvulnerableTime(0); // Not invulnerable anymore
            PlayerStateManager.GetInstance().GetPlayer().SetGravity(0); // Reset gravity

            _flyingSpeed = 0f;
            _flying = false;
        }

        public override void Update(float deltaTime, float velocity)
        {
            if (CheckCollision())
            {
                GameStateManager.GetInstance().GetStates().Peek().Exit();           
                GameStateManager.GetInstance().SwitchState(GameStateManager.GetInstance().GetLooseMenuGameState());
            }
            SetFlyingSpeed(deltaTime);
            PlayerStateManager.GetInstance().GetPlayer().SetPositionY(PlayerStateManager.GetInstance().GetPlayer().GetPositionY() - _flyingSpeed / 30);
            PlayerStateManager.GetInstance().GetPlayer().SetLastAttack(PlayerStateManager.GetInstance().GetPlayer().GetLastAttack() + deltaTime);
        }

        private void SetFlyingSpeed(float deltaTime)
        {
            // Reduce fly speed by little when at top or at bottom
            if (PlayerStateManager.GetInstance().GetPlayer().GetPositionY() <= PlayerStateManager.GetInstance().GetPlayer()._maxHeightPosition)
            {
                // To decrease momentum
                if (_flyingSpeed > 0)
                {
                    _flyingSpeed -= deltaTime * 2.5f;
                }
                // Prevent to much momemtum decrease
                if (_flyingSpeed < 0)
                {
                    _flyingSpeed = 0;
                }
            }
            else if (PlayerStateManager.GetInstance().GetPlayer().GetPositionY() >= PlayerStateManager.GetInstance().GetPlayer()._minHeightPosition)
            {
                // To decrease momentum
                if (_flyingSpeed < 0)
                {
                    _flyingSpeed += deltaTime * 2.5f;
                }
                // Prevent to much momemtum decrease
                if (_flyingSpeed > 0)
                {
                    _flyingSpeed = 0;
                }
            }

            // Flying speed
            if (_flying)
            {
                _flyingSpeed += deltaTime;
            }
            else
            {
                _flyingSpeed -= deltaTime;
            }

            // To cap flying speed when flying
            if (_flyingSpeed <= -_flyingSpeedMax)
            {
                _flyingSpeed = -_flyingSpeedMax;
            }
            else if (_flyingSpeed >= _flyingSpeedMax)
            {
                _flyingSpeed = _flyingSpeedMax;
            }
        }


        private void Flying(Object? sender, KeyEventArgs e)
        {
            if (e.Code != SettingsManager.GetIntances().GetJumpKey()) return;
            _flying = true;
            SettingsManager.GetIntances().GetWindow().KeyPressed -= Flying;
            SettingsManager.GetIntances().GetWindow().KeyReleased += NotFlying;
        }
        private void NotFlying(Object? sender, KeyEventArgs e)
        {
            if (e.Code != SettingsManager.GetIntances().GetJumpKey()) return;
            _flying = false;
            SettingsManager.GetIntances().GetWindow().KeyReleased -= NotFlying;
            SettingsManager.GetIntances().GetWindow().KeyPressed += Flying;

        }
        private void Shoot(Object? sender, KeyEventArgs e)
        {
            if (e.Code != SettingsManager.GetIntances().GetShotKey()) return;
            if (1 / PlayerStateManager.GetInstance().GetPlayer().GetAttackSpeed() > PlayerStateManager.GetInstance().GetPlayer().GetLastAttack()) return;
            PlayerStateManager.GetInstance().GetPlayer().SetLastAttack(0);

            // Apparition du shoot
            ShootStateManager.GetInstance().SpawnShoot(PlayerStateManager.GetInstance().GetPlayer().GetPositionY());
        }

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
                if(PlayerStateManager.GetInstance().GetPlayer().GetPlayerBounds().Intersects(laser.GetLaserHitBox()))
                {
                    return true;
                }
            }
            return false;
        }
    }    
}
