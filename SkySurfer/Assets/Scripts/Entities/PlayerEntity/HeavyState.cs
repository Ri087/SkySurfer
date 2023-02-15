using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    class HeavyState : PlayerBaseState
    {
        private Player _player;
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
            player.Position = new(windowX * 0.1f, windowY * _player.GetPositionY());
            SettingsManager.GetIntances().GetWindow().Draw(player);
        }

        public override void Exit()
        {

        }

        public override void HandleInput()
        {

        }

        public override void Init(Player player)
        {
            Console.WriteLine("ma mere la pute");
            _player = player;
            _player.SetPowerUpTime(15); // Not a powerup state
            _player.SetHp(2); // 1 HP max
            _player.SetAttackSpeed(1.5f); // 1 Attack speed
            _player.SetLastAttack(0); // Reset attack timer (formula 1/AS)
            _player.SetGravity(0); // Reset gravity
        }

        public override void Update(float deltaTime, float velocity)
        {
            _player.SetLastAttack(_player.GetLastAttack() + deltaTime);
            _player.SetPowerUpTime(_player.GetPowerUpTime() - deltaTime);
            if (_player.GetPowerUpTime() <= 0)
            {
                // Switch states
            }
        }
    }
}
