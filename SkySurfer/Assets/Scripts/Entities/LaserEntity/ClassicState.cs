using SFML.Graphics;
using SFML.System;
using SkySurfer.Assets.Scripts.Entities.EnemyEntity;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.LaserEntity
{
    class ClassicState : LaserBaseState
    {
        private Laser _laser;

        public ClassicState()
        {
            _laser = new();
        }
        public override bool CheckIfOut()
        {
            return _laser.GetPositionX() < -0.25f;
        }
        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            RectangleShape laser = new(new Vector2f(windowX * 0.015f, windowY * _laser.length));

            laser.Position = new Vector2f(windowX * _laser.GetPositionX(), windowY * _laser.GetPositionY());
            laser.FillColor = Color.Yellow;

            _laser.SetLaserBounds(laser);

            SettingsManager.GetIntances().GetWindow().Draw(laser);
        }
        public override void Update(float deltaTime, float velocity)
        {
            _laser.SetPositionX(_laser.GetPositionX() - deltaTime * velocity / 4);
        }
        public override FloatRect GetLaserHitBox()
        {
           return _laser.GetLaserBounds();
        }
    }
}
