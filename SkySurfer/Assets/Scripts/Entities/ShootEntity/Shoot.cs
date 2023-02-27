using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.ShootEntity
{
    internal class Shoot
    {
        public readonly float _length = 0.05f;
        public readonly float _height = 0.03f;
        private float _positionX = 0.15f;
        public readonly float _positionY;


        private FloatRect _ShootFloatRect;

        public Shoot()
        {
            _positionY = PlayerStateManager.GetInstance().GetPlayer().GetPositionY();
        }

        public void SetPositionX(float positionX)
        {
            _positionX = positionX;
        }
        public float GetPositionX()
        {
            return _positionX;
        }
        public void SetShootBounds(RectangleShape shoot)
        {
            this._ShootFloatRect = shoot.GetGlobalBounds();
        }
        public FloatRect GetShootBounds()
        {
            return this._ShootFloatRect;
        }
    }
}
