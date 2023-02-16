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
        private float _positionX;
        private float _positionY;
        private float _maxHeight;
        private float _minHeight;

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

        public void SetmaxHeight(float maxHeight) 
        {
            this._maxHeight = maxHeight;
        }
        public float GetMaxHeight()
        {
            return this._maxHeight;
        }
        public void SetMinHeight(float minHeight) 
        { 
            this._minHeight = minHeight; 
        }  
        public float GetMinHeight()
        {
            return this._minHeight;
        }

    }
}
