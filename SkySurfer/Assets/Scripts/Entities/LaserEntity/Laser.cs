using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.LaserEntity
{
    class Laser
    {
        private float _positionX = 1.25f;
        private float _positionY;
        public readonly float length;
        public readonly float minLength = 0.25f;
        public readonly float maxLength = 0.5f;
        public readonly float maxHeightPosition = 0.1f; // Always under roof
        public readonly float minHeightPosition;
        private FloatRect _hitbox;


        public Laser()
        {
            Random random = new();
            length = (float)random.NextDouble() * (maxLength - minLength) + minLength;
            minHeightPosition = 0.9f - length;
            _positionY = (float)random.NextDouble() * (minHeightPosition - maxHeightPosition) + maxHeightPosition;
        }

        public float GetPositionX()
        {
            return _positionX;
        }
        public void SetPositionX(float positionX)
        {
            _positionX = positionX;
        }

        public float GetPositionY()
        {
            return _positionY;
        }
        public void SetPositionY(float positionY)
        {
            _positionY = positionY;
        }
        public void SetLaserBounds(RectangleShape hitbox)
        {
            _hitbox = hitbox.GetGlobalBounds();
        }
        public FloatRect GetLaserBounds()
        {
            return _hitbox;
        }
    }
}
