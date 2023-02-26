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
        public readonly float length;
        public readonly float height;
        private float x;
        private float y;


        private FloatRect _ShootFloatRect;

        public Shoot()
        {
            length = 0.05f;
            height = 0.03f;
        }

        public void SetPositionX(float x)
        {
            this.x = x;
        }
        public float GetPositionX()
        {
            return this.x;
        }
        public void SetPositionY(float y)
        {
            this.y = y;
        }
        public float GetPositiony()
        {
            return this.y;
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
