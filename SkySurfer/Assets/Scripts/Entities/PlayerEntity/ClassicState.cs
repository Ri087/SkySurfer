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
        public override void Cleanup()
        {

        }

        public override void Draw(RenderWindow window)
        {
            float windowX = window.Size.X;
            float windowY = window.Size.Y;

            // Player of the game
            RectangleShape player = new(new Vector2f(windowX * 0.06f, windowY * 0.1f));
            player.FillColor = Color.Black;
            player.Position = new(window.Size.X * 0.1f, window.Size.Y * _player.GetPositionY());
            window.Draw(player);
        }

        public override void Exit()
        {

        }

        public override void HandleInput()
        {

        }

        public override void Init(Player player)
        {
            _player = player;
            _player.SetPowerUpTime(0); // Not a powerup state
            _player.SetHp(1); // 1 HP max
            _player.SetJump(0); // 0 means that he can fly
            _player.SetAttackSpeed(1); // 1 Attack speed
            _player.SetLastAttack(0); // Reset attack timer (formula 1/AS)
            _player.SetInvulnerableTime(0); // Not invulnerable anymore
            _player.SetGravity(0); // Reset gravity
        }

        public override void Update(float deltaTime, float velocity)
        {
            _player.SetLastAttack(_player.GetLastAttack() + deltaTime);
            //PlayerStateManager.GetInstance().SwitchState(PlayerStateManager.GetInstance().GetStickyState()); switch states
        }
    }
}
