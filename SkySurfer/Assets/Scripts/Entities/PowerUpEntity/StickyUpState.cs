using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PowerUpEntity
{
    class StickyUpState : PowerUpBaseState
    {
        private PowerUp _powerUp;
        public StickyUpState()
        {
            _powerUp = new();
        }
        public override PowerUp GetPowerUp()
        {
            return _powerUp;
        }
        public override bool CheckIfOut()
        {
            return _powerUp.GetPositionX() < -0.25f;
        }
        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            RectangleShape powerUp = new(new Vector2f(windowX * _powerUp.length, windowY * _powerUp.length));

            powerUp.Position = new Vector2f(windowX * _powerUp.GetPositionX(), windowY * _powerUp._positionY);
            powerUp.FillColor = Color.Green;

            SettingsManager.GetIntances().GetWindow().Draw(powerUp);
        }
        public override void Init()
        {
            _powerUp = new();
        }

        public override void Update(float deltaTime, float velocity)
        {
            _powerUp.SetPositionX(_powerUp.GetPositionX() - deltaTime / 7.5f);
        }
    }
}
