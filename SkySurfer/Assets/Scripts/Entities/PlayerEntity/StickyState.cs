using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    class StickyState : PlayerBaseState
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
            player.FillColor = Color.Green;
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
            _player = player;
            _player.SetPowerUpTime(15); // Not a powerup state
        }

        public override void Update(float deltaTime, float velocity)
        {
            _player.SetPowerUpTime(_player.GetPowerUpTime() - deltaTime);
            if (_player.GetPowerUpTime() <= 0)
            {
                // Switch states
            }
        }
    }
}
