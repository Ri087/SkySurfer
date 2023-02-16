using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.EnemyEntity
{
    internal class Enemy
    {
        private int _damageHp;
        private float _positionX = 1.25f;
        private float _positionY = 0.8f;


        
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
    }
}
