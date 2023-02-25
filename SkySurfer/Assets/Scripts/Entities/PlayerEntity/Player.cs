using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    public class Player
    {
        private float _powerUpTime;
        private int _hp;
        private int _jump;
        private float _attackSpeed;
        private float _lastAttack;
        private float _invulnerableTime;
        private int _gravity;
        private float _positionY = 0.8f;
        private FloatRect _playerFloatRect;
        private int _score;
        public readonly float _maxHeightPosition = 0.1f;
        public readonly float _minHeightPosition = 0.8f;
        


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
        public float GetLastAttack()
        {
            return _lastAttack;
        }
        public void SetLastAttack(float lastAttack)
        {
            _lastAttack = lastAttack;
        }

        public float GetInvulnerableTime()
        {
            return _invulnerableTime;
        }

        public void SetInvulnerableTime(float time)
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
        public float GetPositionY()
        {
            return _positionY;
        }
        public void SetPositionY(float positionY)
        {
            _positionY = positionY;
            if (_positionY < _maxHeightPosition)
            {
                _positionY = _maxHeightPosition;
                return;
            }
            if (_positionY > _minHeightPosition)
            {
                _positionY = _minHeightPosition;
                return;
            }
        }
        public void SetPLayeryBounds(RectangleShape player)
        {
            this._playerFloatRect = player.GetGlobalBounds();
        }
        public FloatRect GetPlayerBounds()
        {
            return _playerFloatRect;
        }
        public void SetScore(int score)
        {
            _score = score;
        }
        public int GetScore()
        {
            return _score;
        }
    }
}
