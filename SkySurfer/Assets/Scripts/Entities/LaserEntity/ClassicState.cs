using SFML.Graphics;
using SFML.System;
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

        public override void Cleanup()
        {

        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            // Laser of the game
            RectangleShape laser = new(new Vector2f(windowX * 0.03f, windowY * _laser.length));
            laser.FillColor = Color.Black;
            laser.Position = new(windowX * _laser.GetPositionX(), windowY * _laser.GetPositionY());
            laser.Rotation = _laser.rotation;
            SettingsManager.GetIntances().GetWindow().Draw(laser);
        }

        public override void Exit()
        {
            
        }

        public override void HandleInput()
        {
            
        }

        public override void Init()
        {
            
        }

        public override void Update(float deltaTime, float velocity)
        {
            _laser.SetPositionX(_laser.GetPositionX() - deltaTime * velocity / 5);
        }
    }
}
