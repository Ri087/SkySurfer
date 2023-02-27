using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.EnemyEntity
{
    internal class Enemy
    {
        private int _damageHp = 1;
        private float _positionX = 1.25f;
        private float _positionY;
        private FloatRect _EnemyFloatRect;

        public Enemy()
        {
            _positionY = (float)new Random().NextDouble() * 0.7f + 0.1f;
        }
        
        public void SetDamage(int damageHp)
        {
            this._damageHp = damageHp;
        }

        public int GetDamage()
        {
            return this._damageHp;
        }
        public void SetPositionX(float positionX)
        { 
            this._positionX = positionX;
        }      

        public float GetPositionX() 
        { 
            return this._positionX;
        }

        public void SetPositionY(float positionY) 
        { 
            this._positionY = positionY;
        }

        public float GetPositionY()
        { 
            return this._positionY;
        }
        public void SetEnemyBounds(RectangleShape enemy)
        {
            this._EnemyFloatRect = enemy.GetGlobalBounds();
        }
        public FloatRect GetEnemyBounds()
        {
            return _EnemyFloatRect;
        }
    }
}
