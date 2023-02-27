using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PowerUpEntity
{
    class PowerUp
    {
        public readonly float maxHeightPosition = 0.1f;
        public readonly float minHeightPosition = 0.8f;
        public readonly float length = 0.075f;
        private float _positionX = 1.25f;
        public readonly float _positionY;
        private FloatRect _hitbox;

        public PowerUp()
        {
            _positionY = 0.5f + length / 2;
        }

        public void SetPositionX(float positionX)
        {
            _positionX = positionX;
        }

        public float GetPositionX()
        {
            return _positionX;
        }
        public void SetPLayeryBounds(RectangleShape hitbox)
        {
            this._hitbox = hitbox.GetGlobalBounds();
        }
        public FloatRect GetPlayerBounds()
        {
            return _hitbox;
        }
    }
}
