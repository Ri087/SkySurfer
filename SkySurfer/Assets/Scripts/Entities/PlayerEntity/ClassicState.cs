using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    class ClassicState : PlayerBaseState
    {
        private Player _player;
        private float _flyingSpeed;
        private float _flyingSpeedMax = 0.5f;
        private bool _flying;
        public override void Cleanup()
        {

        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            // Player of the game
            RectangleShape player = new(new Vector2f(windowX * 0.06f, windowY * 0.1f));
            player.FillColor = Color.Black;
            player.Position = new(windowX * 0.1f, windowY * _player.GetPositionY());
            SettingsManager.GetIntances().GetWindow().Draw(player);
        }

        public override void Exit()
        {
            SettingsManager.GetIntances().GetWindow().KeyPressed -= Shoot;
            SettingsManager.GetIntances().GetWindow().KeyPressed -= Flying;
            SettingsManager.GetIntances().GetWindow().KeyReleased -= NotFlying;
            //PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetStickyState()); switch states
        }

        public override void HandleInput()
        {

        }

        public override void Init(Player player)
        {
            // Event
            SettingsManager.GetIntances().GetWindow().KeyPressed += Shoot;
            SettingsManager.GetIntances().GetWindow().KeyPressed += Flying;

            // player stats
            _player = player;
            _player.SetPowerUpTime(0); // Not a powerup state
            _player.SetHp(1); // 1 HP max
            _player.SetJump(0); // 0 means that he can fly
            _player.SetAttackSpeed(1); // 1 Attack speed
            _player.SetLastAttack(0); // Reset attack timer (formula 1/AS)
            _player.SetInvulnerableTime(0); // Not invulnerable anymore
            _player.SetGravity(0); // Reset gravity

            _flyingSpeed = 0f;
            _flying = false;
        }

        public override void Update(float deltaTime, float velocity)
        {
            SetFlyingSpeed(deltaTime);
            _player.SetPositionY(_player.GetPositionY() - _flyingSpeed / 30);
            _player.SetLastAttack(_player.GetLastAttack() + deltaTime);
        }

        private void SetFlyingSpeed(float deltaTime)
        {
            // Reduce fly speed by little when at top or at bottom
            if (_player.GetPositionY() <= _player._maxHeightPosition)
            {
                // To decrease momentum
                if (_flyingSpeed > 0)
                {
                    _flyingSpeed -= deltaTime*2.5f;
                } 
                // Prevent to much momemtum decrease
                if (_flyingSpeed < 0)
                {
                    _flyingSpeed = 0;
                }
            } else if (_player.GetPositionY() >= _player._minHeightPosition)
            {
                // To decrease momentum
                if (_flyingSpeed < 0)
                {
                    _flyingSpeed += deltaTime*2.5f;
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
            Console.WriteLine("Shoot");
        }
    }
}
