using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    class Player
    {
        private float _powerUpTime;
        private int _hp;
        private int _jump;
        private float _attackSpeed;
        private float _invulnerableTime;
        private int _gravity;

        public float GetPowerUpTime()
        {
            return _powerUpTime;
        }
        public void SetPowerUpTime(float time)
        {
            _powerUpTime = time;
        }

        public float GetHp()
        {
            return _hp;
        }

        public void SetHp(int hp)
        {
            _hp = hp;
        }
        public int GetJump()
        {
            return _jump;
        }

        public void SetJump(int jump)
        {
            _jump = jump;
        }

        public float GetAttackSpeed()
        {
            return _attackSpeed;
        }
        public void SetAttackSpeed(float attackSpeed)
        {
            _attackSpeed = attackSpeed; 
        }

        public float GetInvulnerableTime()
        {
            return _invulnerableTime;
        }

        public void SetInvulerableTime(float time)
        {
            _invulnerableTime = time;
        }

        public int GetGravity()
        {
            return _gravity;
        }

        public void SetGravity(int gravity)
        {
            _gravity = gravity;
        }
    }
}
